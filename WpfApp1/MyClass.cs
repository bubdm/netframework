using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Annotations;

namespace WpfApp1
{
    class MyClass : INotifyPropertyChanged
    {
        private bool flag;
        public bool Flag
        {
            get => flag;
            set
            {
                if (flag == value) return;
                flag = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Flag)));
            }
        }
        public ObservableCollection<int> Ints { get; set; }

        public MyClass()
        {
            flag = true;
            Ints = new ObservableCollection<int> {1, 2, 4, 8, 9};
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
