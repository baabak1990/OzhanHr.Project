using OzhanHr.Application.DTOs.CommonDto;
using OzhanHr.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDTO : BaseDomainDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime DataActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }

        #region Relations

        public LeaveTypeDTO LeaveTypeDTO { get; set; }
        [ForeignKey(nameof(LeaveTypeDTO))]
        public int LeaveType_Id { get; set; }
        #endregion
    }
}
