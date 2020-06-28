using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        private DataTable _table;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "sample",
            };
            _connection = new SqlConnection(connectionStringBuilder.ConnectionString);
            _adapter = new SqlDataAdapter();
            //select
            SqlCommand command = new SqlCommand("SELECT id,fam,name FROM Person", _connection);
            _adapter.SelectCommand = command;
            //insert
            //command = new SqlCommand(@"INSERT INTO Person (fam, name)
            //                                VALUES (@fam, @name); SET @id = @@IDENTITY;",_connection);
            //command.Parameters.Add("@fam", SqlDbType.NVarChar, -1, "fam");
            //command.Parameters.Add("@name", SqlDbType.NVarChar, -1, "name");
            //SqlParameter parameter = command.Parameters.Add("@id", SqlDbType.Int, 0, "id");
            //parameter.Direction = ParameterDirection.Output;
            //_adapter.InsertCommand = command;
            ////update
            //command = new SqlCommand(@"UPDATE Person SET fam = @fam,
            //                                                    name = @name
            //                                                    WHERE (id = @id)", _connection);
            //command.Parameters.Add("@fam", SqlDbType.NVarChar, -1, "fam");
            //command.Parameters.Add("@name", SqlDbType.NVarChar, -1, "name");
            //parameter = command.Parameters.Add("@id", SqlDbType.Int, 0, "id");
            //parameter.SourceVersion = DataRowVersion.Original;
            //_adapter.UpdateCommand = command;
            ////delete
            //command = new SqlCommand(@"DELETE FROM Person WHERE id = @id", _connection);
            //parameter = command.Parameters.Add("@id", SqlDbType.Int, 0, "id");
            //parameter.SourceVersion = DataRowVersion.Original;
            //_adapter.DeleteCommand = command;
            //set source
            _table = new DataTable();
            _adapter.Fill(_table);
            DataGridDataBase.DataContext = _table.DefaultView;
        }
        private void UpdateTable()
        {
            _table.Clear();
            _adapter.Fill(_table);
        }
        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            DataRow newRow = _table.NewRow();
            EditWindow editWindow = new EditWindow(newRow);
            editWindow.ShowDialog();
            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                _table.Rows.Add(newRow);
                var _ = new SqlCommandBuilder(_adapter);
                _adapter.Update(_table);
            }
            UpdateTable();
        }
        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            DataRowView editRow = (DataRowView)DataGridDataBase.SelectedItem;
            if (editRow == null)
                return;
            editRow.BeginEdit();
            EditWindow editWindow = new EditWindow(editRow.Row);
            editWindow.ShowDialog();
            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                editRow.EndEdit();
                var _ = new SqlCommandBuilder(_adapter);
                _adapter.Update(_table);
            }
            else
            {
                editRow.CancelEdit();
            }
            UpdateTable();
        }
        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            DataRowView delRow = (DataRowView)DataGridDataBase.SelectedItem;
            if (delRow == null)
                return;
            delRow.Row.Delete();
            var _ = new SqlCommandBuilder(_adapter);
            _adapter.Update(_table);
            UpdateTable();
        }
    }
}
