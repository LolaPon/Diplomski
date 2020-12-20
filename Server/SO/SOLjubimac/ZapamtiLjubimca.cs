using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOLjubimac
{
    public class ZapamtiLjubimca : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {

            try
            {
                Sesija.Broker.vratiKonekciju().insert(odo);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
