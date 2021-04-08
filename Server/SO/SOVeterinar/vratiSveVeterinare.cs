using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOVeterinar
{
    public class vratiSveVeterinare : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            List<Veterinar> lista = Sesija.Broker.vratiKonekciju().vratiSVe(odo).OfType<Veterinar>().ToList<Veterinar>();

            foreach (Veterinar v in lista)
            {
                Osoba o = new Osoba();
                o.Id = v.Id;
                o = Sesija.Broker.vratiKonekciju().vratiJedanZaID(o) as Osoba;
                v.Jmbg = o.Jmbg;
                v.Ime = o.Ime;
                v.Prezime = o.Prezime;
                v.Email = o.Email;
                v.Telefon = o.Telefon;

            }
            return lista;
        }
    }
}
