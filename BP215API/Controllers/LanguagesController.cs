using AutoMapper;
using BP215API.DTOs.Languages;
using BP215API.Entities;
using BP215API.Exceptions;
using BP215API.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP215API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController(ILanguageService _service, IMapper _mapper) : ControllerBase
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
        public async Task<IActionResult> Update( string code , LanguageUpdateDto dto)
        {
            await _service.UpdateAsync(dto , code);
            return Ok();
        }
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            await _service.DeleteAsync(code); 
            return Ok();
        }
    }
}
