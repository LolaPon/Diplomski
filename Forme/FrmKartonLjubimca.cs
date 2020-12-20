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
    public partial class FrmKartonLjubimca : Form
    {
        Ljubimac ljub = new Ljubimac();
        KontrolerKI kontroler = new KontrolerKI();
        Termin termin = new Termin();
        public FrmKartonLjubimca()
        {
            InitializeComponent();
        }

        public FrmKartonLjubimca(Ljubimac ljubimac)
        {
            InitializeComponent();
            ljub = ljubimac;
        }

        private void FrmKartonLjubimca_Load(object sender, EventArgs e)
        {
            txtIme.Text = ljub.Ime;
            txtVlasnik.Text = ljub.Vlasnik.ToString();
            txtZivotinja.Text = ljub.Zivotinja.ToString();
            txtStarost.Text = ljub.Starost.ToString();
            gridTermini.DataSource = kontroler.prikaziTermineZaLjubimca(ljub);
            gridTermini.Columns["Opis"].Visible = false;

        }

        private void gridTermini_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            termin = gridTermini.CurrentRow.DataBoundItem as Termin;
            txtOpis.Text = termin.Opis;
        }
    }
}
