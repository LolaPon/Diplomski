using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOTermin
{
    public class PronadjiTermine : OpstaSistemskaOperacija
    {


        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            List<Termin> termini = Sesija.Broker.vratiKonekciju().vratiTermineJoin(odo).OfType<Termin>().ToList<Termin>();
            foreach (Termin t in termini)
            {
                t.Veterinar = Sesija.Broker.vratiKonekciju().vratiJedanZaID(t.Veterinar) as Veterinar;
                t.Ljubimac = Sesija.Broker.vratiKonekciju().vratiJedanZaID(t.Ljubimac) as Ljubimac;
                t.Zivotinja = new Zivotinja();
                t.Zivotinja.Id = t.Ljubimac.Zivotinja.Id;
                t.Zivotinja = Sesija.Broker.vratiKonekciju().vratiJedanZaID(t.Zivotinja) as Zivotinja;
                t.Sala = Sesija.Broker.vratiKonekciju().vratiJedanZaID(t.Sala) as Sala;
            }
            return termini;
        }
    }
}
