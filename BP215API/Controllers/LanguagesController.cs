using BP215API.DTOs.Languages;
using BP215API.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP215API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController(ILanguageService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create( LanguageCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }
        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            return Ok();
        }
    }
}
