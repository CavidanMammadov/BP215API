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
            try
            {
                await _service.CreateAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                if(ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        StatusCode = bEx.StatusCode,
                        Message =bEx.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = ex.Message
                    });
                }
                
            }
         
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
