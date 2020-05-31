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
            listStyles.Items.Add("ButtonStyle1");
            listStyles.Items.Add("ButtonStyle2");
            listStyles.Items.Add("ButtonStyle3");
        }
        private void ListStyles_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentStyle = (Style) TryFindResource(listStyles.SelectedValue);
            if (currentStyle == null)
                return;
            buttonStyle.Style = currentStyle;
        }
    }
}
