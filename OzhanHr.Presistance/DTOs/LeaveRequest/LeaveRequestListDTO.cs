using OzhanHr.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDTO
    {
        public LeaveTypeDTO LeaveTypeDTO { get; set; }
        public DateTime RequestedDate { get; set; }
        public bool? IsApproved { get; set; }
    }
}
