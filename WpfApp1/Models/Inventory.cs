using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class Inventory : INotifyPropertyChanged //наблюдаемая модель
    {
        private int carId;
        public int CarId
        {
            get => carId;
            set
            {
                if (value == carId) return;
                carId = value;
                //передача названия свойства значение которого изменилось
                OnPropertyChanged(nameof(CarId));
            }
        }
        private string make;
        public string Make
        {
            get => make;
            set
            {
                if (value == make) return;
                make = value;
                OnPropertyChanged(nameof(Make));
            }
        }
        private string color;
        public string Color
        {
            get => color;
            set
            {
                if (value == color) return;
                color = value;
                OnPropertyChanged(nameof(Color));
            }
        }
        private string petName;
        public string PetName
        {
            get => petName;
            set
            {
                if (value == petName) return;
                petName = value;
                OnPropertyChanged(nameof(PetName));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary> Вспомогательный метод индицирования события изменения свойства </summary>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            //индицирование события со строкой, указывающей свойство, которое было изменено и нуждается в обновлении
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //обновление всех привязанных свойств объекта
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }
    }
}
