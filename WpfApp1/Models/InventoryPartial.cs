using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public partial class Inventory : EntityBase, IDataErrorInfo
    {
        private string error;
        //индексатор валидации
        public string this[string columnName]
        {
            get
            {
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(CarId):
                        break;
                    case nameof(Make):
                        hasError = CheckMakeAndColor();
                        if (Make == "Чайка")
                        {
                            AddError(nameof(Make), "Слишком старый автомобиль");
                            hasError = true;
                        }
                        if (!hasError)
                        {
                            ClearErrors(nameof(Make));
                            ClearErrors(nameof(Color));
                        }
                        break;
                    case nameof(Color):
                        hasError = CheckMakeAndColor();
                        if (!hasError)
                        {
                            ClearErrors(nameof(Make));
                            ClearErrors(nameof(Color));
                        }
                        break;
                    case nameof(PetName):
                        break;
                }
                return string.Empty;
            }
        }
        private bool CheckMakeAndColor()
        {
            if (Make == "Копейка" && Color == "Беж")
            {
                AddError(nameof(Make), $"{Make} не может быть цвета {Color}");
                AddError(nameof(Color), $"{Make} не может быть цвета {Color}");
                return true;
            }
            return false;
        }
        public string Error => error;
    }
}
