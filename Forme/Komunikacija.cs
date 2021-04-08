using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Sesija;
using System.Windows.Forms;

namespace Forme
{
    public class Komunikacija
    {
        NetworkStream tok;
        BinaryFormatter formater;
        TcpClient klijent;
        static Komunikacija instanca;

        public Komunikacija()
        {
            try
            {
                klijent = new TcpClient("localhost", 20000);
                tok = klijent.GetStream();
                formater = new BinaryFormatter();

            }
            catch (Exception)
            {


            }

        }

        public bool poveziSeNaServer()
        {
            try
            {
                klijent = new TcpClient("localhost", 20000);
                tok = klijent.GetStream();
                formater = new BinaryFormatter();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //public static Komunikacija Instanca
        //{
        //    get
        //    {
        //        if (instanca == null)
        //        {
        //            instanca = new Komunikacija();
        //        }
        //        return instanca;
        //    }
        //}

        public object pronadjiVeterinara(Veterinar veterinar)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.PronadjiVeterinara;
            transfer.poruka = veterinar;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor;

        }

        public List<Vlasnik> vratiSveVlasnike(Vlasnik vlasnik)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.VratiSveVlasnike;
            transfer.poruka = vlasnik;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor as List<Vlasnik>;
        }

        public List<Vlasnik> vratiVlasnike(Vlasnik vlasnik)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.VratiVlasnike;
            transfer.poruka = vlasnik;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor as List<Vlasnik>;
        }

        public List<Osoba> pronadjiOsobe(Osoba osoba)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.operacija = Operacija.PronadjiOsobe;
                transfer.poruka = osoba;
                formater.Serialize(tok, transfer);
                transfer = formater.Deserialize(tok) as TransferKlasa;

                return transfer.odgovor as List<Osoba>;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public object obrisiTermin(Termin termin)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.ObrisiTermin;
            transfer.poruka = termin;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor;
        }

        public List<Sala> vratiSveSale(Sala sala)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.VratiSveSale;
            transfer.poruka = sala;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor as List<Sala>;
        }

        public List<Termin> pronadjiTermine(Termin termin)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.PronadjiTermine;
            transfer.poruka = termin;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor as List<Domen.Termin>;
        }

        internal void kraj()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.Kraj;
        }

        public Termin kreirajTermin(Termin termin)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.KreirajTermin;
            transfer.poruka = termin;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor as Termin;
        }

        public object sacuvajTermin(Termin termin)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.SacuvajTermin;
            transfer.poruka = termin;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor;
        }

        public List<Termin> vratiSveTermine(Termin termin)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.VratiSveTermine;
            transfer.poruka = termin;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor as List<Termin>;
        }

        public object izmeniTermin(Termin termin)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.IzmeniTermin;
            transfer.poruka = termin;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor;
        }

        public object IzmeniProtekliTermin(Termin termin)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.operacija = Operacija.IzmeniProtekliTermin;
                transfer.poruka = termin;
                formater.Serialize(tok, transfer);
                transfer = formater.Deserialize(tok) as TransferKlasa;

                return transfer.odgovor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public List<Ljubimac> ucitajSveLjubimce(Ljubimac ljubimac)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.UcitajSveLjubimce;
            transfer.poruka = ljubimac;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            
            return transfer.odgovor as List<Ljubimac>;

        }

        public Ljubimac kreirajLjubimca(Ljubimac ljubimac)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.KreirajLjubimca;
            transfer.poruka = ljubimac;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor as Ljubimac;
        }

        public List<Veterinar> vratiSveVeterinare(Veterinar vet)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.VratiSveVeterinare;
            transfer.poruka = vet;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor as List<Veterinar>;
        }

        public Vlasnik kreirajVlasnika(Vlasnik vlasnik)

        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.KreirajVlasnika;
            transfer.poruka = vlasnik;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor as Vlasnik;
        }

        public List<Termin> vratiTermineZaUslov(Termin termin)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.VratiTermineZaUslov;
            transfer.poruka = termin;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor as List<Termin>;
        }

        public object sacuvajLjubimca(Ljubimac ljubimac)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.operacija = Operacija.ZapamtiLjubimca;
                transfer.poruka = ljubimac;
                formater.Serialize(tok, transfer);
                transfer = formater.Deserialize(tok) as TransferKlasa;

                return transfer.odgovor;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public object sacuvajVlasnika(Vlasnik vlasnik)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.operacija = Operacija.ZapamtiVlasnika;
                transfer.poruka = vlasnik;
                formater.Serialize(tok, transfer);
                transfer = formater.Deserialize(tok) as TransferKlasa;

                return transfer.odgovor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public Vlasnik izmeniVlasnika(Vlasnik vlasnik)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.operacija = Operacija.IzmeniVlasnika;
                transfer.poruka = vlasnik;
                formater.Serialize(tok, transfer);
                transfer = formater.Deserialize(tok) as TransferKlasa;

                return transfer.odgovor as Vlasnik;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public object sacuvajLjubimcaSaVlasnikom(Ljubimac ljubimac)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.ZapamtiLjubimcaSaVlasnikom;
            transfer.poruka = ljubimac;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor;
        }

        public Ljubimac pronadjiLjubimcaIzTabele(Ljubimac ljubimac)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.PronadjiLjubimcaIzTabele;
            transfer.poruka = ljubimac;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor as Ljubimac;
        }

        public Ljubimac izmeniLjubimca(Ljubimac ljubimac)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.IzmeniLjubimca;
            transfer.poruka = ljubimac;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor as Ljubimac;
        }

        public object obrisiVlasnika(Vlasnik vlasnik)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.ObrisiVlasnika;
            transfer.poruka = vlasnik;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor;
        }

        public object obrisiLjubimca(Ljubimac ljubimac)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.ObrisiLjubimca;
            transfer.poruka = ljubimac;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor;
        }

        public List<Ljubimac> pronadjiLjubimca(Ljubimac ljubimac)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacija.PronadjiLjubimca;
            transfer.poruka = ljubimac;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.odgovor as List<Ljubimac>;
        }

        public object pronadjiVlasnika(Vlasnik vlasnik)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.operacija = Operacija.PronadjiVlasnika;
                transfer.poruka = vlasnik;
                formater.Serialize(tok, transfer);
                transfer = formater.Deserialize(tok) as TransferKlasa;

                return transfer.odgovor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public List<Vlasnik> VratiOsobeVlasnik(Vlasnik vlasnik)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.operacija = Operacija.VratiOsobeVlasnik;
                transfer.poruka = vlasnik;
                formater.Serialize(tok, transfer);
                transfer = formater.Deserialize(tok) as TransferKlasa;

                return transfer.odgovor as List<Vlasnik>;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }







    }
}
