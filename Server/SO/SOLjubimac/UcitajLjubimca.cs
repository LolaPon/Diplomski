using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOLjubimac
{
    public class UcitajLjubimca : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Ljubimac lj = new Ljubimac();
            lj = Sesija.Broker.vratiKonekciju().vratiJedanZaID(odo) as Ljubimac;
            lj.Vlasnik = Sesija.Broker.vratiKonekciju().vratiJedanZaID(lj.Vlasnik) as Vlasnik;
            lj.Zivotinja = Sesija.Broker.vratiKonekciju().vratiJedanZaID(lj.Zivotinja) as Zivotinja;

            return lj;
        }
    }
}
