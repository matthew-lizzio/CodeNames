using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using System.Text;

namespace mml.CodeNames.Wpf.ViewModel.Helper
{
    public static class UrlConsts
    {
        public const string GAMEBOARD = "Gameboard";
        public const string NEW_GAME = "NewGame";
        public const string TILE_WORDS = "TileWords";
        public const string BASE_URL = "http://localhost:5000";

        public static string GetBaseUrl()
        {
            ///\todo Should probably get this from config file in case I ever want to try to deploy this
            return BASE_URL;
        }
        public static string GetNewGameUrl()
        {
            return GetBaseUrl() + Path.AltDirectorySeparatorChar + GAMEBOARD + Path.AltDirectorySeparatorChar + NEW_GAME;
        }
        public static string GetGameboardUrl()
        {
            return GetBaseUrl() + Path.AltDirectorySeparatorChar + GAMEBOARD;
        }
        public static string GetTileLibraryUrl()
        {
            return GetBaseUrl() + Path.AltDirectorySeparatorChar + TILE_WORDS;
        }
    }
}
