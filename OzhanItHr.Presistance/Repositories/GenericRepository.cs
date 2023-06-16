using Microsoft.EntityFrameworkCore;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanItHr.Persistence.Context;

namespace OzhanItHr.Persistence.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class
    {
        private readonly DefaultDbContext _context;

        public GenericRepository(DefaultDbContext context)
        {
            _context = context;
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
           _context.Entry(entity).State= EntityState.Modified;
           await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }
    }
}
