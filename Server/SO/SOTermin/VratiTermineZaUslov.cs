using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOTermin
{
    public class VratiTermineZaUslov : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            List<Termin> lista = Sesija.Broker.vratiKonekciju().vratiSveZaUslovOpsti(odo).OfType<Termin>().ToList<Termin>();

            foreach (Termin t in lista)
            {
                t.Veterinar = Sesija.Broker.vratiKonekciju().vratiJedanZaID(t.Veterinar) as Veterinar;
                Osoba osoba = new Osoba();
                osoba.Id = t.Veterinar.Id;
                osoba = Sesija.Broker.vratiKonekciju().vratiJedanZaID(osoba) as Osoba;
                
                t.Veterinar.Ime = osoba.Ime;
                t.Veterinar.Prezime = osoba.Prezime;
                t.Veterinar.Telefon = osoba.Telefon;
                t.Veterinar.Email = osoba.Email;

                t.Ljubimac = Sesija.Broker.vratiKonekciju().vratiJedanZaID(t.Ljubimac) as Ljubimac;
                t.Zivotinja = new Zivotinja();
                t.Zivotinja.Id = t.Ljubimac.Zivotinja.Id;
                t.Zivotinja = Sesija.Broker.vratiKonekciju().vratiJedanZaID(t.Zivotinja) as Zivotinja;

                t.Sala = Sesija.Broker.vratiKonekciju().vratiJedanZaID(t.Sala) as Sala;

                osoba = new Osoba();
                osoba.Id = t.Ljubimac.Vlasnik.Id;
                osoba = Sesija.Broker.vratiKonekciju().vratiJedanZaID(osoba) as Osoba;
                t.Ljubimac.Vlasnik = Sesija.Broker.vratiKonekciju().vratiJedanZaID(t.Ljubimac.Vlasnik) as Vlasnik;
                t.Ljubimac.Vlasnik.Ime = osoba.Ime;
                t.Ljubimac.Vlasnik.Prezime = osoba.Prezime;
                t.Ljubimac.Vlasnik.Telefon = osoba.Telefon;
                t.Ljubimac.Vlasnik.Email = osoba.Email;
                t.Ljubimac.Zivotinja = Sesija.Broker.vratiKonekciju().vratiJedanZaID(t.Ljubimac.Zivotinja) as Zivotinja;
            }

            return lista;
        }
    }
}
