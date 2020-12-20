using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.SO.SOOsoba
{
    public class PronadjiOsobe : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            try
            {
                return Sesija.Broker.vratiKonekciju().vratiSveZaUslovOpsti(odo).OfType<Osoba>().ToList<Osoba>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
