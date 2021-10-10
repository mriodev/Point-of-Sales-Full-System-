using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;


namespace Dineth_s_POS
{
    public partial class Home : Form
    {

        public Home()
        {
            InitializeComponent();
          
        }
        

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Buy frm = new Buy();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Product frm = new Product();
            frm.MdiParent = this;
            frm.Show();
        }
        

        private void Home_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.ToolStripStatusLabel4.Text = datetime.ToString();
            
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup frm = new Backup();
            frm.MdiParent = this;
            frm.Show();

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Customer frm = new Customer();
            frm.MdiParent = this;
            frm.Show();

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            User frm = new User();
            frm.MdiParent = this;
            frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buy frm = new Buy();
        }

        private void bunifuFlatButton1_MouseHover(object sender, EventArgs e)
        {
       
        }

        private void bunifuFlatButton1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            BuyProductRecord frm = new BuyProductRecord();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }
    }
}
