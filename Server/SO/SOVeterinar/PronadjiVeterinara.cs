using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOVeterinar
{
    public class PronadjiVeterinara : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
           
           Veterinar v = Sesija.Broker.vratiKonekciju().vratiJedanZaUslovOpsti(odo) as Veterinar;
            Osoba o = new Osoba();
            o.Id = v.Id;

           o = Sesija.Broker.vratiKonekciju().vratiJedanZaID(o) as Osoba;
            v.Jmbg = o.Jmbg;
            v.Ime = o.Ime;
            v.Prezime = o.Prezime;
            v.Email = o.Email;
            v.Telefon = o.Telefon;
            return v;
        }
    }
}
