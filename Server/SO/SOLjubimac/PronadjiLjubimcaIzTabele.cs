using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOLjubimac
{
    public class PronadjiLjubimcaIzTabele : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            return Sesija.Broker.vratiKonekciju().vratiLjubimcaIzTabele(odo);
        }
    }
}
