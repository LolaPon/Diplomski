using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.SO.SOVlasnik
{
    public class IzmeniVlasnika : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Vlasnik v = odo as Vlasnik;
            Osoba o = new Osoba();
            o.Id = v.Id;
            o.Jmbg = v.Jmbg;
            o.Ime = v.Ime;
            o.Prezime = v.Prezime;
            o.Telefon = v.Telefon;
            o.Email = v.Email;

            try
            {
                Sesija.Broker.vratiKonekciju().updateJedan(odo);
                Sesija.Broker.vratiKonekciju().updateJedan(o);
                return odo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
