using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Domen;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Sesija;
using Server.SO.SOLjubimac;
using Server.SO.SOVeterinar;
using Server.SO.SOVlasnik;
using Server.SO.SOTermin;
using Server.SO.SOSala;
using Server.SO.SOOsoba;
using Server.SO;

namespace Server
{
    public class NitKlijenta
    {
        private NetworkStream tok;
        BinaryFormatter formater;

        public NitKlijenta(NetworkStream tok)
        {
            this.tok = tok;
            formater = new BinaryFormatter();

            ThreadStart delegat = obradiZahtev;
            new Thread(delegat).Start();


        }

        void obradiZahtev()
        {
            try
            {
                int operacija = 0;
                while (operacija != (int)Operacija.Kraj)
                {
                    TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;

                    switch (transfer.operacija)
                    {
                        case Operacija.Kraj:
                            operacija = 1;
                            ServerKlasa.listaTokova.Remove(tok);
                            break;
                        case Operacija.LogIn:
                            operacija = 2;
                            break;
                        case Operacija.KreirajLjubimca:
                            KreirajLjubimca klj = new KreirajLjubimca();
                            transfer.odgovor = klj.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.ZapamtiLjubimca:
                            ZapamtiLjubimca zalj = new ZapamtiLjubimca();
                            transfer.odgovor = zalj.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.KreirajVlasnika:
                            KreirajVlasnika kv = new KreirajVlasnika();
                            transfer.odgovor = kv.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.VratiVlasnike:
                            VratiVlasnike vv = new VratiVlasnike();
                            transfer.odgovor = vv.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.VratiSveVlasnike:
                            VratiSveVlasnike vsv = new VratiSveVlasnike();
                            transfer.odgovor = vsv.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.VratiOsobeVlasnik:
                            VratiOsobeVlasnik vov = new VratiOsobeVlasnik();
                            transfer.odgovor = vov.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.ObrisiVlasnika:
                            ObrisiVlasnika ov = new ObrisiVlasnika();
                            transfer.odgovor = ov.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.ZapamtiVlasnika:
                            ZapamtiVlasnika zv = new ZapamtiVlasnika();
                            transfer.odgovor = zv.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.IzmeniVlasnika:
                            IzmeniVlasnika iv = new IzmeniVlasnika();
                            transfer.odgovor = iv.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.PronadjiVlasnika:
                            PronadjiVlasnika pvl = new PronadjiVlasnika();
                            transfer.odgovor = pvl.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.PronadjiLjubimca:
                            PronadjiLjubimca plj = new PronadjiLjubimca();
                            transfer.odgovor = plj.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.UcitajSveLjubimce:
                            UcitajSveLjubimce ulj = new UcitajSveLjubimce();
                            transfer.odgovor = ulj.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.PronadjiLjubimcaIzTabele:
                            PronadjiLjubimcaIzTabele pljt = new PronadjiLjubimcaIzTabele();
                            transfer.odgovor = pljt.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.ObrisiLjubimca:
                            ObrisiLjubimca olj = new ObrisiLjubimca();
                            transfer.odgovor = olj.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.IzmeniLjubimca:
                            IzmeniLjubimca izlj = new IzmeniLjubimca();
                            transfer.odgovor = izlj.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.ZapamtiLjubimcaSaVlasnikom:
                            ZapamtiLjubimcaSaVlasnikom zljv = new ZapamtiLjubimcaSaVlasnikom();
                            transfer.odgovor = zljv.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.PronadjiVeterinara:
                            PronadjiVeterinara pvet = new PronadjiVeterinara();
                            transfer.odgovor = pvet.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        //case Operacija.DodajTermin:
                        //    operacija = 14;
                        //    break;
                        case Operacija.VratiSveVeterinare:
                            vratiSveVeterinare vsvet = new vratiSveVeterinare();
                            transfer.odgovor = vsvet.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.VratiSveTermine:
                            VratiSveTermine pt = new VratiSveTermine();
                            transfer.odgovor = pt.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.VratiTermineZaUslov:
                            VratiTermineZaUslov vt = new VratiTermineZaUslov();
                            transfer.odgovor = vt.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.PronadjiTermine:
                            PronadjiTermine ptr = new PronadjiTermine();
                            transfer.odgovor = ptr.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.KreirajTermin:
                            KreirajTermin kt = new KreirajTermin();
                            transfer.odgovor = kt.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.SacuvajTermin:
                            SacuvajTermin st = new SacuvajTermin();
                            transfer.odgovor = st.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.IzmeniTermin:
                            IzmeniTermin it = new IzmeniTermin();
                            transfer.odgovor = it.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.IzmeniProtekliTermin:
                            IzmeniProtekliTermin ipt = new IzmeniProtekliTermin();
                            transfer.odgovor = ipt.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.ObrisiTermin:
                            ObrisiTermin ot = new ObrisiTermin();
                            transfer.odgovor = ot.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.VratiSveSale:
                            VratiSveSale vss = new VratiSveSale();
                            transfer.odgovor = vss.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacija.PronadjiOsobe:
                            PronadjiOsobe po = new PronadjiOsobe();
                            transfer.odgovor = po.IzvrsiSO(transfer.poruka as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        default:
                            break;
                    }


                }
            }
            catch (Exception)
            {

                try
                {
                    ServerKlasa.listaTokova.Remove(tok);
                }
                catch (Exception)
                {

                }
            }


        }
    }
}
