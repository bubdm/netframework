using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            //создать форматированный текст
            FormattedText text = new FormattedText("Визуализация", new CultureInfo("ru-ru"),FlowDirection.LeftToRight,new Typeface(this.FontFamily,FontStyles.Italic,FontWeights.DemiBold,FontStretches.UltraExpanded),30,Brushes.DarkGreen,null,VisualTreeHelper.GetDpi(this).PixelsPerDip);
            //создать контекст визуализации
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                //методы DrawingContext для визуализации данных
                drawingContext.DrawRoundedRectangle(Brushes.Yellow, new Pen(Brushes.Black, 5), new Rect(5,5,400,100), 20, 20);
                drawingContext.DrawText(text, new Point(20,20));
            }
            //битовое изображение из визуального контекста
            RenderTargetBitmap bitmap = new RenderTargetBitmap(500,300,100,100,PixelFormats.Pbgra32);
            bitmap.Render(drawingVisual);
            myImage.Source = bitmap;
        }
    }
}
