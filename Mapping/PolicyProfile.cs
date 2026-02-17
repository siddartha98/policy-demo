using AutoMapper;
using PolicyDemo.Domain;
using PolicyDemo.Dtos;

namespace PolicyDemo.Mapping
{
    public class PolicyProfile : Profile
    {
        public PolicyProfile()
        {
            // Create maps between domain entity and DTOs
            CreateMap<Policy, PolicyDto>().ReverseMap();
            CreateMap<CreatePolicyDto, Policy>()
                // PolicyNumber / IsCancelled / CancelledDate are set server-side — ignore when mapping from DTO
                .ForMember(dest => dest.PolicyNumber, opt => opt.Ignore())
                .ForMember(dest => dest.IsCancelled, opt => opt.Ignore())
                .ForMember(dest => dest.CancelledDate, opt => opt.Ignore());
        }
    }
}
