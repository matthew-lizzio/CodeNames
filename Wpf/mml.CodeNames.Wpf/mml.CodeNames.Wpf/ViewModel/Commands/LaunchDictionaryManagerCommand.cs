using mml.CodeNames.Wpf.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace mml.CodeNames.Wpf.ViewModel.Commands
{
    public class LaunchDictionaryManagerCommand : ICommand
    {
        public MainWindowVm Vm { get; set; }
        public LaunchDictionaryManagerCommand(MainWindowVm vm)
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
            var dmw = new DictionaryManagerWindow();
            dmw.ShowDialog();
        }
    }
}
