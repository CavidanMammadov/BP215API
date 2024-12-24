using AutoMapper;
using BP215API.DTOs.Games;
using BP215API.Entities;

namespace BP215API.Profiles
{
    public class WordProfile: Profile
    {
        public WordProfile()
        {
            CreateMap<GameCreateDto, Game>();
        }
    }
}
