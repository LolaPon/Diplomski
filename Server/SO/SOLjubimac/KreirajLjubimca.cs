using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOLjubimac
{
    class KreirajLjubimca : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Ljubimac lj = new Ljubimac();
            lj.Id = Sesija.Broker.vratiKonekciju().vratiID(odo);
            //Sesija.Broker.vratiKonekciju().insert(lj);
            return lj;
        }
    }
}
