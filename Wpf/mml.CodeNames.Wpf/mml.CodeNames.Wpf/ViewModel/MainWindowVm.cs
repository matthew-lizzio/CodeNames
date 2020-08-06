using mml.CodeNames.Wpf.Model;
using mml.CodeNames.Wpf.ViewModel.Commands;
using mml.CodeNames.Wpf.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media;
using static mml.CodeNames.Wpf.Model.Tiles;

namespace mml.CodeNames.Wpf.ViewModel
{
    public class MainWindowVm
    {
        public ObservableCollection<Tiles> Gameboard { get; set; }
        public NewGameCommand NewGameCommand { get; set; }
        public TileClickCommand TileClickCommand { get; set; }
        
        HttpClientController HttpClientController { get; set; }
        public MainWindowVm()
        {
            Gameboard = new ObservableCollection<Tiles>();
            HttpClientController = new HttpClientController();
            NewGameCommand = new NewGameCommand(this);
            TileClickCommand = new TileClickCommand(this);
        }

        public async void StartNewGame()
        {
            var newGameboard = await HttpClientController.StartNewGame();

            Gameboard.Clear();
            foreach (var item in newGameboard)
            {
                item.DisplayedTileType = TileTypes.Neutral;
                Gameboard.Add(item);
            }
        }
        public void RevealTile(int tileIndex)
        {
            var tile = Gameboard[tileIndex];
            tile.DisplayedTileType = tile.TileType;
            Gameboard.RemoveAt(tileIndex);
            Gameboard.Insert(tileIndex, tile);

        }
    }
}
