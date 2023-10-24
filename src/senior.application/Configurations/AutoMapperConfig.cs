using AutoMapper;
using senior.application.ViewModels.Account;
using senior.application.ViewModels.Locality;
using senior.domain.Entites;

namespace senior.application.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            _ = CreateMap<ListIbgeViewModel, Locality>().ReverseMap()
                .ForMember(
                    dest => dest.IbgeCode,
                    opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.City.Value))
                .ForMember(
                    dest => dest.State,
                    opt => opt.MapFrom(src => src.State.Value));

            _ = CreateMap<ListUserViewModel, User>().ReverseMap();
        }
    }
}
