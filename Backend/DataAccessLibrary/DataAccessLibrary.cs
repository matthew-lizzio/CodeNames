using mml.CodeNames.Backend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace mml.CodeNames.Backend.DataAccessLibrary
{
    public static class DataAccess
    {
        public static IList<TileWords> TileWords { get; set; }
        public static IList<Tiles> Gameboard { get; set; }
        public static void InitializeDatabase()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(Program.DatabasePath))
            {
                /// - Create tables                
                conn.CreateTable<TileWords>();
                conn.CreateTable<Tiles>();

                /// - Cleanup 

                /// - Populate class table attributes
                TileWords = conn.Table<TileWords>().ToList();
                Gameboard = conn.Table<Tiles>().ToList();
                
            }            
        }
        
    }
}
