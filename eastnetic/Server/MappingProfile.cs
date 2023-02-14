using AutoMapper;
using AutoMapper.Configuration;
using eastnetic.Shared.DTO;
using eastnetic.Shared.Model;

namespace eastnetic.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Window, WindowDto>()
                .ForMember(m => m.Order, opt => opt.Ignore())
                .ForMember(m => m.TotalSubElements, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<WindowDto, Window>()
                .ForMember(m => m.Order, opt => opt.Ignore())
                .ForMember(m => m.TotalSubElements, opt => opt.Ignore());

            CreateMap<SubElement, SubElementDto>().ReverseMap();
            CreateMap<SubElementDto, SubElement>()
                .ForMember(m => m.Window, opt => opt.Ignore());
        }
    }
}