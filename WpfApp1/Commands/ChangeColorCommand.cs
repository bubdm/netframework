using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.Commands
{
    class ChangeColorCommand : ICommand
    {
        public bool CanExecute(object parameter) => (parameter as Inventory) != null;
        public void Execute(object parameter)
        {
            ((Inventory) parameter).Color = "Бурый";
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
