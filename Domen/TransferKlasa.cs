using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    
    public enum Operacija { Kraj = 1,
                            LogIn = 2,
                            KreirajLjubimca = 3,
                            ZapamtiLjubimca = 4,
                            VratiVlasnike = 5,
                            PronadjiVlasnika = 6,
                            ZapamtiVlasnika = 7,
                            IzmeniVlasnika = 8,
                            UcitajSveLjubimce = 9,
                            PronadjiLjubimca = 10,
                            IzmeniLjubimca = 12,
                            PronadjiVeterinara = 13,
                            VratiSveVeterinare = 15,
                            VratiSveTermine = 16,
                            VratiTermineZaUslov = 17,
                            IzmeniTermin = 34,
                            KreirajTermin = 18,
                            KreirajVlasnika = 19,
                            PronadjiLjubimcaIzTabele = 21,
                            ObrisiVlasnika = 22,
                            ObrisiLjubimca = 23,
                            PronadjiTermine = 24,
                            ObrisiTermin = 30,
                            ZapamtiLjubimcaSaVlasnikom = 31,
                            SacuvajTermin = 32,
                            VratiSveSale = 33,
                            VratiSveVlasnike = 35,
                            PronadjiOsobe = 36,
                            VratiOsobeVlasnik = 37,
                            IzmeniProtekliTermin = 38,
    }
    [Serializable]
    public class TransferKlasa
    {
       public Operacija operacija;
       public Object poruka;
       public Object odgovor;

    }
}
