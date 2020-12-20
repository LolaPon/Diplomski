using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOVlasnik
{
    public class KreirajVlasnika : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Vlasnik v = new Vlasnik();
            Osoba o = new Osoba();
            v.Id = Sesija.Broker.vratiKonekciju().vratiID(o as OpstiDomenskiObjekat);
            return v;
        }
    }
}
