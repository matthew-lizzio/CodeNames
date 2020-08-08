using mml.CodeNames.Wpf.Model;
using mml.CodeNames.Wpf.ViewModel.Commands;
using mml.CodeNames.Wpf.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static mml.CodeNames.Wpf.Model.Tiles;

namespace mml.CodeNames.Wpf.ViewModel
{
    public class MainWindowVm : INotifyPropertyChanged
    {
        public ObservableCollection<Tiles> Gameboard { get; set; }

        private const string GOES_FIRST_STR = " Team Goes First!";
        private string whoGoesFirstText;
        public string WhoGoesFirstText
        {
            get { return whoGoesFirstText; }
            set
            {
                whoGoesFirstText = value;
                RaisePropertyChange();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChange([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public NewGameCommand NewGameCommand { get; set; }
        public TileClickCommand TileClickCommand { get; set; }
        public LaunchDictionaryManagerCommand LaunchDictionaryManagerCommand { get; set; }

        HttpClientController HttpClientController { get; set; }
        public MainWindowVm()
        {
            Gameboard = new ObservableCollection<Tiles>();
            HttpClientController = new HttpClientController();
            NewGameCommand = new NewGameCommand(this);
            TileClickCommand = new TileClickCommand(this);
            LaunchDictionaryManagerCommand = new LaunchDictionaryManagerCommand(this);
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
            WhoGoesFirstText = DetermineWhoGoesFirst();
        }
        public void RevealTile(int tileIndex)
        {
            var tile = Gameboard[tileIndex];
            tile.DisplayedTileType = tile.TileType;

            /// need to force observablecollection to refresh. Probably should have used a different class
            Gameboard.RemoveAt(tileIndex);
            Gameboard.Insert(tileIndex, tile);
        }

        public string DetermineWhoGoesFirst()
        {            
            int redCount = 0;
            int blueCount = 0;
            foreach (var item in Gameboard)
            {
                if (item.TileType == TileTypes.Red)
                {
                    ++redCount;
                }
                else if (item.TileType == TileTypes.Blue)
                {
                    ++blueCount;
                }
            }
            string team = (redCount > blueCount) ? "Red" : "Blue";
            return team + GOES_FIRST_STR;
        }
        public async Task<List<TileWords>> RetrieveDictionary()
        {
            return await HttpClientController.RetrieveDictionary();
        }
    }
}
