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
        public static SQLite.SQLiteConnection SQLiteConnection { get; set; }
        
        public static IList<TileWords> TileWords { get; private set; }

        public static IList<Tiles> Gameboard{ get; private set; }
        public static void WriteGameboard()
        {
            // SQLiteConnection.DeleteAll<Tiles>();
            foreach (var item in Gameboard)
            {
                SQLiteConnection.InsertOrReplace(item);
            }            
            SQLiteConnection.Commit();
        }

        public static void InitializeDatabase()
        {
            SQLiteConnection = new SQLite.SQLiteConnection(Program.DatabasePath);

            /// - Create tables                
            SQLiteConnection.CreateTable<TileWords>();
            SQLiteConnection.CreateTable<Tiles>();

            /// - Populate class table attributes
            TileWords = SQLiteConnection.Table<TileWords>().ToList();
            Gameboard = SQLiteConnection.Table<Tiles>().ToList();


        }

    }
}
