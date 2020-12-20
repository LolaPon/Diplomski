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
using Sesija;

namespace Forme
{
    public partial class FrmPocetna : Form
    {
        //  BindingList<Termin> termini;
        KontrolerKI kontroler = new KontrolerKI();

        Veterinar veterinar = new Veterinar();
        public FrmPocetna()
        {
            InitializeComponent();
        }

        public FrmPocetna(Veterinar vet)
        {
            InitializeComponent();
            veterinar = vet;
            lblVet.Text += vet.Ime + " " + vet.Prezime;
        }

        public Veterinar Vet { get; }

        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void krajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void prikaziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmLjubimci().ShowDialog();

        }

        private void FrmPocetna_Load(object sender, EventArgs e)
        {
            kontroler.vratiDanasnjeTermine(gridTermini);
            

        }

        private void unesiNovogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmUnesiNovogLjubimca().Show();
        }

        private void rasporedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmRaspored().ShowDialog();
        }

        private void vlasniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmVlasnici().Show();
        }

        private void gridTermini_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Termin termin = new Termin();
            termin = gridTermini.CurrentRow.DataBoundItem as Termin;
            new FrmUnesiNoviTermin(termin).Show();

        }
    }
}
