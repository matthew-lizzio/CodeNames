using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mml.CodeNames.Backend.DataAccessLibrary;
using mml.CodeNames.Backend.Models;

namespace mml.CodeNames.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TileWordsController : ControllerBase
    {        
        private readonly ILogger<TileWordsController> _logger;

        public TileWordsController(ILogger<TileWordsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<TileWords> GetTileWords()
        {
            return DataAccess.TileWords;
        }

        [HttpGet("test")]
        public async Task<IActionResult> Gett()
        {           
            var image = System.IO.File.OpenRead(@"C:\Users\Matt\Pictures\OnixCeptable.png");
            return await Task.Run( ()=> File(image, "image/png"));
        }
    }
}
