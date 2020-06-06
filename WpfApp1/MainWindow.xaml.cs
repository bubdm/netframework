using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using Microsoft.Win32;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly IList<Inventory> cars = new ObservableCollection<Inventory>(); //наблюдаемая коллекция
        public MainWindow()
        {
            InitializeComponent();
            cars.Add(new Inventory
            {
                CarId = 1,
                Make = "УАЗ",
                Color = "Белый",
                PetName = "Буханка",
                IsChanged = false,
            });
            cars.Add(new Inventory
            {
                CarId = 2,
                Make = "ЗАЗ",
                Color = "Коричневый",
                PetName = "Большая",
                IsChanged = false,
            });
            comboBoxCars.ItemsSource = cars;
        }

        private void ButtonChangeColor_OnClick(object sender, RoutedEventArgs e)
        {
            cars.First(x => x.CarId == ((Inventory) comboBoxCars.SelectedItem)?.CarId).Color = "Pink";
        }

        private void buttonAddCar_Click(object sender, RoutedEventArgs e)
        {
            var maxCount = cars?.Max(x => x.CarId) ?? 0;
            cars.Add(new Inventory
            {
                CarId = maxCount + 1,
                Color = "Желтый",
                Make = "ВАЗ",
                PetName = "Копейка",
            });
        }
    }
}
