using AutoMapper;
using OzhanHr.Application.DTOs.LeaveAllocation;
using OzhanHr.Application.DTOs.LeaveRequest;
using OzhanHr.Application.DTOs.LeaveType;
using OzhanHr.Domain.Entities.Leave;


namespace OzhanHr.Application.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region LeaveAllocation
            CreateMap<LeaveAllocation, LeaveAllocationDTO>().ReverseMap();
            #endregion
            #region LeaveRequest
            CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveRequestDTO, LeaveRequestListDTO>().ReverseMap();
            #endregion
            #region LeaveType
            CreateMap<LeaveType, LeaveTypeDTO>().ReverseMap();
            #endregion
        }
    }
}
