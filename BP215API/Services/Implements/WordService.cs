using AutoMapper;
using BP215API.DAL;
using BP215API.DTOs.Words;
using BP215API.Entities;
using BP215API.Services.Abstracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BP215API.Services.Implements
{
    public class WordService(BP215APIDbContext _context, IMapper _mapper) : IWordService
    {
       
        public async Task<int> CreateAsync(WordCreateDto dto)
        {
            WordForGame word = new WordForGame
            {
                LanguageCode = dto.LanguageCode,
               Text= dto.Text
            };
            word.BannedWords = dto.BannedWords.Select(x => new BannedWord
            {
                Text = x
            }).ToList();
            await _context.Words.AddAsync(word);
            await _context.SaveChangesAsync();
            return word.Id;
        }
        public async Task<IEnumerable<WordGetDto>> GetAllAsync()
        {
            var datas = await _context.Words.ToListAsync();
            return _mapper.Map<IEnumerable<WordGetDto>>(datas);
        }

        public async Task UpdateAsync(WordUpdateDto dto, int id)
        {
            var data = await _context.Words.FindAsync(id);
            data.Text = dto.Text;
            data.LanguageCode = dto.LanguageCode;
            data.BannedWords = (ICollection<BannedWord>)dto.BannedWords;
            await _context.SaveChangesAsync();
           
           
        }
        public async Task DeleteAsync(int id)
        {
            var data = await _context.Words.FindAsync(id);
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }


    }
}
