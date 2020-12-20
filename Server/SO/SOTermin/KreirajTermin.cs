using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOTermin
{
    public class KreirajTermin : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Termin t = new Termin();
            t.Id = Sesija.Broker.vratiKonekciju().vratiID(odo);
            return t;
        }
    }
}
