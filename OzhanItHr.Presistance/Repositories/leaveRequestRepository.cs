using Microsoft.EntityFrameworkCore;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Domain.Entities.Leave;
using OzhanItHr.Persistence.Context;

namespace OzhanItHr.Persistence.Repositories
{
    public class leaveRequestRepository:GenericRepository<LeaveRequest>, IleaveRequestRepository
    {
        private readonly DefaultDbContext _context;

        public leaveRequestRepository(DefaultDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task UpdateApprovedStatus(LeaveRequest leaveRequest, bool? IsApproved)
        {
            leaveRequest.Approved=IsApproved;
            _context.Entry(leaveRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _context.LeaveRequests
                .Include(l => l.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _context.LeaveRequests
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(l => l.Id == id);
            return leaveRequest;
        }
    }
}
