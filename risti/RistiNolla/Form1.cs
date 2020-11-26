using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RistiNolla
{
    public partial class Form1 : Form
    {

        bool turn = true;
        int turn_count = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
        try
            {
                Button b = (Button)sender;
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";

                turn = !turn;
                b.Enabled = false;
                turn_count++;
                checkforwinner();
            }
            catch
            {

            }

        }

        private void checkforwinner()
        {
            bool thereisawinner = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                thereisawinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                thereisawinner = true;
           else if((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                thereisawinner = true;

           else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                thereisawinner = true;
           else if((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                thereisawinner = true;
           else if((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                thereisawinner = true;
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                thereisawinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                thereisawinner = true;



            

            if (thereisawinner)
            {

                
                disablebuttons();
                string winner = "";
                if (turn)
                {
                    winner = "O";
                    owins.Text = (Int32.Parse(owins.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    xwins.Text = (Int32.Parse(xwins.Text) + 1).ToString();

                }
                MessageBox.Show(winner + " Wins");
            } else
            {
                if (turn_count == 9)
                {
                    MessageBox.Show(" Tied");
                    ties.Text = (Int32.Parse(ties.Text) + 1).ToString();

                }
            }


        }

        private void disablebuttons()
        {
            foreach(Control c in Controls)
            {
               try
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
                catch {
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tehnyt: Anssi", "Ristinolla");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch
                {
                }
            }
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }

        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void resetScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            owins.Text = "0";
            xwins.Text = "0";
            ties.Text = "0";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
