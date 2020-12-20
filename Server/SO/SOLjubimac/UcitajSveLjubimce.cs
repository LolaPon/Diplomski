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
            lista = Sesija.Broker.vratiKonekciju().vratiSVe(odo).OfType<Ljubimac>().ToList<Ljubimac>();

            foreach(Ljubimac lj in lista)
            {
                //lj.Veterinar = Sesija.Broker.vratiKonekciju().vratiJedanZaID(lj.Veterinar) as Veterinar;
                //Osoba vet = new Osoba();
                //vet.Jmbg = lj.Veterinar.Jmbg;
                //vet = Sesija.Broker.vratiKonekciju().vratiJedanZaID(vet) as Osoba;
                //lj.Veterinar.Ime = vet.Ime;
                //lj.Veterinar.Prezime = vet.Prezime;
                //lj.Veterinar.Telefon = vet.Telefon;
                //lj.Veterinar.Email = vet.Email;

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
