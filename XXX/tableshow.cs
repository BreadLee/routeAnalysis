using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XXX
{
    public partial class tableshow : Form
    {
        Form1 fm = new Form1();
        public tableshow(Form1 form1)
        {
            InitializeComponent();
            this.fm = form1;
        }

        private void tableshow_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fm.ResTable;            
        }

        private void 全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fm.LiTable;
            dataGridView1.Refresh();
        }

        private void 结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fm.ResTable;
            dataGridView1.Refresh();
        }
    }
}
