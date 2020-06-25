using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyClass myClass;
        public MainWindow()
        {
            InitializeComponent();
            myClass = new MyClass();
            GridMain.DataContext = myClass; //установка контекста
        }
        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            myClass.Flag = !myClass.Flag;
        }
        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            myClass.Ints.Add(99);
        }
        private void ButtonEditInts_OnClick(object sender, RoutedEventArgs e)
        {
            myClass.Ints[0]++;
        }
    }
}
