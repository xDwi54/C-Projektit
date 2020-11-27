using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testui
{
    public partial class Form1 : Form
    {
        Dash dash;
        db dbformi;
        Form1 login;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            string server = textBox1.Text;
            string database = database_textbox.Text;
            string username = Username_textbox.Text;
            string password = password_textbox.Text;

            dbformi = new db();
            dbformi.svr = server;
            dbformi.dse = database;
            dbformi.usame = username;
            dbformi.pwd = password;

            MySqlConnection cnn;
            connetionString = "server=" + server + ";database=" + database + ";uid=" + username + ";pwd=" + password + ";";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
                

                string stm = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '"+database+"'; ";
                var cmd = new MySqlCommand(stm, cnn);

                var total = cmd.ExecuteScalar().ToString();
             

                //dashiin tietoa
                dash = new Dash();
                dash.svr = server;
                dash.dse = database;
                dash.usame = username;
                dash.pwd = password;
                dash.totalputa = total;
                this.Hide();
                dash.Closed += (s, args) => this.Close();
                dash.Show();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.Message.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            var form2 = new Dash();
            form2.Closed += (s, args) => this.Close();
            form2.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            var db = new db();
            db.Closed += (s, args) => this.Close();
            db.Show();
        }
    }
}
