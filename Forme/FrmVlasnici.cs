using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domen;

namespace Forme
{
    public partial class FrmVlasnici : Form
    {
        KontrolerKI kontroler = new KontrolerKI();
        List<Vlasnik> vlasnici = new List<Vlasnik>();
        Vlasnik vlasnik = new Vlasnik();
        public FrmVlasnici()
        {
            InitializeComponent();
        }

        private void FrmVlasnici_Load(object sender, EventArgs e)
        {
            vlasnici = kontroler.vratiSveVlasnike();

            if(vlasnici != null)
            {
                foreach (Vlasnik v in vlasnici)
                {
                    cmbVlasnici.Items.Add(v);
                }
            }
        }

        private void cmbVlasnici_SelectedIndexChanged(object sender, EventArgs e)
        {
            vlasnik = cmbVlasnici.SelectedItem as Vlasnik;
            txtIme.Text = vlasnik.Ime;
            txtPrezime.Text = vlasnik.Prezime;
            txtTelefon.Text = vlasnik.Telefon;
            txtEmail.Text = vlasnik.Email;
            txtZanimanje.Text = vlasnik.Zanimanje;
            txtNapomena.Text = vlasnik.Napomena;

            gridLjubimci.DataSource = vlasnik.Ljubimci;
            //gridLjubimci.Columns["Veterinar"].Visible = false;
            gridLjubimci.Columns["Vlasnik"].Visible = false;
            gridLjubimci.Columns["Zivotinja"].Visible = false;
        }

        private void btnObrisiLjub_Click(object sender, EventArgs e)
        {
            try
            {

                Ljubimac lj = gridLjubimci.CurrentRow.DataBoundItem as Ljubimac;
            
                vlasnik = cmbVlasnici.SelectedItem as Vlasnik;
                if (kontroler.obrisiLjubimcaIzListe(lj, vlasnik))
                {
                    kontroler.prikaziLjubimce(gridLjubimci, vlasnik);
                }
                //else { this.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }
    }
}
