using mml.CodeNames.Wpf.Model;
using mml.CodeNames.Wpf.ViewModel.Commands;
using mml.CodeNames.Wpf.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace mml.CodeNames.Wpf.ViewModel
{
    public class DictionaryManagerWindowVm
    {
        public ObservableCollection<TileWords> Dictionary { get; set; }
        public TileWords NewWord { get; set; }
        public UpdateDictionaryCommand UpdateDictionaryCommand { get; set; }
        public AddWordCommand AddWordCommand { get; set; }

        HttpClientController HttpClientController { get; set; }
        public DictionaryManagerWindowVm()
        {
            HttpClientController = new HttpClientController();
            Dictionary = new ObservableCollection<TileWords>();    
            NewWord = new TileWords();
            UpdateDictionaryCommand = new UpdateDictionaryCommand(this);
            AddWordCommand = new AddWordCommand(this);
            InitDictionary();
        }
        public async void InitDictionary()
        {
            var tw = await HttpClientController.RetrieveDictionary();
            foreach (var item in tw)
            {
                Dictionary.Add(item);
            }
        }

        public void AddWord()
        {
            Dictionary.Add(new TileWords { Id = Dictionary.Count, Word = NewWord.Word });
        }

        public void UpdateDictionary()
        {
            
        }
    }
}
