using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {
        List<Person> list;
        DataTable table;
        public FormMain()
        {
            InitializeComponent();
            list = new List<Person>
            {
                new Person {Id = 1, Fam = "Testin1", Name = "Test1", Age = 18},
                new Person {Id = 2, Fam = "Testin2", Name = "Test2", Age = 28},
                new Person {Id = 3, Fam = "Testin3", Name = "Test3", Age = 20},
                new Person {Id = 4, Fam = "Testin2", Name = "Test4", Age = 22},
                new Person {Id = 5, Fam = "Testin2", Name = "Test1", Age = 23},
                new Person {Id = 6, Fam = "Testin2", Name = "Test2", Age = 24},
                new Person {Id = 7, Fam = "Testin1", Name = "Test3", Age = 28},
                new Person {Id = 8, Fam = "Testin2", Name = "Test4", Age = 28},
            };
            table = CreateDataTable(list);
            dataGridViewPersons.DataSource = table;
        }
        private DataTable CreateDataTable(ICollection<Person> list)
        {
            var table = new DataTable();
            var IdColumn = new DataColumn("Id", typeof(int));
            var FamColumn = new DataColumn("Fam", typeof(string));
            var NameColumn = new DataColumn("Name", typeof(string));
            var AgeColumn = new DataColumn("Age", typeof(int));
            table.Columns.AddRange(new[] { IdColumn, FamColumn, NameColumn, AgeColumn });
            foreach (var el in list)
            {
                var newRow = table.NewRow();
                newRow["Id"] = el.Id;
                newRow["Fam"] = el.Fam;
                newRow["Name"] = el.Name;
                newRow["Age"] = el.Age;
                table.Rows.Add(newRow);
            }
            return table;
        }
        //удаление строки
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow rowToDelete = table.Select($"Id = {int.Parse(textBoxDeleteRowNumber.Text)}").First();
                rowToDelete.Delete();
                table.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //показ отфильтрованных и отсортированных данных
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            //фильтровать по фамилии и номерам ид больше трех
            string filterStr = $"Fam = '{textBoxFilterFam.Text}' AND Id > 3";
            //сортировать по имени в обратном порядке
            DataRow[] fams = table.Select(filterStr, "Name DESC");
            if (fams.Length == 0)
                MessageBox.Show("Строк с такими фамилиями не найдено!", "Фиговый результат");
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (var el in fams)
                    sb.AppendLine(el["Name"].ToString());
                MessageBox.Show($"Найдены {fams.Length} штук:\n" + sb.ToString(), "Результаты");
            }
        }
        //замена имени
        private void buttonReplaceName_Click(object sender, EventArgs e)
        {
            try
            {
                string filterStr = $"Name = '{textBoxReplaceNameFrom.Text}'";
                DataRow[] names = table.Select(filterStr);
                string strTo = textBoxReplaceNameTo.Text;
                foreach (var el in names)
                    el["Name"] = strTo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
    public class Person
    {
        public int Id { get; set; }
        public string Fam { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
