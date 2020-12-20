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
    public partial class FrmUnesiNoviTermin : Form
    {
        KontrolerKI kontroler = new KontrolerKI();
        Ljubimac lj = new Ljubimac();
        Sala sala = new Sala();
        Termin t = new Termin();

        public FrmRaspored FrmRaspored { get; }
        

        public FrmUnesiNoviTermin()
        {
            InitializeComponent();
        }

        public FrmUnesiNoviTermin(Termin termin)
        {
            InitializeComponent();
            t = termin;
            btnSacuvaj.Text = "Izmeni";

        }

        private void txtLjubimac_TextChanged(object sender, EventArgs e)
        {
            kontroler.pronadjiLjubimce(txtLjubimac, gridLjubimci);
           
            gridLjubimci.Columns["Starost"].Visible = false;
            gridLjubimci.Columns["Pol"].Visible = false;
            gridLjubimci.Columns["Boja"].Visible = false;

        }

        private void Termin_Load(object sender, EventArgs e)
        {
            List<Veterinar> veterinari = kontroler.vratiSveVeterinare();
            List<Sala> sale = kontroler.vratiSveSale();

            foreach (Veterinar v in veterinari)
            {
                cmbVeterinar.Items.Add(v);
            }
            foreach (Sala s in sale)
            {
                cmbSala.Items.Add(s);
            }

            cmbVeterinar.SelectedIndex = cmbVeterinar.FindStringExact(kontroler.vratiUlogovanogVeterinara().ToString());

            if (btnSacuvaj.Text == "Izmeni")
            {
                txtLjubimac.Text = t.Ljubimac.ToString();
                cmbVeterinar.SelectedIndex = cmbVeterinar.FindStringExact(t.Veterinar.ToString());
                string datumIVreme = t.DatumIvreme.ToString("dd.MM.yyyy. HH:mm");
                dateTimePicker1.Value = t.DatumIvreme;
                cmbSati.SelectedIndex = cmbSati.FindStringExact(datumIVreme.Split(' ')[1].Split(':')[0]);
                cmbMinuti.SelectedIndex = cmbMinuti.FindStringExact(datumIVreme.Split(' ')[1].Split(':')[1]);
                cmbSala.SelectedIndex = cmbSala.FindStringExact(t.Sala.ToString());
                txtOpis.Text = t.Opis;
                txtVrsta.Text = t.VrstaTermina;

                if (t.DatumIvreme < DateTime.Now)
                {
                    dateTimePicker1.Enabled = false;
                    txtLjubimac.ReadOnly = true;
                    cmbVeterinar.Enabled = false;
                    cmbSati.Enabled = false;
                    cmbMinuti.Enabled = false;
                    cmbSala.Enabled = false;
                    txtVrsta.ReadOnly = true;
                }
                else {  }
            }
        }

        private void gridLjubimci_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lj = gridLjubimci.CurrentRow.DataBoundItem as Ljubimac;
            

            txtLjubimac.Text = lj.ToString();
          //  cmbVeterinar.SelectedIndex = cmbVeterinar.FindStringExact(lj.Veterinar.ToString());
            
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (btnSacuvaj.Text == "Izmeni")
            {
                if (dateTimePicker1.Enabled)
                {
                    if (kontroler.izmeniTermin(gridLjubimci, cmbVeterinar, dateTimePicker1, cmbSati, cmbMinuti, cmbSala, txtOpis, t.Id, txtVrsta))
                        this.Close();
                }else
                {
                    if (kontroler.izmeniProtekliTermin(gridLjubimci, cmbVeterinar, dateTimePicker1, cmbSati, cmbMinuti, cmbSala, txtOpis, t.Id, txtVrsta))
                        this.Close();
                }
            }
            else
            {
                if (kontroler.sacuvajTermin(gridLjubimci, cmbVeterinar, dateTimePicker1,cmbSati ,cmbMinuti, cmbSala, txtOpis , txtVrsta ))
                {
                    this.Close();
                }
            }
        }
    }
}
