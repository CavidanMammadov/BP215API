using AutoMapper;
using BP215API.DAL;
using BP215API.DTOs.Games;
using BP215API.DTOs.Words;
using BP215API.Entities;
using BP215API.Extensions;
using BP215API.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace BP215API.Services.Implements
{
    public class GameService(BP215APIDbContext _context, IMapper _mapper, IMemoryCache _cache) : IGameService
    {
        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {
            var game = _mapper.Map<Game>(dto);
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }
        public async Task<WordForGameDto> Skip(Guid id)
        {
            var status = _getCurrentGame(id);
            if(status.Skip <= status.MaxSkipCount)
            {
                var currentWord = status.Words.Pop();
                status.Skip++;
                _cache.Set(id, status ,TimeSpan.FromSeconds(300));
                return currentWord;
            }
            return null;
        }
        public async Task<WordForGameDto> Start(Guid id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null || game.Score != null)
            {
                throw new Exception();
            }
            IQueryable<WordForGame> query = _context.Words.Where(x => x.LanguageCode == game.LanguageCode);
            var words = await _context.Words.Where(x => x.LanguageCode == game.LanguageCode)
                .Select(x => new WordForGameDto
                {
                    Word = x.Text,
                    BannedWords = x.BannedWords.Select(y => y.Text)
                })
                  .Random(await query.CountAsync())
                  .Take(20)
                  .ToListAsync();

            var wordStack = new Stack<WordForGameDto>(words);
            WordForGameDto currentWord = wordStack.Pop();
            GameStatusDto status = new GameStatusDto()
            {
                Fail = 0,
                Skip = 0,
                Succes = 0,
                Words = wordStack,
                MaxSkipCount = game.SkipCount,
                UsedWordIds = words.Select(x => x.Id)

            }; 
            _cache.Set(id, status, TimeSpan.FromSeconds(300));
            return currentWord;
        }

        public Task Fail()
        {
            throw new NotImplementedException();
        }

       


        public Task Wrong()
        {
            throw new NotImplementedException();
        }


        public Task End (Guid id)
        {
            throw new NotImplementedException();
        }

        GameStatusDto _getCurrentGame(Guid id)
        {
            var result = _cache.Get<GameStatusDto>(id);
            if (result == null) throw new Exception();
            return result;
        }
    }
}
