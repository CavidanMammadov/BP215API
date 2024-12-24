using BP215API.DTOs.Games;
using BP215API.Entities;

namespace BP215API.Services.Abstracts
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(GameCreateDto dto);
        Task Start(Guid Id);
        Task WrongAnswer();
        Task FailAnswer();
        Task SkippedAnswer();
    }
}
