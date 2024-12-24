using BP215API.DTOs.Words;

namespace BP215API.Services.Abstracts
{
    public interface IWordService
    {
        Task<int>  CreateAsync(WordCreateDto dto);
        Task<IEnumerable<WordGetDto>> GetAllAsync();
        Task UpdateAsync(WordUpdateDto dto , int id );
        Task DeleteAsync(int id);
    }
}
