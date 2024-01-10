namespace StudentManager
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("修改密码");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("退出系统");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("个人中心", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("添加教师信息");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("修改教师信息");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("教师信息管理", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("开设课程");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("修改课程");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("开设课期");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("查询课期");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("课程管理", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("添加选课时间");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("修改选课时间");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("选课管理", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("录入成绩");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("统计成绩");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("修改成绩");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("学生成绩管理", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("添加学生信息");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("修改学生信息");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("新建培养方案");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("学生信息管理", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.LineColor = System.Drawing.Color.LightGray;
            this.treeView1.Location = new System.Drawing.Point(5, 17);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点0";
            treeNode1.Text = "修改密码";
            treeNode2.Name = "节点0";
            treeNode2.Text = "退出系统";
            treeNode3.Name = "userInfo";
            treeNode3.SelectedImageIndex = 2;
            treeNode3.Text = "个人中心";
            treeNode4.Name = "addMan";
            treeNode4.Text = "添加教师信息";
            treeNode5.Name = "modifyMan";
            treeNode5.Text = "修改教师信息";
            treeNode6.Name = "manMan";
            treeNode6.Text = "教师信息管理";
            treeNode7.Name = "addCL";
            treeNode7.Text = "开设课程";
            treeNode8.Name = "searchCL";
            treeNode8.Text = "修改课程";
            treeNode9.Name = "addCT";
            treeNode9.Text = "开设课期";
            treeNode10.Name = "searchCT";
            treeNode10.Text = "查询课期";
            treeNode11.Name = "classMan";
            treeNode11.Text = "课程管理";
            treeNode12.Name = "节点1";
            treeNode12.Text = "添加选课时间";
            treeNode13.Name = "节点2";
            treeNode13.Text = "修改选课时间";
            treeNode14.Name = "节点0";
            treeNode14.Text = "选课管理";
            treeNode15.Checked = true;
            treeNode15.Name = "luruCJ";
            treeNode15.NodeFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode15.Text = "录入成绩";
            treeNode16.Name = "tongjiCJ";
            treeNode16.Text = "统计成绩";
            treeNode17.Name = "节点0";
            treeNode17.Text = "修改成绩";
            treeNode18.Name = "chengjiMan";
            treeNode18.Text = "学生成绩管理";
            treeNode19.Name = "addStu";
            treeNode19.Text = "添加学生信息";
            treeNode20.Name = "modifyStu";
            treeNode20.Text = "修改学生信息";
            treeNode21.Name = "addarrangement";
            treeNode21.Text = "新建培养方案";
            treeNode22.Name = "studentMan";
            treeNode22.Text = "学生信息管理";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode11,
            treeNode14,
            treeNode18,
            treeNode22});
            this.treeView1.Size = new System.Drawing.Size(221, 649);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Location = new System.Drawing.Point(248, 17);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(987, 647);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 680);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.treeView1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学生综合教务系统-管理员";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_close);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel2;
    }
}

