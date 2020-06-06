using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Xps.Packaging;
using Microsoft.Win32;
using WpfApp1.Commands;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly IList<Inventory> cars = new ObservableCollection<Inventory>(); //
        
        public MainWindow()
        {
            InitializeComponent();
            cars.Add(new Inventory
            {
                CarId = 1,
                Make = "УАЗ",
                Color = "Белый",
                PetName = "Буханка",
            });
            cars.Add(new Inventory
            {
                CarId = 2,
                Make = "ЗАЗ",
                Color = "Коричневый",
                PetName = "Большая"
            });
            comboBoxCars.ItemsSource = cars;
        }
        //поддерживающее поле команды
        private ICommand changeColorCommand = null;
        public ICommand ChangeColorCommand => changeColorCommand ?? (changeColorCommand = new ChangeColorCommand());

        private ICommand addCarCommand = null;
        public ICommand AddCarCommand => addCarCommand ?? (addCarCommand = new AddCarCommand());

        private RelayCommand<Inventory> deleteCarCommand = null;
        public RelayCommand<Inventory> DeleteCarCommand => deleteCarCommand ?? (deleteCarCommand = new RelayCommand<Inventory>(DeleteCar, CanDeleteCar));
        private bool CanDeleteCar(Inventory car) => car != null;
        private void DeleteCar(Inventory car)
        {
            this.cars.Remove(car);
        }
    }
}
