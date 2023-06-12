using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanHr.Application.DTOs.CommonDto;

namespace OzhanHr.Application.DTOs.LeaveAllocation
{
    public class ChangeLeaveAllocationDTO : BaseDomainDTO
    {
        public int NumberOfDays { get; set; }
        public int Period { get; set; }
        public int LeaveType_Id { get; set; }
    }
}
