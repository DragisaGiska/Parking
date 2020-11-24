using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingServis_27_4_2018
{
    public partial class FormRezervacija : Form
    {
        private string MjestoRezervacije="";
        public FormRezervacija(string mjesto)
        {
            InitializeComponent();
            this.Text = mjesto + "- Rezervacija";
            comboBoxTipVozila.SelectedIndex = 0;
            MjestoRezervacije = mjesto;
            new Rezervacija();
        }

        private void checkBoxVrijemeRezervacije_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVrijemeRezervacije.Checked)
            {
                tbVrijemeRezervacije.Clear();
                tbVrijemeRezervacije.Enabled = false;
            }
            else
                tbVrijemeRezervacije.Enabled = true;
        }

        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            try
            {
                provjeriUnos();
                provjeriVrijeme();
                Rezervacija.BrDokumenta = tbBrojDokumenta.Text;
                Rezervacija.NazivRezervacije = tbNazivRezervacije.Text;
                Rezervacija.TipVozila = comboBoxTipVozila.SelectedItem.ToString();
                Rezervacija.Mjesto = MjestoRezervacije;
                Rezervacija.Rezervisano = true;
                if (checkBoxVrijemeRezervacije.Checked)
                {
                    Rezervacija.VrijemeRezervacije = DateTime.Now;
                }
                else
                {
                    Rezervacija.VrijemeRezervacije = DateTime.Parse(tbVrijemeRezervacije.Text);
                }
                MessageBox.Show("Uspješno ste obavili rezervaciju.");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void provjeriUnos()
        {
            if (string.IsNullOrWhiteSpace(tbNazivRezervacije.Text) || string.IsNullOrWhiteSpace(tbBrojDokumenta.Text))
                throw new Exception("Ispravno popunite sva polja!");  
        }

        private void provjeriVrijeme()
        {
            if (!checkBoxVrijemeRezervacije.Checked)
            {
                DateTime dt;
                if (DateTime.TryParse(tbVrijemeRezervacije.Text, out dt))
                {
                    dt = DateTime.Parse(tbVrijemeRezervacije.Text);
                    if (dt < DateTime.Now)
                    {
                        throw new Exception("Ne možete rezervisati u vrijeme koje je već prošlo!");
                    }
                }
                else
                {
                    throw new Exception("Ispravan format za unos vremena je: HH:mm:ss");
                }
            }
            
        }

        private void FormRezervacija_Load(object sender, EventArgs e)
        {

        }
    }
}
