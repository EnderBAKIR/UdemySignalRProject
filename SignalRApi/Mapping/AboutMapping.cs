using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
          CreateMap<About , ResultAboutDto>().ReverseMap();
          CreateMap<About , CreateAboutDto>().ReverseMap();
          CreateMap<About , UpdateAboutDto>().ReverseMap();
          CreateMap<About , GetAboutDto>().ReverseMap();
        }
    }
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
        }
    }
}
