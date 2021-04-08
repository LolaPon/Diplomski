using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOLjubimac
{
    public class UcitajSveLjubimce : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            List<Ljubimac> lista = new List<Ljubimac>();
            lista = Sesija.Broker.vratiKonekciju().vratiSveZaUslovOpsti(odo).OfType<Ljubimac>().ToList<Ljubimac>();

            foreach(Ljubimac lj in lista)
            {

                lj.Vlasnik = Sesija.Broker.vratiKonekciju().vratiJedanZaID(lj.Vlasnik) as Vlasnik;
                Osoba vlasnik = new Osoba();
                vlasnik.Id = lj.Vlasnik.Id;
                vlasnik = Sesija.Broker.vratiKonekciju().vratiJedanZaID(vlasnik) as Osoba;
                lj.Vlasnik.Ime = vlasnik.Ime;
                lj.Vlasnik.Prezime = vlasnik.Prezime;
                lj.Vlasnik.Telefon = vlasnik.Telefon;
                lj.Vlasnik.Email = vlasnik.Email;

                lj.Zivotinja = Sesija.Broker.vratiKonekciju().vratiJedanZaID(lj.Zivotinja) as Zivotinja;
            }
            return lista;

        }
    }
}
