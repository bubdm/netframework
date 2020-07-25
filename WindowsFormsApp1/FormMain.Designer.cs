namespace WindowsFormsApp1
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewPersons = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDeleteRowNumber = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFilterFam = new System.Windows.Forms.TextBox();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxReplaceNameFrom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxReplaceNameTo = new System.Windows.Forms.TextBox();
            this.buttonReplaceName = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersons)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPersons
            // 
            this.dataGridViewPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPersons.Location = new System.Drawing.Point(12, 36);
            this.dataGridViewPersons.Name = "dataGridViewPersons";
            this.dataGridViewPersons.Size = new System.Drawing.Size(565, 193);
            this.dataGridViewPersons.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Работа с базой данных";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Номер удаляемой строки:";
            // 
            // textBoxDeleteRowNumber
            // 
            this.textBoxDeleteRowNumber.Location = new System.Drawing.Point(155, 240);
            this.textBoxDeleteRowNumber.Name = "textBoxDeleteRowNumber";
            this.textBoxDeleteRowNumber.Size = new System.Drawing.Size(137, 20);
            this.textBoxDeleteRowNumber.TabIndex = 3;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(298, 238);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(129, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Фильтрация по фамилиям:";
            // 
            // textBoxFilterFam
            // 
            this.textBoxFilterFam.Location = new System.Drawing.Point(155, 266);
            this.textBoxFilterFam.Name = "textBoxFilterFam";
            this.textBoxFilterFam.Size = new System.Drawing.Size(137, 20);
            this.textBoxFilterFam.TabIndex = 6;
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(298, 264);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(128, 23);
            this.buttonFilter.TabIndex = 7;
            this.buttonFilter.Text = "Отфильтровать";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Замена имен";
            // 
            // textBoxReplaceNameFrom
            // 
            this.textBoxReplaceNameFrom.Location = new System.Drawing.Point(90, 296);
            this.textBoxReplaceNameFrom.Name = "textBoxReplaceNameFrom";
            this.textBoxReplaceNameFrom.Size = new System.Drawing.Size(100, 20);
            this.textBoxReplaceNameFrom.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "на";
            // 
            // textBoxReplaceNameTo
            // 
            this.textBoxReplaceNameTo.Location = new System.Drawing.Point(222, 296);
            this.textBoxReplaceNameTo.Name = "textBoxReplaceNameTo";
            this.textBoxReplaceNameTo.Size = new System.Drawing.Size(100, 20);
            this.textBoxReplaceNameTo.TabIndex = 11;
            // 
            // buttonReplaceName
            // 
            this.buttonReplaceName.Location = new System.Drawing.Point(329, 293);
            this.buttonReplaceName.Name = "buttonReplaceName";
            this.buttonReplaceName.Size = new System.Drawing.Size(97, 23);
            this.buttonReplaceName.TabIndex = 12;
            this.buttonReplaceName.Text = "Заменить";
            this.buttonReplaceName.UseVisualStyleBackColor = true;
            this.buttonReplaceName.Click += new System.EventHandler(this.buttonReplaceName_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 522);
            this.Controls.Add(this.buttonReplaceName);
            this.Controls.Add(this.textBoxReplaceNameTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxReplaceNameFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.textBoxFilterFam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.textBoxDeleteRowNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewPersons);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPersons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDeleteRowNumber;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFilterFam;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxReplaceNameFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxReplaceNameTo;
        private System.Windows.Forms.Button buttonReplaceName;
    }
}

