using OzhanHr.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Domain.Entities.Leave
{
    public class LeaveRequest:BaseDomain
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime? DataActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }

        #region Relations

        public LeaveType LeaveType { get; set; }
        [ForeignKey(nameof(LeaveType))]
        public int LeaveType_Id { get; set; }
        #endregion
    }
}
