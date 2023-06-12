namespace OzhanHr.Application.DTOs.LeaveRequest;

public interface IleaveRequestDTO
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveType_Id { get; set; }
    public string RequestComments { get; set; }
}