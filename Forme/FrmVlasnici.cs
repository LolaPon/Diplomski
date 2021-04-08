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
            gridLjubimci.Columns["Vlasnik"].Visible = false;
            gridLjubimci.Columns["Zivotinja"].Visible = false;
            gridLjubimci.Columns["Pol"].Width = 50;
            gridLjubimci.Columns["Starost"].Width = 70;
            gridLjubimci.Columns["Status"].Width = 100;
            gridLjubimci.Columns["Boja"].Width = 70;

            int row = 0;
            foreach(Ljubimac lj in vlasnik.Ljubimci)
            {
                if (Equals(lj.Status, "Aktivan"))
                {
                    gridLjubimci[6, row].Style.BackColor = Color.Green;
                }
                else
                {
                    gridLjubimci[6, row].Style.BackColor = Color.Red;
                }

                row++;
            }


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

        private void btnIzmeniVlasnika_Click(object sender, EventArgs e)
        {
            txtIme.ReadOnly = false;
            txtPrezime.ReadOnly = false;
            txtTelefon.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtZanimanje.ReadOnly = false;
            txtNapomena.ReadOnly = false;
        }

        private void btnSacuvajVlasnika_Click(object sender, EventArgs e)
        {
           
            kontroler.sacuvajVlasnika(cmbVlasnici.SelectedItem as Vlasnik,cmbVlasnici ,txtIme, txtPrezime, txtTelefon, txtEmail, txtZanimanje, txtNapomena);
           
        }


        private void gridLjubimci_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (gridLjubimci.CurrentCell.ColumnIndex == 6)
            {
                if (gridLjubimci.CurrentCell.Style.BackColor == Color.Green)
                {
                    kontroler.promeniStatusLjubimca(gridLjubimci.CurrentRow, cmbVlasnici.SelectedItem as Vlasnik);
                    gridLjubimci.CurrentCell.Style.BackColor = Color.Red;
                    gridLjubimci.CurrentCell.Value = "Neaktivan";
                    
                }
                else
                {
                    kontroler.promeniStatusLjubimca(gridLjubimci.CurrentRow, cmbVlasnici.SelectedItem as Vlasnik);
                    gridLjubimci.CurrentCell.Style.BackColor = Color.Green;
                    gridLjubimci.CurrentCell.Value = "Aktivan";
                }
            }
        }
    }
}
