using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOTermin
{
    public class IzmeniTermin : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            try
            {
                if (Sesija.Broker.vratiKonekciju().updateJedan(odo) != 0)
                { return odo as Termin; }
                else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
