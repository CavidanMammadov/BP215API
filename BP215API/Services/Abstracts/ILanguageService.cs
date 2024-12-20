using BP215API.DTOs.Languages;
using System.Collections;

namespace BP215API.Services.Abstracts
{
    public interface ILanguageService
    {
        Task CreateAsync(LanguageCreateDto dto);
        Task<IEnumerable<LanguageCreateDto>> GetAllAsync();

    }
}
