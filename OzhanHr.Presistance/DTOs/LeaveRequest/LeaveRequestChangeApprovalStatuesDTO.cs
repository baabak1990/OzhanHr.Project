using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanHr.Application.DTOs.CommonDto;

namespace OzhanHr.Application.DTOs.LeaveRequest
{
    public class LeaveRequestChangeApprovalStatuesDTO:BaseDomainDTO
    {
        public bool? IsApproved { get; set; }
    }
}
