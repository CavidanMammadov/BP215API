using AutoMapper;
using BP215API.DAL;
using BP215API.DTOs.Games;
using BP215API.Entities;
using BP215API.Services.Abstracts;

namespace BP215API.Services.Implements
{
    public class GameService(BP215APIDbContext _context ,IMapper _mapper) : IGameService
    {
        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {  var game = _mapper.Map<Game>(dto);
            await _context.Games.AddAsync(game);
           await _context .SaveChangesAsync();
            return game.Id;
        }

        public Task FailAnswer()
        {
            throw new NotImplementedException();
        }

        public Task SkippedAnswer()
        {
            throw new NotImplementedException();
        }

        public Task Start(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task WrongAnswer()
        {
            throw new NotImplementedException();
        }
    }
}
