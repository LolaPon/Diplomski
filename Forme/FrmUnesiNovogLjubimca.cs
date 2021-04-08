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
    public partial class FrmUnesiNovogLjubimca : Form
    {
        KontrolerKI kontroler = new KontrolerKI();
        Ljubimac lj = new Ljubimac();
        string pol = "";
        bool odgovor = false;
        Vlasnik vlasnik = new Vlasnik();

        public FrmUnesiNovogLjubimca()
        {
            InitializeComponent();
        }

        public FrmUnesiNovogLjubimca(Ljubimac ljubimac)
        {
            lj = ljubimac;
            InitializeComponent();
            this.Text = "Ljubimac " + ljubimac.Ime; 
            btnKreirajIDLj.Enabled = false;
            gbLjubimac.Enabled = true;
            gbVlasnik.Enabled = false;
            txtIDljub.Enabled = false;
            btnSacuvajLj.Text = "Izmeni Ljubimca";
            btnSacuvajLj.Enabled = true;

            
        }


        private void btnSacuvajLj_Click(object sender, EventArgs e)
        {
            if (rbMuski.Checked == true)
                pol = "M";
            if (rbZenski.Checked == true)
                pol = "Z";

            if (btnSacuvajLj.Text == "Izmeni Ljubimca")
            {
                try
                {
                    if (kontroler.IzmeniLjubimca(txtIDljub, txtImeLjubimca, cmbZivotinje, txtRasa, txtStarost, txtBoja, pol,txtID ,txtJmbg,txtIme, txtPrezime, txtEmail, txtTelefon, txtZanimanje,txtNapomena ,odgovor))
                    {
                        MessageBox.Show("Uspešno ste izmenili ljubimca!");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            else
            {

                if (kontroler.sacuvajLjubimca(txtImeLjubimca, cmbZivotinje, txtRasa, txtStarost, txtBoja, pol, txtIme, txtPrezime, txtEmail, txtJmbg, lj.Id , txtID, txtZanimanje, txtTelefon))
                {
                    this.Close();
                }
            }
            
        }

        private void FrmUnesiNovogLjubimca_Load(object sender, EventArgs e)
        {
            List<Zivotinja> zivotinje = Sesija.Broker.vratiKonekciju().vratiZivotinje();
            
            foreach (Zivotinja z in zivotinje)
            {
                cmbZivotinje.Items.Add(z);
            }


            if (btnSacuvajLj.Text == "Izmeni Ljubimca")
            {
                kontroler.popuniFormu(txtImeLjubimca, cmbZivotinje, txtRasa, txtStarost, txtBoja, rbMuski , rbZenski, txtIDljub, btnSacuvajLj, lj, txtID, txtJmbg, txtIme, txtPrezime, txtEmail,txtTelefon,txtZanimanje,txtNapomena);
                if (MessageBox.Show("Da li želite da izmenite i podatke o vlasniku?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    gbVlasnik.Enabled = true;
                    odgovor = true;
                    
                }
            }
        }

        private void btnKreirajIDLj_Click(object sender, EventArgs e)
        {
            gbLjubimac.Enabled = true;
            gbVlasnik.Enabled = true;
            btnSacuvajLj.Enabled = true;

           if(kontroler.kreirajLjubimca(txtIDljub, btnKreirajIDLj) != null)
            {
                lj = kontroler.kreirajLjubimca(txtIDljub, btnKreirajIDLj);
            }
        }

        private void txtJmbg_Leave(object sender, EventArgs e)
        {
            vlasnik.Jmbg = txtJmbg.Text;
            vlasnik = kontroler.proveriVlasnika(vlasnik);
            if (vlasnik != null)
            {
                txtID.Text = vlasnik.Id.ToString();
                txtIme.Text = vlasnik.Ime;
                txtPrezime.Text = vlasnik.Prezime;
                txtTelefon.Text = vlasnik.Telefon;
                txtEmail.Text = vlasnik.Email;
                txtZanimanje.Text = vlasnik.Zanimanje;
                txtNapomena.Text = vlasnik.Napomena;
            }
        }
    }
}
