using OzhanHr.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Domain.Entities.Leave
{
    public class LeaveType:BaseDomain
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
       
    }
}
