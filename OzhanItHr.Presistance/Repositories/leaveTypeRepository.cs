using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Domain.Entities.Leave;
using OzhanItHr.Persistence.Context;

namespace OzhanItHr.Persistence.Repositories
{
    public class leaveTypeRepository:GenericRepository<LeaveType>, IleaveTypeRepository
    {
        private readonly DefaultDbContext _context;

        public leaveTypeRepository(DefaultDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
