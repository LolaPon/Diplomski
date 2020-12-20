using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmRaspored : Form
    {
        KontrolerKI kontroler = new KontrolerKI();
        List<Termin> lista = new List<Termin>();
        Termin termin;
        

        public FrmRaspored()
        {
            InitializeComponent();
        }

        public FrmRaspored(List<Termin> termini)
        {
            InitializeComponent();
            lista = termini;
        }

        private void FrmRaspored_Load(object sender, EventArgs e)
        {
            kontroler.prikaziTermine(gridRaspored, lista);
            gridRaspored.Columns["DatumIVreme"].DefaultCellStyle.Format = "dd.MM.yyyy";
            gridRaspored.Columns["Opis"].Visible = false;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            kontroler.prikaziTermineZaDatum(gridRaspored, dateTimePicker);
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {

            kontroler.obrisiTermin(gridRaspored.CurrentRow.DataBoundItem as Termin);
            lista.Remove(gridRaspored.CurrentRow.DataBoundItem as Termin);
            kontroler.prikaziTermine(gridRaspored, lista);
        }

        private void btnDodajNovi_Click(object sender, EventArgs e)
        {
            new FrmUnesiNoviTermin().ShowDialog();
            kontroler.prikaziTermine(gridRaspored, lista);
        }

        private void gridRaspored_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            termin = gridRaspored.CurrentRow.DataBoundItem as Termin;
            if (termin.DatumIvreme < DateTime.Now)
            {
                btnIzmeni.Text = "Prikaži";
                //btnPrikazi.Enabled = true;
            }
            else 
            {
                btnIzmeni.Text = "Izmeni";
                //btnPrikazi.Enabled = false;
            }

           
        }

    private void btnIzmeni_Click(object sender, EventArgs e)
        {
            termin = new Termin();
            termin = gridRaspored.CurrentRow.DataBoundItem as Termin;
            
                new FrmUnesiNoviTermin(termin).ShowDialog();
                kontroler.prikaziTermine(gridRaspored, lista);
           
        }

        private void btnPonisti_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = DateTime.Now;
            kontroler.prikaziTermine(gridRaspored, null);
        }

        private void gridRaspored_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            termin = gridRaspored.CurrentRow.DataBoundItem as Termin;
            if (termin.DatumIvreme < DateTime.Now)
            {
                btnIzmeni.Enabled = false;
            }
            else { btnIzmeni.Enabled = true; }
        }

       
    }
}
