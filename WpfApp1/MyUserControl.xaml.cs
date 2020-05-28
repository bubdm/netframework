using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для UserControl.xaml
    /// </summary>
    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }
        private int currentNumber = 0;
        public int CurrentNumber
        {
            get => (int)GetValue(CurrentNumberProperty);
            set => SetValue(CurrentNumberProperty, value);
        }
        public static readonly DependencyProperty CurrentNumberProperty =
            DependencyProperty.Register("MyProperty", typeof(int), typeof(MyUserControl), new UIPropertyMetadata(0));


        //public int CurrentNumber
        //{
        //    get => currentNumber;
        //    set
        //    {
        //        currentNumber = value;
        //        numberDisplay.Content = currentNumber.ToString();
        //    }
        //}
    }
}
