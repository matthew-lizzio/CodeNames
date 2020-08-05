using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mml.CodeNames.Backend.DataAccessLibrary;
using mml.CodeNames.Backend.Models;
using static mml.CodeNames.Backend.Models.Tiles;

namespace mml.CodeNames.Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameboardController : ControllerBase
    {
        private readonly int numberOfTiles = 25;
        private readonly ILogger<GameboardController> _logger;
        private readonly TileTypes[] _tileTypeList = {
            TileTypes.Neutral, TileTypes.Neutral, TileTypes.Neutral, TileTypes.Neutral, TileTypes.Neutral,
            TileTypes.Neutral, TileTypes.Neutral, TileTypes.Neutral, TileTypes.Neutral, TileTypes.Neutral,
            TileTypes.Neutral, TileTypes.Red, TileTypes.Red, TileTypes.Red, TileTypes.Red,
            TileTypes.Red, TileTypes.Red, TileTypes.Blue, TileTypes.Blue, TileTypes.Blue,
            TileTypes.Blue, TileTypes.Blue, TileTypes.Blue, TileTypes.Black
        };


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
            var newWords = GenerateNewWords();
            var newSolution = GenerateNewSolution();
            DataAccess.Gameboard.Clear();

            for (int i = 0; i < numberOfTiles; ++i)
            {
                DataAccess.Gameboard.Add(new Tiles { Id = i, Word = newWords[i].Word, TileType = newSolution[i] });
            }

            DataAccess.WriteGameboard();
            return DataAccess.Gameboard;
        }

        public List<TileWords> GenerateNewWords()
        {
            return SelectNFromList<TileWords>(DataAccess.TileWords.ToList(), numberOfTiles);
        }
        public List<TileTypes> GenerateNewSolution()
        {
            var tt = _tileTypeList.ToList();
            Random rnd = new Random();
            tt.Add(rnd.Next(0, 2) == 0 ? TileTypes.Red : TileTypes.Blue);
            return SelectNFromList<TileTypes>(tt, tt.Count);

        }

        public static List<T> SelectNFromList<T>(List<T> listToSelectFrom, int n)
        {
            var copyList = new List<T>();
            var newList = new List<T>();
            copyList.AddRange(listToSelectFrom);

            Random rnd = new Random();
            while (newList.Count < n)
            {
                int index = rnd.Next(0, copyList.Count);
                newList.Add(copyList[index]);
                copyList.RemoveAt(index);
            }
            return newList;
        }

        [HttpGet("test")]
        public async Task<IActionResult> Gett()
        {
            // var image = System.IO.File.OpenRead(@"C:\Users\Matt\Pictures\OnixCeptable.png");
            //return await Task.Run(() => File(image, "image/png"));

            Bitmap bmp = new Bitmap(50, 50);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.Green, 0, 0, 50, 50);
            MemoryStream memoryStream = new MemoryStream();
            bmp.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] file = memoryStream.ToArray();
            MemoryStream ms = new MemoryStream();
            ms.Write(file, 0, file.Length);
            ms.Position = 0;

            return await Task.Run(() => File(fileStream: ms, contentType: "image/png"));
        }

        [HttpGet("test2")]
        public ActionResult MyHtmlView()
        {
            return Content("<html><body>Ahoy.</body></html>", "text/html");
        }

    }
}
