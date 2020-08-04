using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mml.CodeNames.Backend.DataAccessLibrary;
using mml.CodeNames.Backend.Models;

namespace mml.CodeNames.Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameboardController : ControllerBase
    {
        private readonly ILogger<GameboardController> _logger;

        public GameboardController(ILogger<GameboardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Tiles> Get()
        {
            return DataAccess.Gameboard;
        }


        [HttpGet("NewGame")]
        public IList<Tiles> GetNewGame()
        {            
            var gb = DataAccess.Gameboard;
            var newWords = GenerateNewWords();
            return gb;
        }

        public List<TileWords> GenerateNewWords()
        {
            var copyList = new List<TileWords>();
            var newList = new List<TileWords>();
            copyList.AddRange(DataAccess.TileWords);

            Random rnd = new Random();
            while (newList.Count < 25)
            {
                int index = rnd.Next(0, copyList.Count);
                newList.Add(copyList[index]);
                copyList.RemoveAt(index);
            }
            return newList;
        }
    }
}
