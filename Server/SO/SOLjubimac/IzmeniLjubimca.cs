using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOLjubimac
{
    public class IzmeniLjubimca : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            if (Sesija.Broker.vratiKonekciju().updateJedan(odo) != 0)
            {

                return odo;
            }
            else
            {
                return null;
            }
        }
    }
}
