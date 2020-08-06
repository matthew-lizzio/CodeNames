using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace mml.CodeNames.Wpf.Model
{
    public class Tiles
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public TileTypes TileType { get; set; }
        public TileTypes DisplayedTileType { get; set; }
        public enum TileTypes
        {
            Neutral = 0,
            Red = 1,
            Blue = 2,
            Black = 3
        }
    }
}
