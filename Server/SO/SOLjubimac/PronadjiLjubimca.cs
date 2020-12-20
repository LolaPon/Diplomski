using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOLjubimac
{
    public class PronadjiLjubimca : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            List<Ljubimac> ljubimci = Sesija.Broker.vratiKonekciju().vratiSveZaUslovOpsti(odo).OfType<Ljubimac>().ToList<Ljubimac>();
            foreach (Ljubimac lj in ljubimci)
            {
                
                lj.Vlasnik = Sesija.Broker.vratiKonekciju().vratiJedanZaID(lj.Vlasnik) as Vlasnik;
                Osoba o = new Osoba();
                o.Id = lj.Vlasnik.Id;
                o = Sesija.Broker.vratiKonekciju().vratiJedanZaID(o) as Osoba;
                lj.Vlasnik.Ime = o.Ime;
                lj.Vlasnik.Prezime = o.Prezime;
                lj.Vlasnik.Telefon = o.Telefon;
                lj.Vlasnik.Email = o.Email;

                lj.Zivotinja = Sesija.Broker.vratiKonekciju().vratiJedanZaID(lj.Zivotinja) as Zivotinja;
            }
            return ljubimci;
        }
    }
}
