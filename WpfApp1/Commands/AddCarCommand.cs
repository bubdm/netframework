using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Commands
{
    class AddCarCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return parameter != null && parameter is ObservableCollection<Inventory>;
        }
        public override void Execute(object parameter)
        {
            if (parameter is ObservableCollection<Inventory> cars)
            {
                var maxCount = cars?.Max(x => x.CarId) ?? 0;
                cars?.Add(new Inventory
                {
                    CarId = maxCount + 1,
                    Color = "Желтый",
                    Make = "ГАЗ",
                    PetName = "Телега",
                });
            }
        }
    }
}
