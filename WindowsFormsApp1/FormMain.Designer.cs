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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewPerson = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewChild = new System.Windows.Forms.DataGridView();
            this.buttonUpdateDatabase = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPersonId = new System.Windows.Forms.TextBox();
            this.buttonGetPersonInfo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxChildId = new System.Windows.Forms.TextBox();
            this.buttonChildInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChild)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Person";
            // 
            // dataGridViewPerson
            // 
            this.dataGridViewPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPerson.Location = new System.Drawing.Point(12, 36);
            this.dataGridViewPerson.Name = "dataGridViewPerson";
            this.dataGridViewPerson.Size = new System.Drawing.Size(579, 131);
            this.dataGridViewPerson.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Child";
            // 
            // dataGridViewChild
            // 
            this.dataGridViewChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChild.Location = new System.Drawing.Point(12, 209);
            this.dataGridViewChild.Name = "dataGridViewChild";
            this.dataGridViewChild.Size = new System.Drawing.Size(579, 131);
            this.dataGridViewChild.TabIndex = 1;
            // 
            // buttonUpdateDatabase
            // 
            this.buttonUpdateDatabase.Location = new System.Drawing.Point(388, 346);
            this.buttonUpdateDatabase.Name = "buttonUpdateDatabase";
            this.buttonUpdateDatabase.Size = new System.Drawing.Size(203, 29);
            this.buttonUpdateDatabase.TabIndex = 3;
            this.buttonUpdateDatabase.Text = "Отправка изменений в базу";
            this.buttonUpdateDatabase.UseVisualStyleBackColor = true;
            this.buttonUpdateDatabase.Click += new System.EventHandler(this.buttonUpdateDatabase_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Показ детской коллекции родителя";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Id";
            // 
            // textBoxPersonId
            // 
            this.textBoxPersonId.Location = new System.Drawing.Point(35, 374);
            this.textBoxPersonId.Name = "textBoxPersonId";
            this.textBoxPersonId.Size = new System.Drawing.Size(124, 20);
            this.textBoxPersonId.TabIndex = 6;
            // 
            // buttonGetPersonInfo
            // 
            this.buttonGetPersonInfo.Location = new System.Drawing.Point(165, 372);
            this.buttonGetPersonInfo.Name = "buttonGetPersonInfo";
            this.buttonGetPersonInfo.Size = new System.Drawing.Size(137, 23);
            this.buttonGetPersonInfo.TabIndex = 7;
            this.buttonGetPersonInfo.Text = "Показать";
            this.buttonGetPersonInfo.UseVisualStyleBackColor = true;
            this.buttonGetPersonInfo.Click += new System.EventHandler(this.buttonGetPersonInfo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 398);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Показ родителя ребенка";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Id";
            // 
            // textBoxChildId
            // 
            this.textBoxChildId.Location = new System.Drawing.Point(35, 417);
            this.textBoxChildId.Name = "textBoxChildId";
            this.textBoxChildId.Size = new System.Drawing.Size(124, 20);
            this.textBoxChildId.TabIndex = 10;
            // 
            // buttonChildInfo
            // 
            this.buttonChildInfo.Location = new System.Drawing.Point(165, 415);
            this.buttonChildInfo.Name = "buttonChildInfo";
            this.buttonChildInfo.Size = new System.Drawing.Size(137, 23);
            this.buttonChildInfo.TabIndex = 11;
            this.buttonChildInfo.Text = "Показать";
            this.buttonChildInfo.UseVisualStyleBackColor = true;
            this.buttonChildInfo.Click += new System.EventHandler(this.buttonChildInfo_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 449);
            this.Controls.Add(this.buttonChildInfo);
            this.Controls.Add(this.textBoxChildId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonGetPersonInfo);
            this.Controls.Add(this.textBoxPersonId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonUpdateDatabase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewChild);
            this.Controls.Add(this.dataGridViewPerson);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChild)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewPerson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewChild;
        private System.Windows.Forms.Button buttonUpdateDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPersonId;
        private System.Windows.Forms.Button buttonGetPersonInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxChildId;
        private System.Windows.Forms.Button buttonChildInfo;
    }
}

