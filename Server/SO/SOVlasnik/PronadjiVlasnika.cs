using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOVlasnik
{
    public class PronadjiVlasnika : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Vlasnik v = Sesija.Broker.vratiKonekciju().vratiJedanZaID(odo) as Vlasnik;
            if (v == null)
            {
                return null;
            }
            Osoba o = new Osoba();
            o.Id = v.Id;

            o = Sesija.Broker.vratiKonekciju().vratiJedanZaID(o) as Osoba;
            v.Jmbg = o.Jmbg;
            v.Ime = o.Ime;
            v.Prezime = o.Prezime;
            v.Email = o.Email;
            v.Telefon = o.Telefon;

            Ljubimac lj = new Ljubimac();
            lj.USLOVI = " IDVlasnik = " + v.Id + " and Status = 'Aktivan'";
            v.Ljubimci = Sesija.Broker.vratiKonekciju().vratiSveZaUslovOpsti(lj).OfType<Ljubimac>().ToList<Ljubimac>();

            return v;
        }
    }
}
