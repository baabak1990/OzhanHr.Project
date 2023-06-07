using OzhanHr.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Domain.Entities.Leave
{
    public class LeaveAllocation: BaseDomain
    {
        public int NumberOfDays { get; set; }
      
        public int Period { get; set; }


        #region Relations

        public LeaveType LeaveType { get; set; }
        [ForeignKey(nameof(LeaveType))]
        public int LeaveType_Id { get; set; }
        #endregion
    }
}
