using BP215API.DTOs.Games;
using BP215API.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BP215API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameService _service , IMemoryCache _cache) : ControllerBase
    {
        [HttpPost]
        public async  Task<IActionResult>  Create(GameCreateDto dto )
        { 
            return Ok(await _service.CreateAsync(dto));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Start(Guid id)
        {
            return Ok(await _service.Start(id));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Skip(Guid id)
        {
            return Ok(await _service.Skip(id));
        }





        //[HttpGet("[action]")]
        //public async Task<IActionResult> Get(string key)
        //{ 
        //    return Ok(_cache.Get(key));
        //}
        //[HttpGet("[action]")]
        //public async Task<IActionResult> Set(string key , string value)
        //{
        //    _cache.Set<string>(key, value, DateTime.Now.AddSeconds(20));
        //    return Ok();
        //}

    }
}
