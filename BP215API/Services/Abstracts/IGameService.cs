using BP215API.DTOs.Games;
using BP215API.DTOs.Words;
using BP215API.Entities;

namespace BP215API.Services.Abstracts
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(GameCreateDto dto);
        Task<WordForGameDto> Start(Guid id);
        Task<WordForGameDto> Skip(Guid id);
        Task Wrong();
        Task Fail();
        Task End (Guid id);
    }
}
