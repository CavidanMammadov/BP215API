using BP215API.DAL;
using BP215API.DTOs.Words;
using BP215API.Entities;
using BP215API.Services.Abstracts;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BP215API.Services.Implements
{
    public class WordService(BP215APIDbContext _context) : IWordService
    {
        public async Task<int> Create(WordCreateDto dto)
        {
            Word word = new Word
            {
                LanguageCode = dto.LanguageCode,
                BannedWords = dto.BannedWords.Select(x => new BannedWord
                {
                    Text = x
                }).ToList()
            };
            await _context.Words.AddAsync(word);
            await _context.SaveChangesAsync();
            return word.Id;
        }
    }
}
