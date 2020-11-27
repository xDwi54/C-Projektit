using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testui
{
    
    public partial class Dash : Form
    {
        public string totalputa { get; set; }
        public string svr { get; set; }
        public string dse { get; set; }
        public string usame { get; set; }
        public string pwd { get; set; }
        db dbformi;
        public Dash()
        {
            InitializeComponent();
        }

        private void load(object sender, EventArgs e)
        {
            label7.Text = totalputa;
            
            dbformi = new db();
            dbformi.svr = svr;
            dbformi.dse = dse;
            dbformi.usame = usame;
            dbformi.pwd = pwd;
            label9.Text = usame;
            label8.Text = dse;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            MessageBox.Show(svr);
            
        
            this.Hide();
            var db = new db();
            db.svr = svr;
            db.dse = dse;
            db.usame = usame;
            db.pwd = pwd;
            db.Closed += (s, args) => this.Close();
            db.Show();
        }
    }
}
