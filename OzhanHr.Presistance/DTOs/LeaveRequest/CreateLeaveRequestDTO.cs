using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Application.DTOs.LeaveRequest
{
    public class CreateLeaveRequestDTO: IleaveRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveType_Id { get; set; }
        public string RequestComments { get; set; }
    }
}
