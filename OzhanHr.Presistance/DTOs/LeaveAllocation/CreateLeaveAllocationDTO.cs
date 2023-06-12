using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDTO
    {
        public int NumberOfDays { get; set; }
        public int LeaveType_Id { get; set; }
        public int Period { get; set; }
    }
}
