namespace ProjectUI
{
    partial class Financial_Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Financial_Report));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExpense = new System.Windows.Forms.Button();
            this.buttonIncome = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.buttonFinRep = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonExpense);
            this.panel1.Controls.Add(this.buttonIncome);
            this.panel1.Controls.Add(this.buttonHome);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 617);
            this.panel1.TabIndex = 8;
            // 
            // buttonExpense
            // 
            this.buttonExpense.FlatAppearance.BorderSize = 0;
            this.buttonExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpense.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExpense.ForeColor = System.Drawing.Color.White;
            this.buttonExpense.Image = ((System.Drawing.Image)(resources.GetObject("buttonExpense.Image")));
            this.buttonExpense.Location = new System.Drawing.Point(3, 412);
            this.buttonExpense.Name = "buttonExpense";
            this.buttonExpense.Size = new System.Drawing.Size(196, 110);
            this.buttonExpense.TabIndex = 6;
            this.buttonExpense.Text = "Expense";
            this.buttonExpense.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonExpense.UseVisualStyleBackColor = true;
            this.buttonExpense.Click += new System.EventHandler(this.buttonExpense_Click);
            // 
            // buttonIncome
            // 
            this.buttonIncome.FlatAppearance.BorderSize = 0;
            this.buttonIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIncome.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIncome.ForeColor = System.Drawing.Color.White;
            this.buttonIncome.Image = ((System.Drawing.Image)(resources.GetObject("buttonIncome.Image")));
            this.buttonIncome.Location = new System.Drawing.Point(3, 294);
            this.buttonIncome.Name = "buttonIncome";
            this.buttonIncome.Size = new System.Drawing.Size(196, 110);
            this.buttonIncome.TabIndex = 5;
            this.buttonIncome.Text = "Income";
            this.buttonIncome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonIncome.UseVisualStyleBackColor = true;
            this.buttonIncome.Click += new System.EventHandler(this.buttonIncome_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHome.ForeColor = System.Drawing.Color.White;
            this.buttonHome.Image = ((System.Drawing.Image)(resources.GetObject("buttonHome.Image")));
            this.buttonHome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonHome.Location = new System.Drawing.Point(3, 176);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(196, 110);
            this.buttonHome.TabIndex = 4;
            this.buttonHome.Text = "Home";
            this.buttonHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.button5);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 118);
            this.panel2.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(34, 9);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(136, 91);
            this.button5.TabIndex = 2;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(1032, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(125, 50);
            this.button7.TabIndex = 7;
            this.button7.Text = "Logout ";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(614, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 34);
            this.label1.TabIndex = 11;
            this.label1.Text = "Financial Report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(363, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 30);
            this.label2.TabIndex = 11;
            this.label2.Text = "From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(391, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 30);
            this.label3.TabIndex = 11;
            this.label3.Text = "To:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(441, 150);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(258, 30);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(441, 197);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(258, 30);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // buttonFinRep
            // 
            this.buttonFinRep.FlatAppearance.BorderSize = 0;
            this.buttonFinRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFinRep.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinRep.ForeColor = System.Drawing.Color.White;
            this.buttonFinRep.Image = ((System.Drawing.Image)(resources.GetObject("buttonFinRep.Image")));
            this.buttonFinRep.Location = new System.Drawing.Point(718, 133);
            this.buttonFinRep.Name = "buttonFinRep";
            this.buttonFinRep.Size = new System.Drawing.Size(196, 110);
            this.buttonFinRep.TabIndex = 3;
            this.buttonFinRep.Text = "Search";
            this.buttonFinRep.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonFinRep.UseVisualStyleBackColor = true;
            this.buttonFinRep.Click += new System.EventHandler(this.buttonFinRep_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelLeft.Location = new System.Drawing.Point(208, 176);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(10, 110);
            this.panelLeft.TabIndex = 15;
            this.panelLeft.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(441, 270);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(443, 299);
            this.dataGridView1.TabIndex = 10;
            // 
            // Financial_Report
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1169, 617);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.buttonFinRep);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Financial_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financial_Report";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExpense;
        private System.Windows.Forms.Button buttonIncome;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button buttonFinRep;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}