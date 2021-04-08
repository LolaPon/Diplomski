using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SO.SOVlasnik
{
    public class VratiVlasnike : OpstaSistemskaOperacija
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Osoba o = new Osoba();

            
            List<Vlasnik> lista = Sesija.Broker.vratiKonekciju().vratiSveZaUslovOpsti(odo).OfType<Vlasnik>().ToList<Vlasnik>();
            
            Ljubimac ljubimac = new Ljubimac();
            
            foreach (Vlasnik v in lista)
            {
                
                o.Id = v.Id;
                o = Sesija.Broker.vratiKonekciju().vratiJedanZaID(o) as Osoba;
                v.Jmbg = o.Jmbg;
                v.Ime = o.Ime;
                v.Prezime = o.Prezime;
                v.Email = o.Email;
                v.Telefon = o.Telefon;
                ljubimac.USLOVI = "IDVlasnik = " + v.Id + " and Status = 'Aktivan'";
                v.Ljubimci = Sesija.Broker.vratiKonekciju().vratiSveZaUslovOpsti(ljubimac).OfType<Ljubimac>().ToList<Ljubimac>();
             }
            return lista;
        }
    }
}
