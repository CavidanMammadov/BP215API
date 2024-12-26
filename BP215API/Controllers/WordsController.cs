using BP215API.DTOs.Words;
using BP215API.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP215API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordService _service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(WordCreateDto dto)
        {
          await _service.CreateAsync(dto);
            return Ok();
        } 
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMany(List<WordCreateDto> dto)
        {foreach (var item in dto)
            {
                await _service.CreateAsync(item);
            }
            return Ok();
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(WordUpdateDto dto ,  int id)
        {
            await _service.UpdateAsync(dto, id);
            return Ok();
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int id )
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

    }
}
