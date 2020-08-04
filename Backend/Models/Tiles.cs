using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mml.CodeNames.Backend.Models
{
    public class Tiles
    {        
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }        
        public string Word { get; set; }

        [EnumDataType(typeof(TileTypes))]
        public TileTypes TileType { get; set; }
        public enum TileTypes
        {
            Neutral = 0,
            Red = 1,
            Blue = 2,
            Black = 3
        }
    }
}
