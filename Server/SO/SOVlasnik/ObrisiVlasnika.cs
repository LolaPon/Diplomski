using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOVlasnik
{
    public class ObrisiVlasnika : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Vlasnik v = odo as Vlasnik;
            Osoba o = new Osoba();
            o.Id = v.Id;

            try
            {
                Sesija.Broker.vratiKonekciju().deleteJedan(odo);
                Sesija.Broker.vratiKonekciju().deleteJedan(o);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }
    }
}
