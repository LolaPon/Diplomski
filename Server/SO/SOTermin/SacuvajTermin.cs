using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOTermin
{
    public class SacuvajTermin : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Termin t = odo as Termin;
            try
            {
                Sesija.Broker.vratiKonekciju().insert(odo);
                return t;
            }
            catch (Exception)
            {

                throw;
            }
                
        }
    }
}
