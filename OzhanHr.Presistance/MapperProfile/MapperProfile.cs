using AutoMapper;
using OzhanHr.Application.DTOs.LeaveAllocation;
using OzhanHr.Application.DTOs.LeaveRequest;
using OzhanHr.Application.DTOs.LeaveType;
using OzhanHr.Application.DTOs.LeaveType.Validation;
using OzhanHr.Domain.Entities.Leave;


namespace OzhanHr.Application.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region LeaveAllocation
            CreateMap<LeaveAllocation, LeaveAllocationDTO>().ReverseMap();
            CreateMap<ChangeLeaveAllocationDTO, LeaveAllocation>();
            CreateMap<CreateLeaveAllocationDTO, LeaveAllocation>();
            #endregion
            #region LeaveRequest
            CreateMap<LeaveRequestDTO, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequestListDTO, LeaveRequest>().ReverseMap();
            CreateMap<ChangeLeaveRequestStatuesDTO, LeaveRequest>();
            CreateMap<CreateLeaveRequestDTO, LeaveRequest>();
            CreateMap<LeaveRequestChangeApprovalStatuesDTO, LeaveRequest>();

            #endregion
            #region LeaveType
            CreateMap<LeaveTypeDTO, LeaveTypeDTO>().ReverseMap();
            CreateMap<LeaveTypeValidation, LeaveType>();
            CreateMap<CreateLeaveTypeDTO, LeaveType>();
            #endregion
        }
    }
}
