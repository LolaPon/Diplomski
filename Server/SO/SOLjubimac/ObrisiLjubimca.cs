using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOLjubimac
{
    public class ObrisiLjubimca : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            if (Sesija.Broker.vratiKonekciju().deleteJedan(odo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
