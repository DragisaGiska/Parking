using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingServis_27_4_2018
{
    public partial class Form1 : Form
    {
        private Button ActiveButton = null;
        private int BrSlobodnihMjesta = 14;

        public Form1()
        {
            InitializeComponent();
            labelDateTime.Text = DateTime.Now.ToString("HH:mm    dd//MM/yyyy");
            tbBrSlobodnihMjesta.Text = BrSlobodnihMjesta.ToString();
        }

    

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelDateTime.Text = DateTime.Now.ToString("HH:mm    dd//MM/yyyy");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ekspotAktrinvostiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text document (*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sWriter = null;
                try
                {
                    sWriter = new StreamWriter(sfd.FileName);
                    sWriter.Write(rtbAktivnosti.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (sWriter != null)
                        sWriter.Close();
                }
            }
        }

        private void cmsPadajuciMeni_Opening(object sender, CancelEventArgs e)
        {
            if (ActiveButton.BackColor == Color.Red)
            {
                rezervišiToolStripMenuItem.Enabled = false;
                naplatiToolStripMenuItem.Enabled = true;
            }
            else
            {
                rezervišiToolStripMenuItem.Enabled = true;
                naplatiToolStripMenuItem.Enabled =false;
            }
        }

        private void btnMjesto_MouseDown(object sender, MouseEventArgs e)
        {
            Button b=(Button)sender;
            if (e.Button == MouseButtons.Right)
            {
                foreach (Button btn in tableLPParking.Controls)
                {
                    if (b == btn)
                    {
                        ActiveButton = b;
                        break;
                    }
                }
            }
        }

        private void rezervišiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRezervacija fRezervacija = new FormRezervacija("M"+ActiveButton.Text);
            fRezervacija.FormClosed += (s, args) => { generisiAktivnostDolazak(); this.Enabled = true; };
            fRezervacija.Show();
            this.Enabled = false;

        }



        private void generisiAktivnostDolazak()
        {
            if (Rezervacija.Rezervisano)
            {
                rtbAktivnosti.Text += Rezervacija.Ispis();
                ActiveButton.BackColor = Color.Red;
                BrSlobodnihMjesta--;
                tbBrSlobodnihMjesta.Text = BrSlobodnihMjesta.ToString();
            }
        }

        private void naplatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbAktivnosti.Text += "M" + ActiveButton.Text + "- Odlazak"+Environment.NewLine+"Vrijeme: "+DateTime.Now.ToString("HH:mm:ss")+Environment.NewLine+Environment.NewLine; 
            ActiveButton.BackColor = Color.Green;
            BrSlobodnihMjesta++;
            tbBrSlobodnihMjesta.Text = BrSlobodnihMjesta.ToString();
        }

        private void rtbAktivnosti_TextChanged(object sender, EventArgs e)
        {
            rtbAktivnosti.SelectionStart = rtbAktivnosti.Text.Length;//Auto skrolovanje
            rtbAktivnosti.ScrollToCaret();//Auto skrolovanje!!!!!!!!!!!!!!!!!!!!!

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
 }

