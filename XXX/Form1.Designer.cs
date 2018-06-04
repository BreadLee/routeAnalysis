namespace XXX
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axMap1 = new AxMapWinGIS.AxMap();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全幅ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.漫游ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.路线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选取起终点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选取终点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.驾车导航ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选取起点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选取终点ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lineShow = new System.Windows.Forms.Button();
            this.LineName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.BusCommandText = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CommandT = new System.Windows.Forms.TabPage();
            this.AllT = new System.Windows.Forms.TabPage();
            this.BusAllText = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axMap1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.CommandT.SuspendLayout();
            this.AllT.SuspendLayout();
            this.SuspendLayout();
            // 
            // axMap1
            // 
            this.axMap1.Enabled = true;
            this.axMap1.Location = new System.Drawing.Point(11, 40);
            this.axMap1.Margin = new System.Windows.Forms.Padding(2);
            this.axMap1.Name = "axMap1";
            this.axMap1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMap1.OcxState")));
            this.axMap1.Size = new System.Drawing.Size(712, 485);
            this.axMap1.TabIndex = 0;
            this.axMap1.MouseDownEvent += new AxMapWinGIS._DMapEvents_MouseDownEventHandler(this.axMap1_MouseDownEvent);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.操作ToolStripMenuItem,
            this.路线ToolStripMenuItem,
            this.驾车导航ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1125, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.放大ToolStripMenuItem,
            this.缩小ToolStripMenuItem,
            this.全幅ToolStripMenuItem,
            this.漫游ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.操作ToolStripMenuItem.Text = "图幅操作";
            // 
            // 放大ToolStripMenuItem
            // 
            this.放大ToolStripMenuItem.Name = "放大ToolStripMenuItem";
            this.放大ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.放大ToolStripMenuItem.Text = "放大";
            this.放大ToolStripMenuItem.Click += new System.EventHandler(this.放大ToolStripMenuItem_Click);
            // 
            // 缩小ToolStripMenuItem
            // 
            this.缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            this.缩小ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.缩小ToolStripMenuItem.Text = "缩小";
            this.缩小ToolStripMenuItem.Click += new System.EventHandler(this.缩小ToolStripMenuItem_Click);
            // 
            // 全幅ToolStripMenuItem
            // 
            this.全幅ToolStripMenuItem.Name = "全幅ToolStripMenuItem";
            this.全幅ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.全幅ToolStripMenuItem.Text = "全幅";
            this.全幅ToolStripMenuItem.Click += new System.EventHandler(this.全幅ToolStripMenuItem_Click);
            // 
            // 漫游ToolStripMenuItem
            // 
            this.漫游ToolStripMenuItem.Name = "漫游ToolStripMenuItem";
            this.漫游ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.漫游ToolStripMenuItem.Text = "漫游";
            this.漫游ToolStripMenuItem.Click += new System.EventHandler(this.漫游ToolStripMenuItem_Click);
            // 
            // 路线ToolStripMenuItem
            // 
            this.路线ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选取起终点ToolStripMenuItem,
            this.选取终点ToolStripMenuItem});
            this.路线ToolStripMenuItem.Name = "路线ToolStripMenuItem";
            this.路线ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.路线ToolStripMenuItem.Text = "公交导航";
            // 
            // 选取起终点ToolStripMenuItem
            // 
            this.选取起终点ToolStripMenuItem.Name = "选取起终点ToolStripMenuItem";
            this.选取起终点ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.选取起终点ToolStripMenuItem.Text = "选取起点";
            this.选取起终点ToolStripMenuItem.Click += new System.EventHandler(this.选取起终点ToolStripMenuItem_Click);
            // 
            // 选取终点ToolStripMenuItem
            // 
            this.选取终点ToolStripMenuItem.Name = "选取终点ToolStripMenuItem";
            this.选取终点ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.选取终点ToolStripMenuItem.Text = "选取终点";
            this.选取终点ToolStripMenuItem.Click += new System.EventHandler(this.选取终点ToolStripMenuItem_Click);
            // 
            // 驾车导航ToolStripMenuItem
            // 
            this.驾车导航ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选取起点ToolStripMenuItem,
            this.选取终点ToolStripMenuItem1});
            this.驾车导航ToolStripMenuItem.Name = "驾车导航ToolStripMenuItem";
            this.驾车导航ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.驾车导航ToolStripMenuItem.Text = "驾车导航";
            // 
            // 选取起点ToolStripMenuItem
            // 
            this.选取起点ToolStripMenuItem.Name = "选取起点ToolStripMenuItem";
            this.选取起点ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.选取起点ToolStripMenuItem.Text = "选取起点";
            this.选取起点ToolStripMenuItem.Click += new System.EventHandler(this.选取起点ToolStripMenuItem_Click);
            // 
            // 选取终点ToolStripMenuItem1
            // 
            this.选取终点ToolStripMenuItem1.Name = "选取终点ToolStripMenuItem1";
            this.选取终点ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.选取终点ToolStripMenuItem1.Text = "选取终点";
            this.选取终点ToolStripMenuItem1.Click += new System.EventHandler(this.选取终点ToolStripMenuItem1_Click);
            // 
            // lineShow
            // 
            this.lineShow.Location = new System.Drawing.Point(948, 45);
            this.lineShow.Name = "lineShow";
            this.lineShow.Size = new System.Drawing.Size(75, 23);
            this.lineShow.TabIndex = 5;
            this.lineShow.Text = "路线显示";
            this.lineShow.UseVisualStyleBackColor = true;
            this.lineShow.Click += new System.EventHandler(this.lineShow_Click);
            // 
            // LineName
            // 
            this.LineName.Location = new System.Drawing.Point(842, 44);
            this.LineName.Name = "LineName";
            this.LineName.Size = new System.Drawing.Size(100, 21);
            this.LineName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(726, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "起点";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(726, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "终点";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(981, 71);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(91, 20);
            this.Search.TabIndex = 12;
            this.Search.Text = "查询公交路线";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // BusCommandText
            // 
            this.BusCommandText.Location = new System.Drawing.Point(-4, -5);
            this.BusCommandText.Name = "BusCommandText";
            this.BusCommandText.Size = new System.Drawing.Size(308, 326);
            this.BusCommandText.TabIndex = 13;
            this.BusCommandText.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.CommandT);
            this.tabControl1.Controls.Add(this.AllT);
            this.tabControl1.Location = new System.Drawing.Point(728, 147);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(312, 343);
            this.tabControl1.TabIndex = 15;
            // 
            // CommandT
            // 
            this.CommandT.Controls.Add(this.BusCommandText);
            this.CommandT.Location = new System.Drawing.Point(4, 22);
            this.CommandT.Name = "CommandT";
            this.CommandT.Padding = new System.Windows.Forms.Padding(3);
            this.CommandT.Size = new System.Drawing.Size(304, 317);
            this.CommandT.TabIndex = 0;
            this.CommandT.Text = "推荐路线";
            this.CommandT.UseVisualStyleBackColor = true;
            // 
            // AllT
            // 
            this.AllT.Controls.Add(this.BusAllText);
            this.AllT.Location = new System.Drawing.Point(4, 22);
            this.AllT.Name = "AllT";
            this.AllT.Padding = new System.Windows.Forms.Padding(3);
            this.AllT.Size = new System.Drawing.Size(304, 317);
            this.AllT.TabIndex = 1;
            this.AllT.Text = "全部路线";
            this.AllT.UseVisualStyleBackColor = true;
            // 
            // BusAllText
            // 
            this.BusAllText.Location = new System.Drawing.Point(-4, -9);
            this.BusAllText.Name = "BusAllText";
            this.BusAllText.Size = new System.Drawing.Size(308, 330);
            this.BusAllText.TabIndex = 16;
            this.BusAllText.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(771, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "公交线路名";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(765, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(210, 20);
            this.comboBox1.TabIndex = 17;
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(765, 98);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(210, 20);
            this.comboBox2.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(981, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 29);
            this.button1.TabIndex = 19;
            this.button1.Text = "清除路线";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(981, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 20);
            this.button2.TabIndex = 20;
            this.button2.Text = "查询驾车路线";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 535);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LineName);
            this.Controls.Add(this.lineShow);
            this.Controls.Add(this.axMap1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axMap1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.CommandT.ResumeLayout(false);
            this.AllT.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxMapWinGIS.AxMap axMap1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全幅ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 漫游ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 路线ToolStripMenuItem;
        private System.Windows.Forms.Button lineShow;
        private System.Windows.Forms.TextBox LineName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.RichTextBox BusCommandText;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CommandT;
        private System.Windows.Forms.TabPage AllT;
        private System.Windows.Forms.RichTextBox BusAllText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem 选取起终点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选取终点ToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem 驾车导航ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选取起点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选取终点ToolStripMenuItem1;
    }
}

