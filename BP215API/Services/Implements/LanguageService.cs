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

        Task<IEnumerable<LanguageCreateDto>> ILanguageService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        //Task<IEnumerable<LanguageCreateDto>> ILanguageService.GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
