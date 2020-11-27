using MySql.Data.MySqlClient;
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
    public partial class db : Form
    {
        public string svr { get; set; }
        public string dse { get; set; }
        public string usame { get; set; }
        public string pwd { get; set; }
        
        public db()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Dash();
            form2.Closed += (s, args) => this.Close();
            form2.Show();

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void load_con(object sender, EventArgs e)
        {
            string srver = svr;
            
            label8.Text = dse;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connetionString = null;
           
            if(svr == "")
            {
                MessageBox.Show("You are not connected to the database or you need to reconnect", "ALERT!");
            } else
            {
            MySqlConnection cnn;
            connetionString = "server=" + svr + ";database=" + dse + ";uid=" + usame + ";pwd=" + pwd + ";";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();


                string stm = richTextBox1.Text;
                var cmd = new MySqlCommand(stm, cnn);


                cmd.ExecuteReader();
                    MessageBox.Show("Your command was sent");



                }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.Message.ToString());
            }
            }

            
        }
    }
}
