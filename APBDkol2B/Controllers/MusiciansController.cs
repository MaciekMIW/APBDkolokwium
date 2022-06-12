using APBDkol2B.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDkol2B.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class MusiciansController : Controller
    {
        private readonly IDbService _dbService;
        public MusiciansController(DbService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMusician(int id)
        {
            if (!await _dbService.CheckIfMusicianExists(id))
            {
                return BadRequest("no such musician");
            }
            var musician = _dbService.GetMusician(id);
            return Ok(musician);
        }
    }
}
