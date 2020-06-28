using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private DataRow _dataRow;
        public EditWindow(DataRow dataRow)
        {
            InitializeComponent();
            _dataRow = dataRow;
        }
        private void EditWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextBoxFam.Text = _dataRow["fam"].ToString();
            TextBoxName.Text = _dataRow["name"].ToString();
            ButtonOk.Click += delegate
            {
                _dataRow["fam"] = TextBoxFam.Text;
                _dataRow["name"] = TextBoxName.Text;
                DialogResult = true;
            };
            ButtonCancel.Click += delegate { DialogResult = false; };
        }
    }
}
