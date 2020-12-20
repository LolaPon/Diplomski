using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.SO.SOTermin
{
    public class IzmeniProtekliTermin : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            try
            {
                if (Sesija.Broker.vratiKonekciju().update2(odo) != 0)
                { return odo as Termin; }
                else { return null; }
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
