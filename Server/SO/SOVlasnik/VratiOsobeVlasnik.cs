using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOVlasnik
{
    public class VratiOsobeVlasnik : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            return Sesija.Broker.vratiKonekciju().vratiOsobeVlasnik(odo).OfType<Vlasnik>().ToList<Vlasnik>();
        }
    }
}
