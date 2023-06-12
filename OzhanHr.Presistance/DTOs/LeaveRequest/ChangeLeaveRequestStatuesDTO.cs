using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanHr.Application.DTOs.CommonDto;

namespace OzhanHr.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestStatuesDTO:BaseDomainDTO,IleaveRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveType_Id { get; set; }
        public string RequestComments { get; set; }
        public bool? IsCancelled { get; set; }
    }
}
