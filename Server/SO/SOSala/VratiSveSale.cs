using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOSala
{
    public class VratiSveSale : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            List<Sala> lista = new List<Sala>();
            lista = Sesija.Broker.vratiKonekciju().vratiSVe(odo).OfType<Sala>().ToList<Sala>();
           
            return lista;

        }
    }
}
