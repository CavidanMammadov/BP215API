using BP215API.DAL;
using BP215API.DTOs.Languages;
using BP215API.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace BP215API.Services.Implements
{
    public class LanguageService(BP215APIDbContext _context) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            await _context.Languages.AddAsync(new Entities.Language
            {
                Code = dto.Code,
                Name = dto.Name,
                Icon = dto.Icon,
            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
           return await _context.Languages.Select(x=> new LanguageGetDto { 
           
               Name = x.Name,
               Icon = x.Icon,
               Code = x.Code,
           
           }).ToListAsync();
        }

        Task<IEnumerable<LanguageCreateDto>> ILanguageService.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
