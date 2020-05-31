using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

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

        private bool isSpinning = false;
        private void ButtonSpinner_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (!isSpinning)
            {
                isSpinning = true;
                var doubleAnim = new DoubleAnimation();
                doubleAnim.Completed += (o, args) => isSpinning = false;
                doubleAnim.From = 0;
                doubleAnim.To = 360;
                doubleAnim.Duration = new Duration(TimeSpan.FromSeconds(10)); //время на анимацию - 10 секунд
                var rotate = new RotateTransform();
                buttonSpinner.RenderTransform = rotate;
                rotate.BeginAnimation(RotateTransform.AngleProperty, doubleAnim); //анимация вращения
            }
        }
        private void ButtonSpinner_OnClick(object sender, RoutedEventArgs e)
        {
            var doubleAnim = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
            };
            //doubleAnim.RepeatBehavior = RepeatBehavior.Forever; //бесконечно повторять
            doubleAnim.RepeatBehavior = new RepeatBehavior(3); //повторить три раза
            //doubleAnim.RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(30)); //повторять 30 секунд
            doubleAnim.AutoReverse = true; //после завершения - запустить в обратном порядке
            buttonSpinner.BeginAnimation(Button.OpacityProperty, doubleAnim); //становление кнопки невидимой
        }
    }
}
