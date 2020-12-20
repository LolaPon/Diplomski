using Domen;
using Sesija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmLjubimci : Form
    {
       
        BindingList<Ljubimac> listaLjubimaca;
        KontrolerLjubimci kontroler = new KontrolerLjubimci();
        //KontrolerKI kontroler = new KontrolerKI();
        public FrmLjubimci()
        {
            InitializeComponent();

        }

        private void FrmLjubimci_Load(object sender, EventArgs e)
        {
            kontroler.prikaziLjubimce(gridLjubimci, null);
            //kontroler.osluskuj(gridLjubimci);
            
        }


        private void gridLjubimci_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridLjubimci.Columns[e.ColumnIndex].Name == "btnObrisi")
            {
                if (MessageBox.Show("Da li ste sigurni da želite da obrišete ljubimca?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (kontroler.obrisiLjubimca(gridLjubimci.CurrentRow))
                    {
                        kontroler.prikaziLjubimce(gridLjubimci, null);
                    }

                }
            }

            if (gridLjubimci.Columns[e.ColumnIndex].Name == "btnIzmeni")
            {
                kontroler.izmeniLjubimca(gridLjubimci.CurrentRow);
                kontroler.prikaziLjubimce(gridLjubimci, null);
                

            }

        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            kontroler.pronadjiLjubimce(txtPretraga, gridLjubimci);
        }

        private void gridLjubimci_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new FrmKartonLjubimca(gridLjubimci.CurrentRow.DataBoundItem as Ljubimac).Show();
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {

        }
    }
}