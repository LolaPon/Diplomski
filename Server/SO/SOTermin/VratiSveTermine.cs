using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOTermin
{
    public class VratiSveTermine : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            List<Termin> lista = Sesija.Broker.vratiKonekciju().vratiSVe(odo).OfType<Termin>().ToList<Termin>();
            foreach (Termin t in lista)
            {
                t.Ljubimac = Sesija.Broker.vratiKonekciju().vratiJedanZaID(t.Ljubimac) as Ljubimac;
                t.Veterinar = Sesija.Broker.vratiKonekciju().vratiJedanZaID(t.Veterinar) as Veterinar;
                Osoba o = new Osoba();
                o.Id = t.Veterinar.Id;
                o = Sesija.Broker.vratiKonekciju().vratiJedanZaID(o) as Osoba;

                t.Veterinar.Ime = o.Ime;
                t.Veterinar.Prezime = o.Prezime;
                t.Veterinar.Telefon = o.Telefon;
                t.Veterinar.Email = o.Email;
                t.Zivotinja = new Zivotinja();
                t.Zivotinja.Id = t.Ljubimac.Zivotinja.Id;
                t.Zivotinja = Sesija.Broker.vratiKonekciju().vratiJedanZaID(t.Zivotinja) as Zivotinja;

                
                t.Sala = Sesija.Broker.vratiKonekciju().vratiJedanZaID(t.Sala) as Sala;
            }
            return lista;


        }
    }
}
