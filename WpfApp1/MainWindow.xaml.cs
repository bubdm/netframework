using System.Windows;
using System.Windows.Media;

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
        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            //var brush = (RadialGradientBrush)Resources["myBrush"];
            var brush = (RadialGradientBrush)TryFindResource("myBrush");
            if (brush == null)
                return;
            brush.GradientStops[0] = new GradientStop(Colors.Black, 0.5); //это сработает
        }
        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Resources["myBrush"] = new SolidColorBrush(Colors.Green); //а это не сработает
        }
    }
}
