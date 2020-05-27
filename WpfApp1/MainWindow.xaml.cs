using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Xps.Packaging;
using Microsoft.Win32;

namespace WpfApp1
{
    class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToInt32((double)value) * 10; //конвертирование значения
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value; //однонаправленная привязка
        }
    }
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            inkRadio.IsChecked = true;
            this.comboColors.SelectedIndex = 0;

            Binding b = new Binding
            {
                Converter = new MyConverter(),
                Source = myScrollBar,
                Path = new PropertyPath("Value"),
            };
            labelThumb.SetBinding(Label.ContentProperty, b);
            buttonOK.SetBinding(Button.FontSizeProperty, b);
            //Binding binding = new Binding
            //{
            //    ElementName = "myScrollBar",
            //    Path = new PropertyPath("Value"),
            //};
            //labelThumb.SetBinding(Label.ContentProperty, binding);
            //Binding binding = new Binding();
            //binding.ElementName="textBoxValue";
            //binding.Path=new PropertyPath("Text");
            //textBlockInValue.SetBinding(TextBlock.TextProperty, binding);
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton)?.Name)
            {
                case "inkRadio":
                    myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "eraseRadio":
                    myInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                case "selectRadio":
                    myInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
            }
        }
        private void comboColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string color = (comboColors.SelectedItem as StackPanel)?.Tag.ToString();
            myInkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(color);
        }
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream stream = new FileStream("Stroke.bin",FileMode.Create,FileAccess.Write))
            {
                myInkCanvas.Strokes.Save(stream);
            }
        }
        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream stream = new FileStream("Stroke.bin",FileMode.Open,FileAccess.Read))
            {
                var strokes = new StrokeCollection(stream);
                myInkCanvas.Strokes = strokes;
            }
        }
        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            myInkCanvas.Strokes.Clear();
        }
    }
}
