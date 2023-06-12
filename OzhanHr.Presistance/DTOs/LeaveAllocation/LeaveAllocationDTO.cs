using OzhanHr.Application.DTOs.CommonDto;
using OzhanHr.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDTO : BaseDomainDTO, ILeaveAllocationValidation
    {
        public int NumberOfDays { get; set; }

        public int Period { get; set; }


        #region Relations

        public LeaveTypeDTO LeaveTypeDTO { get; set; }
        [ForeignKey(nameof(LeaveTypeDTO))]
        public int LeaveType_Id { get; set; }
        #endregion
    }
}
