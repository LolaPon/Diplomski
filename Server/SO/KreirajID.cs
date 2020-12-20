using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO
{
    public class KreirajID : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            return Sesija.Broker.vratiKonekciju().vratiID(odo);
        }
    }
}
