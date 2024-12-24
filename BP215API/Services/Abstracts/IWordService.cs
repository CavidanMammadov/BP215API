using BP215API.DTOs.Words;

namespace BP215API.Services.Abstracts
{
    public interface IWordService
    {
        Task<int>  CreateAsync(WordCreateDto dto);
    }
}
