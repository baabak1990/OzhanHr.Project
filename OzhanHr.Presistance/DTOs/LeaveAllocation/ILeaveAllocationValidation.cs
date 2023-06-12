using OzhanHr.Application.DTOs.LeaveType;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzhanHr.Application.DTOs.LeaveAllocation;

public interface ILeaveAllocationValidation
{
    public int NumberOfDays { get; set; }
    public int Period { get; set; }
    public int LeaveType_Id { get; set; }
}