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
using Sesija;

namespace Forme
{
    public partial class FrmLogIN : Form
    {
        KontrolerKI kontroler = new KontrolerKI();
        public FrmLogIN()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogIN_Click(object sender, EventArgs e)
        {

            if(kontroler.pronadjiVeterinara(txtUsername,txtPassword))
            {
                new FrmPocetna(KontrolerKI.veterinar).ShowDialog();
                this.Hide();
            }

        }

        private void btnSee_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void FrmLogIN_Load(object sender, EventArgs e)
        {

            //while(KontrolerKI.poveziSeNaServer().Contains("nije"))
            this.Text = KontrolerKI.poveziSeNaServer();
        }
    }
}
