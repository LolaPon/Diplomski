using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using Sesija;

namespace Server.SO
{
    public abstract class OpstaSistemskaOperacija
    {
        public object IzvrsiSO(OpstiDomenskiObjekat odo)
        {
            object rez = null;

            try
            {
                Broker.vratiKonekciju().otvoriKonekciju();
                Broker.vratiKonekciju().zapocniTransakciju();
                rez = Izvrsi(odo);
                Broker.vratiKonekciju().potvrdiTransakciju();

            }
            catch (Exception)
            {

                Broker.vratiKonekciju().ponistiTransakciju();
            }
            finally 
            {
                Broker.vratiKonekciju().zatvoriKonekciju();
            }
            return rez;
        }

        public abstract object Izvrsi(OpstiDomenskiObjekat odo);


    }
}
