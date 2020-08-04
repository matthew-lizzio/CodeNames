using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mml.CodeNames.Backend.Models
{
    public class TileWords
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }        
        public string Word { get; set; }
    }
}
