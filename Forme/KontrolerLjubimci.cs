using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domen;


namespace Forme
{
    public class KontrolerLjubimci
    {
        public delegate void Delegat(DataGridView gridLjubimci, Vlasnik vlasnik);
        Ljubimac ljubimac;
        


        //internal void osluskuj(DataGridView gridLjubimci)
        //{
           
        //    ThreadStart ts = primiPoruku;
        //    new Thread(ts).Start();

        //}

        //void primiPoruku()
        //{
        //    while (true)
        //    {
        //        TransferKlasa transfer = Komunikacija.Instanca.primiPoruku();
        //        Delegat d = new Delegat(prikaziLjubimce);
        //        d.Invoke(gridLjubimci, null);
        //    }
        //}





        internal void prikaziLjubimce(DataGridView gridLjubimci, Vlasnik vlasnik)
        {
            ljubimac = new Ljubimac();
            List<Ljubimac> lista = new List<Ljubimac>();

            if (vlasnik != null)
            {
                ljubimac.USLOVI = " IDVlasnik = " + vlasnik.Id;
                lista = Komunikacija.Instanca.pronadjiLjubimca(ljubimac);
                return;
            }

            lista = Komunikacija.Instanca.ucitajSveLjubimce(ljubimac);

            if (lista == null)
            {
                MessageBox.Show("Ne mozemo da ucitamo ljubimce!");
            }
            if (lista.Count == 0)
            {
                MessageBox.Show("Ne postoji lista ljubimaca");
            }
            gridLjubimci.DataSource = new BindingList<Ljubimac>(lista);
            gridLjubimci.Columns[6].Width = 110;
            gridLjubimci.Columns[3].Width = 60;
            gridLjubimci.Columns[4].Width = 60;
        }

       

        internal bool obrisiLjubimca(DataGridViewRow currentRow)
        {
            ljubimac = new Ljubimac();
            Termin termin = new Termin();
            Vlasnik vlasnik = new Vlasnik();
            List<Termin> termini = new List<Termin>();
            List<Ljubimac> ljubimci = new List<Ljubimac>();

            ljubimac.Ime = currentRow.Cells[2].Value.ToString();
            ljubimac.Starost = Convert.ToInt32(currentRow.Cells[3].Value.ToString());
            ljubimac.Pol = currentRow.Cells[4].Value.ToString();
            ljubimac.Boja = currentRow.Cells[5].Value.ToString();
            ljubimac.Rasa = currentRow.Cells[7].Value.ToString();


            ljubimac.Zivotinja = new Zivotinja();
            ljubimac.Zivotinja.Vrsta = currentRow.Cells[8].Value.ToString();

            ljubimac.Vlasnik = new Vlasnik();
            ljubimac.Vlasnik.Ime = currentRow.Cells[6].Value.ToString().Split(' ')[0];
            ljubimac.Vlasnik.Prezime = currentRow.Cells[6].Value.ToString().Split(' ')[1];

            ljubimac.USLOVI = " lj.Ime = '" + ljubimac.Ime + "' and lj.Rasa = '" + ljubimac.Rasa + "' and o.Ime = '" + ljubimac.Vlasnik.Ime + "' and o.Prezime = '" + ljubimac.Vlasnik.Prezime + /*"' and oo.Ime = '" + ljubimac.Veterinar.Ime + "' and oo.Prezime = '" + ljubimac.Veterinar.Prezime + */"'";
            ljubimac = Komunikacija.Instanca.pronadjiLjubimcaIzTabele(ljubimac);

            termin.USLOVI = " IDLjubimac = " + ljubimac.Id;
            if (Komunikacija.Instanca.vratiTermineZaUslov(termin) != null && Komunikacija.Instanca.vratiTermineZaUslov(termin).Count > 0)
            {
                MessageBox.Show("Nije moguće izbrisati ljubimca! Postoje termini za izabranog ljubimca!");
                new FrmRaspored(Komunikacija.Instanca.vratiTermineZaUslov(termin)).ShowDialog();
                return false;
            }
            vlasnik = ljubimac.Vlasnik;
            if (ljubimac.Id != 0 && ljubimac.Vlasnik.Id != 0 && termini.Count == 0)
            {
                ljubimac.USLOVI = " IDVlasnik = " + ljubimac.Vlasnik.Id;
                if (Komunikacija.Instanca.pronadjiLjubimca(ljubimac).Count > 1)
                {
                    MessageBox.Show("Vlasnik ima još ljubimaca.");
                    try
                    {
                        Komunikacija.Instanca.obrisiLjubimca(ljubimac);
                        MessageBox.Show("Uspešno ste obrisali ljubimca!");
                        return true;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                        return false;
                    }
                }
                else
                {

                    try
                    {
                        Komunikacija.Instanca.obrisiLjubimca(ljubimac);
                        Komunikacija.Instanca.obrisiVlasnika(vlasnik);
                        MessageBox.Show("Uspešno ste obrisali ljubimca!");
                        return true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Brisanje je bilo neuspešno.");
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Neki od ID-jeva je 0!");
                return false;
            }


        }



        internal void izmeniLjubimca(DataGridViewRow currentRow)
        {
            ljubimac = new Ljubimac();
            ljubimac.Ime = currentRow.Cells[2].Value.ToString();
            ljubimac.Starost = Convert.ToInt32(currentRow.Cells[3].Value.ToString());
            ljubimac.Pol = currentRow.Cells[4].Value.ToString();
            ljubimac.Boja = currentRow.Cells[5].Value.ToString();
            ljubimac.Rasa = currentRow.Cells[7].Value.ToString();


            ljubimac.Zivotinja = new Zivotinja();
            ljubimac.Zivotinja.Vrsta = currentRow.Cells[8].Value.ToString();

            ljubimac.Vlasnik = new Vlasnik();
            ljubimac.Vlasnik.Ime = currentRow.Cells[6].Value.ToString().Split(' ')[0];
            ljubimac.Vlasnik.Prezime = currentRow.Cells[6].Value.ToString().Split(' ')[1];



            ljubimac.USLOVI = "lj.Ime = '" + ljubimac.Ime + "' and o.Ime = '" + ljubimac.Vlasnik.Ime + "' and o.Prezime = '" + ljubimac.Vlasnik.Prezime + /*"' and oo.Ime = '" +ljubimac.Veterinar.Ime + "' and oo.Prezime = '" + ljubimac.Veterinar.Prezime + */"'";

            if (Komunikacija.Instanca.pronadjiLjubimcaIzTabele(ljubimac) == null)
            {
                MessageBox.Show("Doslo je do greske");
            }
            else
            {
                new FrmUnesiNovogLjubimca(Komunikacija.Instanca.pronadjiLjubimcaIzTabele(ljubimac)).ShowDialog();

            }

        }


        internal void pronadjiLjubimce(TextBox txtPretraga, DataGridView gridLjubimci)
        {
            ljubimac = new Ljubimac();
            ljubimac.USLOVI = " Ime like '" + txtPretraga.Text + "%' or Rasa like '" + txtPretraga + "%'";
            List<Ljubimac> lista = Komunikacija.Instanca.pronadjiLjubimca(ljubimac);
            gridLjubimci.DataSource = lista;
        }






    }
}
