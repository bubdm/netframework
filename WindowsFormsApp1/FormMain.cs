using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {
        private DataSet _dataSet = new DataSet("sample");
        private SqlDataAdapter _personAdapter;
        private SqlDataAdapter _childAdapter;
        private string _connectionString;
        public FormMain()
        {
            InitializeComponent();

            _connectionString = ConfigurationManager.ConnectionStrings["SampleProvider"].ConnectionString;
            _personAdapter = new SqlDataAdapter("SELECT * FROM Person", _connectionString);
            _childAdapter = new SqlDataAdapter("SELECT * FROM Child", _connectionString);
            var cbPerson = new SqlCommandBuilder(_personAdapter);
            var cbChild = new SqlCommandBuilder(_childAdapter);

            _personAdapter.Fill(_dataSet, "Person");
            _childAdapter.Fill(_dataSet, "Child");

            DataRelation relation = new DataRelation("PersonChild",
                _dataSet.Tables["Person"].Columns["Id"], 
                _dataSet.Tables["Child"].Columns["PersonId"]);
            _dataSet.Relations.Add(relation);

            dataGridViewPerson.DataSource = _dataSet.Tables["Person"];
            dataGridViewChild.DataSource = _dataSet.Tables["Child"];
        }
        private void buttonUpdateDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                _personAdapter.Update(_dataSet, "Person");
                _childAdapter.Update(_dataSet, "Child");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary> Инфа по родителю </summary>
        private void buttonGetPersonInfo_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int id = int.Parse(textBoxPersonId.Text);
            var person = _dataSet.Tables["Person"].Select($"Id = {id}").First();
            sb.AppendLine($"Person {person["Id"]} : {person["Fam"].ToString().Trim()} {person["Name"].ToString().Trim()}");

            var childs = person.GetChildRows(_dataSet.Relations["PersonChild"]);
            sb.AppendLine("Дети:");
            if (childs.Length == 0)
                sb.AppendLine("отсутствуют");
            else
                sb.AppendLine($"{childs.Length} шт.");
            foreach (var c in childs)
            {
                sb.AppendLine($"Child {c["Id"]} : {c["Fam"].ToString().Trim()} {c["Name"].ToString().Trim()}");
            }
            MessageBox.Show(sb.ToString(), "Информация по родителю");
        }
        /// <summary> Инфа по ребенку </summary>
        private void buttonChildInfo_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int id = int.Parse(textBoxChildId.Text);
            var child = _dataSet.Tables["Child"].Select($"Id = {id}").First();
            sb.AppendLine($"Child {child["Id"]} : {child["Fam"].ToString().Trim()} {child["Name"].ToString().Trim()}");

            var person = child.GetParentRow(_dataSet.Relations["PersonChild"]);
            sb.AppendLine("Родитель:");
            sb.AppendLine($"Person {person["Id"]} : {person["Fam"].ToString().Trim()} {person["Name"].ToString().Trim()}");

            MessageBox.Show(sb.ToString(), "Информация по ребенку");
        }
    }
}
