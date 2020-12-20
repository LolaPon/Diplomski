using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Server
{
    public partial class ServerForma : Form
    {
        ServerKlasa server;
        public ServerForma()
        {
            InitializeComponent();
        }
        
        private void btnPokreni_Click(object sender, EventArgs e)
        {
            server = new ServerKlasa();

            if (server.PokreniServer())
            {
                this.Text = "Server je pokrenut!";
                //MessageBox.Show("Server je pokrenut");
                btnPokreni.Enabled = false;
                btnZaustavi.Enabled = true;
                
                
            }
                
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            if (ServerKlasa.listaTokova.Count > 0)
            {
                MessageBox.Show("Ima idalje ulogovanih korisnika!");
                return;
            }

            if (server.zaustaviServer())
            {
                MessageBox.Show("Server je zaustavljen");
                btnPokreni.Enabled = true;
                btnZaustavi.Enabled = false;
            }
        }

        private void ServerForma_Load(object sender, EventArgs e)
        {
            
        }
    }
}
