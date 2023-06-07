using OzhanHr.Application.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Application.DTOs.LeaveType
{
    public class LeaveTypeDTO:BaseDomainDTO
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
