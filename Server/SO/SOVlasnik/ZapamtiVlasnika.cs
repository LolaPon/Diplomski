using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.SO.SOVlasnik
{
    public class ZapamtiVlasnika : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Vlasnik v = odo as Vlasnik;
            Osoba o = new Osoba();
            o.Id = v.Id;
            o.Ime = v.Ime;
            o.Prezime = v.Prezime;
            o.Telefon = v.Telefon;
            o.Email = v.Email;

            
            try
            {
                Sesija.Broker.vratiKonekciju().insert(o);
                Sesija.Broker.vratiKonekciju().insert(odo);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
