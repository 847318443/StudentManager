﻿namespace StudentManager
{
    partial class modifystuForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxmajor = new System.Windows.Forms.ComboBox();
            this.comboBoxgrade = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxhometown = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxpname = new System.Windows.Forms.TextBox();
            this.textBoxpasswd = new System.Windows.Forms.TextBox();
            this.textBoxborn = new System.Windows.Forms.TextBox();
            this.textBoxname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_select = new System.Windows.Forms.Button();
            this.textBox_select_sno = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonnext = new System.Windows.Forms.Button();
            this.buttonlast = new System.Windows.Forms.Button();
            this.textBoxpage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView1.Location = new System.Drawing.Point(28, 17);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(892, 278);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.mos_click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(19, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(947, 317);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "学生信息";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxmajor);
            this.groupBox2.Controls.Add(this.comboBoxgrade);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBoxhometown);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxpname);
            this.groupBox2.Controls.Add(this.textBoxpasswd);
            this.groupBox2.Controls.Add(this.textBoxborn);
            this.groupBox2.Controls.Add(this.textBoxname);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(19, 392);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(947, 250);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "修改区";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // comboBoxmajor
            // 
            this.comboBoxmajor.FormattingEnabled = true;
            this.comboBoxmajor.Items.AddRange(new object[] {
            "计算机科学与技术",
            "软件工程",
            "信息安全",
            "物联网工程"});
            this.comboBoxmajor.Location = new System.Drawing.Point(535, 55);
            this.comboBoxmajor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxmajor.Name = "comboBoxmajor";
            this.comboBoxmajor.Size = new System.Drawing.Size(278, 23);
            this.comboBoxmajor.TabIndex = 42;
            // 
            // comboBoxgrade
            // 
            this.comboBoxgrade.FormattingEnabled = true;
            this.comboBoxgrade.Items.AddRange(new object[] {
            "大一",
            "大二",
            "大三",
            "大四"});
            this.comboBoxgrade.Location = new System.Drawing.Point(535, 92);
            this.comboBoxgrade.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxgrade.Name = "comboBoxgrade";
            this.comboBoxgrade.Size = new System.Drawing.Size(278, 23);
            this.comboBoxgrade.TabIndex = 41;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.Color.Black;
            this.radioButton2.Location = new System.Drawing.Point(628, 132);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(43, 19);
            this.radioButton2.TabIndex = 38;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "女";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.Color.Black;
            this.radioButton1.Location = new System.Drawing.Point(535, 132);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(43, 19);
            this.radioButton1.TabIndex = 37;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "男";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(478, 178);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 36;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(348, 178);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 35;
            this.button1.Text = "修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxhometown
            // 
            this.textBoxhometown.Location = new System.Drawing.Point(169, 130);
            this.textBoxhometown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxhometown.Name = "textBoxhometown";
            this.textBoxhometown.Size = new System.Drawing.Size(280, 25);
            this.textBoxhometown.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(121, 136);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 33;
            this.label8.Text = "籍贯";
            // 
            // textBoxpname
            // 
            this.textBoxpname.Location = new System.Drawing.Point(169, 17);
            this.textBoxpname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxpname.Name = "textBoxpname";
            this.textBoxpname.Size = new System.Drawing.Size(279, 25);
            this.textBoxpname.TabIndex = 32;
            // 
            // textBoxpasswd
            // 
            this.textBoxpasswd.Location = new System.Drawing.Point(169, 92);
            this.textBoxpasswd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxpasswd.Name = "textBoxpasswd";
            this.textBoxpasswd.Size = new System.Drawing.Size(279, 25);
            this.textBoxpasswd.TabIndex = 31;
            // 
            // textBoxborn
            // 
            this.textBoxborn.Location = new System.Drawing.Point(535, 17);
            this.textBoxborn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxborn.Name = "textBoxborn";
            this.textBoxborn.Size = new System.Drawing.Size(279, 25);
            this.textBoxborn.TabIndex = 29;
            // 
            // textBoxname
            // 
            this.textBoxname.Location = new System.Drawing.Point(169, 53);
            this.textBoxname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxname.Name = "textBoxname";
            this.textBoxname.Size = new System.Drawing.Size(280, 25);
            this.textBoxname.TabIndex = 27;
            this.textBoxname.TextChanged += new System.EventHandler(this.textBoxname_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(121, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 26;
            this.label7.Text = "学号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(119, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "密码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(488, 95);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "年级";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(489, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "专业";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(488, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "性别";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(456, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "出生日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(121, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "姓名";
            // 
            // button_select
            // 
            this.button_select.ForeColor = System.Drawing.Color.Black;
            this.button_select.Location = new System.Drawing.Point(460, 344);
            this.button_select.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(85, 25);
            this.button_select.TabIndex = 43;
            this.button_select.Text = "查询";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // textBox_select_sno
            // 
            this.textBox_select_sno.Location = new System.Drawing.Point(156, 344);
            this.textBox_select_sno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_select_sno.Name = "textBox_select_sno";
            this.textBox_select_sno.Size = new System.Drawing.Size(270, 25);
            this.textBox_select_sno.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(44, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 15);
            this.label10.TabIndex = 45;
            this.label10.Text = "要查询的学号";
            // 
            // buttonnext
            // 
            this.buttonnext.ForeColor = System.Drawing.Color.Black;
            this.buttonnext.Location = new System.Drawing.Point(792, 341);
            this.buttonnext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonnext.Name = "buttonnext";
            this.buttonnext.Size = new System.Drawing.Size(76, 26);
            this.buttonnext.TabIndex = 46;
            this.buttonnext.Text = "下一页";
            this.buttonnext.UseVisualStyleBackColor = true;
            this.buttonnext.Click += new System.EventHandler(this.buttonnext_Click);
            // 
            // buttonlast
            // 
            this.buttonlast.ForeColor = System.Drawing.Color.Black;
            this.buttonlast.Location = new System.Drawing.Point(596, 344);
            this.buttonlast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonlast.Name = "buttonlast";
            this.buttonlast.Size = new System.Drawing.Size(84, 26);
            this.buttonlast.TabIndex = 47;
            this.buttonlast.Text = "上一页";
            this.buttonlast.UseVisualStyleBackColor = true;
            this.buttonlast.Click += new System.EventHandler(this.buttonlast_Click);
            // 
            // textBoxpage
            // 
            this.textBoxpage.Location = new System.Drawing.Point(696, 343);
            this.textBoxpage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxpage.Name = "textBoxpage";
            this.textBoxpage.ReadOnly = true;
            this.textBoxpage.Size = new System.Drawing.Size(79, 25);
            this.textBoxpage.TabIndex = 48;
            this.textBoxpage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // modifystuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 665);
            this.Controls.Add(this.textBoxpage);
            this.Controls.Add(this.buttonlast);
            this.Controls.Add(this.buttonnext);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.textBox_select_sno);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "modifystuForm";
            this.Text = "修改学生信息";
            this.Load += new System.EventHandler(this.modifystuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxhometown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxpname;
        private System.Windows.Forms.TextBox textBoxpasswd;
        private System.Windows.Forms.TextBox textBoxborn;
        private System.Windows.Forms.TextBox textBoxname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxmajor;
        private System.Windows.Forms.ComboBox comboBoxgrade;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.TextBox textBox_select_sno;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonnext;
        private System.Windows.Forms.Button buttonlast;
        private System.Windows.Forms.TextBox textBoxpage;
    }
}