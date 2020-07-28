﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2DataDesigner
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sampleDataSet.Person". При необходимости она может быть перемещена или удалена.
            this.personTableAdapter.Fill(this.sampleDataSet.Person);
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.personTableAdapter.Update(this.sampleDataSet.Person);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.personTableAdapter.Fill(this.sampleDataSet.Person);
        }
    }
}
