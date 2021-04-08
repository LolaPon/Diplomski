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
    public partial class FrmIzvestaj : Form
    {
        KontrolerKI kontroler = new KontrolerKI();
        public FrmIzvestaj()
        {
            InitializeComponent();
        }

        private void FrmIzvestaj_Load(object sender, EventArgs e)
        {
            List<string> meseci = new List<string>() { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OKT", "NOV", "DEC"};
            foreach(string s in meseci)
            {
                cmbMeseci.Items.Add(s);
            }
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            kontroler.kreirajIzvestajZaVeterinara(cmbMeseci);
            this.Close();
        }
    }
}
