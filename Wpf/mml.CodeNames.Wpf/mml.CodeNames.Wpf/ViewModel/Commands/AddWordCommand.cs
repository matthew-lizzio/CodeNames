using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace mml.CodeNames.Wpf.ViewModel.Commands
{
    public class AddWordCommand : ICommand
    {
        public DictionaryManagerWindowVm Vm { get; set; }
        public AddWordCommand(DictionaryManagerWindowVm vm)
        {
            Vm = vm;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Vm.AddWord();
        }
    }
}
