using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.Commands
{
    class ChangeColorCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return (parameter as Inventory) != null;
        }

        public override void Execute(object parameter)
        {
            ((Inventory) parameter).Color = "Бурый";
        }
    }
}
