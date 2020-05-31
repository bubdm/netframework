using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Xps.Packaging;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<BitmapImage> images = new List<BitmapImage>();
        private int currentImage = 0;
        public MainWindow()
        {
            InitializeComponent();

        }
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //string path = Environment.CurrentDirectory;
                //загрузка изображений из файлов
                //images.Add(new BitmapImage(new Uri($@"{path}\ma0.jpg")));
                //images.Add(new BitmapImage(new Uri($@"{path}\Images\ma1.jpg")));
                //images.Add(new BitmapImage(new Uri($@"{path}\Images\ma2.jpg")));
                //извлечь из сборки и затем загрузить изображения
                images.Add(new BitmapImage(new Uri($@"Images/ma0.jpg",UriKind.Relative)));
                images.Add(new BitmapImage(new Uri($@"Images/ma1.jpg",UriKind.Relative)));
                images.Add(new BitmapImage(new Uri($@"Images/ma2.jpg",UriKind.Relative)));
                imageHolder.Source = images[currentImage]; //первое изображение в списке
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ButtonPreviousImage_OnClick(object sender, RoutedEventArgs e)
        {
            if (--currentImage < 0)
                currentImage = images.Count - 1;
            imageHolder.Source = images[currentImage];
        }
        private void ButtonNextImage_OnClick(object sender, RoutedEventArgs e)
        {
            if (++currentImage >= images.Count)
                currentImage = 0;
            imageHolder.Source = images[currentImage];
        }
    }
}
