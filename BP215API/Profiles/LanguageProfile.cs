using AutoMapper;
using BP215API.DTOs.Languages;
using BP215API.Entities;

namespace BP215API.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageCreateDto, Language>()
                .ForMember(l => l.Icon, lcd => lcd.MapFrom(x => x.IconUrl));
            CreateMap<Language, LanguageCreateDto>();
        }
    }
}
