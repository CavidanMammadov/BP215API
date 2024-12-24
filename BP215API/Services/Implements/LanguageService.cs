using AutoMapper;
using BP215API.DAL;
using BP215API.DTOs.Languages;
using BP215API.Entities;
using BP215API.Exceptions.Languages;
using BP215API.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace BP215API.Services.Implements
{
    public class LanguageService(BP215APIDbContext _context, IMapper _mapper) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code == dto.Code))
                throw new LanguageExistException();
            await _context.Languages.AddAsync(_mapper.Map<Language>(dto));
            await _context.SaveChangesAsync();
        }

        

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            var datas =  await _context.Languages.ToListAsync();
           return _mapper.Map<IEnumerable<LanguageGetDto>>(datas);
        }

        public async Task UpdateAsync(LanguageUpdateDto dto, string code)
        {
            var data = await _context.Languages.FindAsync( code);
            data.Name = dto.Name;
            data.Icon = dto.Icon;
            await _context.SaveChangesAsync();
           
        }
        public async Task DeleteAsync(string code)
        {
            var data = await _context.Languages.FindAsync(code);
            _context.Languages.Remove(data);
            await _context.SaveChangesAsync();
        }




    }
}
