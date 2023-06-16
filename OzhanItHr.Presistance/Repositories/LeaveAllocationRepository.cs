using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Domain.Entities.Leave;
using OzhanItHr.Persistence.Context;

namespace OzhanItHr.Persistence.Repositories
{
    public class LeaveAllocationRepository:GenericRepository<LeaveAllocation>,ILeaveAllocationRepository
    {
        private readonly DefaultDbContext _context;

        public LeaveAllocationRepository(DefaultDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
