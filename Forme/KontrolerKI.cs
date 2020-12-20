using Domen;
using Sesija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public class KontrolerKI
    {
        public delegate void Delegat(TransferKlasa transfer);
        static Komunikacija komunikacija;
        public static Veterinar veterinar;
        Termin termin;
        static Ljubimac ljubimac;
        static Zivotinja zivotinja;
        static Vlasnik vlasnik;

        //public KontrolerKI()
        //{
        //    ThreadStart ts = primiPoruku;
        //    new Thread(ts).Start();
        //}

        //private void primiPoruku()
        //{
        //    while (true)
        //    {
        //        TransferKlasa transfer = komunikacija.primiPoruku();
        //        Delegat d = new Delegat(zvrsiOperaciju);
        //        invoke(d, transfer)
        //    }
        //}

        //private Delegat zvrsiOperaciju(TransferKlasa transfer)
        //{
        //    throw new NotImplementedException();
        //}

        public static string poveziSeNaServer()
        {
            komunikacija = new Komunikacija();
            if (komunikacija.poveziSeNaServer())
            {
                return "Veterinar je povezan na server!";

            }
            else
            {

                return "Veterinar nije povezan na server!";
            }

        }


        internal List<Vlasnik> vratiSveVlasnike()
        {
            vlasnik = new Vlasnik();
            try
            {
                return komunikacija.vratiSveVlasnike(vlasnik);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        internal List<Termin> prikaziTermineZaLjubimca(Ljubimac ljub)
        {
            termin = new Termin();
            termin.USLOVI = "IDLjubimac = " + ljub.Id;

            return komunikacija.vratiTermineZaUslov(termin);
        }

        internal Vlasnik proveriVlasnika(Vlasnik vlasnik)
        {
            List<Vlasnik> lista = new List<Vlasnik>();
            //Osoba o = new Osoba();
            vlasnik.USLOVI = " Telefon = '" + vlasnik.Telefon + "'";
            
            lista = komunikacija.VratiOsobeVlasnik(vlasnik);

            if(lista == null || lista.Count == 0)
            {
                vlasnik = komunikacija.kreirajVlasnika(vlasnik);
                if (vlasnik != null)
                {
                    MessageBox.Show("Kreiran je novi vlasnik!");
                    return vlasnik;
                }
                else return null;
            } 
            else { 
                MessageBox.Show("Vlasnik već postoji u bazi.");
                //vlasnik = komunikacija.pronadjiVlasnika(vlasnik) as Vlasnik;

                return lista[0];
            }
            
        }

        internal bool obrisiLjubimcaIzListe(Ljubimac lj, Vlasnik vlasnik)
        {
            termin = new Termin();
            List<Termin> termini = new List<Termin>();
            termin.USLOVI = " IDLjubimac = " + lj.Id;
            if (komunikacija.vratiTermineZaUslov(termin) != null && komunikacija.vratiTermineZaUslov(termin).Count > 0)
            {
                MessageBox.Show("Nije moguće izbrisati ljubimca! Postoje termini za izabranog ljubimca!");
                new FrmRaspored(komunikacija.vratiTermineZaUslov(termin)).ShowDialog();
                return false;
            }
            
            if (lj.Id != 0 && vlasnik.Id != 0 && termini.Count == 0)
            {
                
                if (vlasnik.Ljubimci.Count > 1)
                {
                   // MessageBox.Show("Vlasnik ima još ljubimaca.");
                    try
                    {
                        komunikacija.obrisiLjubimca(lj);
                        vlasnik.Ljubimci.RemoveAt(vlasnik.Ljubimci.IndexOf(lj));
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
                    if(vlasnik.Ljubimci.Count == 1)
                    {
                       if(MessageBox.Show("Da li želite da obrišete i vlasnika?", " ",MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            komunikacija.obrisiLjubimca(lj);
                            komunikacija.obrisiVlasnika(vlasnik);
                            MessageBox.Show("Uspešno su obrisani vlasnik i ljubimac!");
                            
                            return true;
                        } return false;
                    }

                    MessageBox.Show("Ne postoje ljubimci za datog vlasnika!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Neki od ID-jeva je 0!");
                return false;
            }
        }

        internal bool izmeniProtekliTermin(DataGridView gridLjubimci, ComboBox cmbVeterinar, DateTimePicker dateTimePicker1, ComboBox cmbSati, ComboBox cmbMinuti, ComboBox cmbSala, TextBox txtOpis, int id, TextBox txtVrsta)
        {
            termin = new Termin();
            termin.Id = id;
            termin.Ljubimac = new Ljubimac();
            List<Termin> termini = new List<Termin>();
            
            termin.Ljubimac = gridLjubimci.CurrentRow.DataBoundItem as Ljubimac;
            
            termin.Veterinar = new Veterinar();
            termin.Veterinar = cmbVeterinar.SelectedItem as Veterinar;
            termin.Sala = new Sala();
            termin.Sala = cmbSala.SelectedItem as Sala;
            termin.Opis = txtOpis.Text;
            termin.VrstaTermina = txtVrsta.Text;
            
            string vreme = cmbSati.SelectedItem.ToString() + ":" + cmbMinuti.SelectedItem.ToString();
            string datum = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            try
            {
                termin.DatumIvreme = Convert.ToDateTime(datum + " " + vreme);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
            if (komunikacija.IzmeniProtekliTermin(termin) != null)
            {
                MessageBox.Show("Uspešno ste izmenili termin!");
                return true;
            }
            else { MessageBox.Show("Izmena termina nije uspela!"); return false; }


        }

        internal Veterinar vratiUlogovanogVeterinara()
        {
            return veterinar;
        }

        internal void pretraziTermine(TextBox txtPretraga, DataGridView gridRaspored)
        {

            termin = new Termin();
            termin.USLOVI = " lj.Ime like '" + txtPretraga.Text + "%' or v.Ime like '" + txtPretraga + "%' or v.Prezime like '" + txtPretraga.Text + "%' or z.Vrsta = '" + txtPretraga + "%'";
            gridRaspored.DataSource = komunikacija.pronadjiTermine(termin);

        }

        internal List<Sala> vratiSveSale()
        {
            Sala sala = new Sala();

            return komunikacija.vratiSveSale(sala);
        }

        internal void obrisiTermin(Termin termin)
        {
            try
            {
                komunikacija.obrisiTermin(termin);
                MessageBox.Show("Uspešno ste obrisali termin!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal bool sacuvajTermin(DataGridView gridLjubimci, ComboBox cmbVeterinar, DateTimePicker dateTimePicker1, ComboBox cmbSati, ComboBox cmbMinuti, ComboBox cmbSala, TextBox txtOpis, TextBox txtVrsta)
        {
            termin = new Termin();
            termin = komunikacija.kreirajTermin(termin);
            List<Termin> termini = new List<Termin>();

            termin.Ljubimac = new Ljubimac();
            termin.Ljubimac = gridLjubimci.CurrentRow.DataBoundItem as Ljubimac;
            termin.Veterinar = new Veterinar();
            termin.Veterinar = cmbVeterinar.SelectedItem as Veterinar;
            termin.Sala = new Sala();
            termin.Sala = cmbSala.SelectedItem as Sala;
            termin.Opis = txtOpis.Text;
            termin.VrstaTermina = txtVrsta.Text;
            string vreme = cmbSati.SelectedItem.ToString() + ":" + cmbMinuti.SelectedItem.ToString();
            string datum = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            try
            {
                termin.DatumIvreme = Convert.ToDateTime(datum + " " + vreme);
            }
            catch (Exception)
            {

                throw;
            }
            termin.USLOVI = "DatumIVreme between DATEADD(MINUTE,-30,'" + datum + " " + vreme + "') and DATEADD(MINUTE,30,'" + datum + " " + vreme + "')";
            termini = komunikacija.vratiTermineZaUslov(termin);
            if (termini != null && termini.Count > 0)
            {
                MessageBox.Show("Imate zakazanu " + termini[0].VrstaTermina + " u " + termini[0].DatumIvreme.ToString("HH:mm"));
                return false;
            }

            if (komunikacija.sacuvajTermin(termin)!=null)
            {
                MessageBox.Show("Uspešno ste dodali termin!");
                return true;
            } else { MessageBox.Show("Dodavanje termina nije uspelo!"); return false; }

        }

        internal bool izmeniTermin(DataGridView gridLjubimci, ComboBox cmbVeterinar, DateTimePicker dateTimePicker1, ComboBox cmbSati, ComboBox cmbMinuti, ComboBox cmbSala, TextBox txtOpis, int id, TextBox txtVrsta)
        {
            termin = new Termin();
            termin.Id = id;
            termin.Ljubimac = new Ljubimac();
            List<Termin> termini = new List<Termin>();

            if (gridLjubimci.CurrentRow.DataBoundItem == null)
            { MessageBox.Show("Izaberite ljubimca!");
                return false;
            }
            else
            {
                termin.Ljubimac = gridLjubimci.CurrentRow.DataBoundItem as Ljubimac;
            }
            termin.Veterinar = new Veterinar();
            if (cmbVeterinar.SelectedItem == null)
            { MessageBox.Show("Izaberite veterinara!");
                return false;
            }
            else
            {
                termin.Veterinar = cmbVeterinar.SelectedItem as Veterinar;
            }
            termin.Sala = new Sala();
            if (cmbSala.SelectedItem == null)
            { MessageBox.Show("Izaberite salu!");
                return false;
            }
            else
            {
                termin.Sala = cmbSala.SelectedItem as Sala;
            }
            termin.Opis = txtOpis.Text;
            if (txtVrsta.Text == "")
            { MessageBox.Show("Unesite vrstu pregleda!");
                return false;
            }
            else
            {
                termin.VrstaTermina = txtVrsta.Text;
            }
            string vreme = cmbSati.SelectedItem.ToString() + ":" + cmbMinuti.SelectedItem.ToString();
            string datum = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            if(vreme == "" || datum == "")
            { MessageBox.Show("Odaberite vreme termina!");
                return false;
            }
            try
            {
                termin.DatumIvreme = Convert.ToDateTime(datum + " " + vreme);
                if(termin.DatumIvreme < DateTime.Now)
                { MessageBox.Show("Nije moguće zameniti termin za izabrani datum. Izabran datum je prošao!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            termin.USLOVI = "DatumIVreme between DATEADD(MINUTE,-30,'" + datum + " " + vreme + "') and DATEADD(MINUTE,30,'" + datum + " " + vreme + "')";
            termini = komunikacija.vratiTermineZaUslov(termin);

            if(termini != null && termini.Count > 0)
            {
                int i = 0;
                int j = 0; ;
                bool signal = true;
                foreach(Termin t in termini)
                { if(!t.Equals(termin))
                    { signal = false;
                        j = i;
                    }
                    i++;
                }
                if (!signal)
                {
                    MessageBox.Show("Imate zakazanu " + termini[j].VrstaTermina + " u " + termini[j].DatumIvreme.ToString("HH:mm"));
                    return false;
                }
            }

            if (komunikacija.izmeniTermin(termin) != null)
            {
                MessageBox.Show("Uspešno ste izmenili termin!");
                return true;
            }
            else { MessageBox.Show("Izmena termina nije uspela!"); return false; }
        }

        internal void prikaziTermine(DataGridView gridRaspored, List<Termin> lista)
        {
            if (lista == null || lista.Count == 0)
            {
                termin = new Termin();
                lista = komunikacija.vratiSveTermine(termin);
            }
            if (lista == null)
            {
                MessageBox.Show("Ne mozemo da ucitamo termine!");
            }
            if (lista.Count == 0)
            {
                MessageBox.Show("Ne postoji lista termina");
            }
            gridRaspored.DataSource = new BindingList<Termin>(lista);
        }
        
///Srediti
        internal void vratiTermineZaUslov(DataGridView gridTermini)
        {
            List<Termin> lista = new List<Termin>();

            termin = new Termin();
                lista = komunikacija.vratiTermineZaUslov(termin);
            
            if (lista == null)
            {
                MessageBox.Show("Ne mozemo da ucitamo termine!");
            }
            if (lista.Count == 0)
            {
                MessageBox.Show("Ne postoji lista termina");
            }
            gridTermini.DataSource = new BindingList<Termin>(lista);
        }

        internal void prikaziTermineZaDatum(DataGridView gridRaspored, DateTimePicker dateTimePicker)
        {
            termin = new Termin();
            termin.USLOVI = " DatumIVreme >= '" + dateTimePicker.Value.ToString("yyyy-MM-dd 00:00") + "' AND DatumIVreme <= '" + dateTimePicker.Value.ToString("yyyy-MM-dd 23:59") + "'";
            List<Termin> lista = komunikacija.vratiTermineZaUslov(termin);

            if (lista == null)
            {
                MessageBox.Show("Ne mozemo da ucitamo termine!");
            }
            if (lista.Count == 0)
            {
                MessageBox.Show("Ne postoji lista termina");
            }
            gridRaspored.DataSource = lista;
            gridRaspored.Columns["DatumIVreme"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        internal List<Veterinar> vratiSveVeterinare()
        {
            Veterinar vet = new Veterinar();
            return komunikacija.vratiSveVeterinare(vet);
        }

        internal void popuniFormu(TextBox txtImeLjubimca, ComboBox cmbZivotinje, TextBox txtRasa, TextBox txtStarost, TextBox txtBoja, RadioButton rbMuski, RadioButton rbZenski, TextBox txtImeVlasnika, TextBox txtPrezimeVlasnika, TextBox txtEmail, TextBox txtTelefon, TextBox txtId, Button btn, Ljubimac lj, TextBox txtJmbg, TextBox txtZanimanje, TextBox txtNapomena)
        {
            vlasnik = new Vlasnik();
            vlasnik.Id = lj.Vlasnik.Id;
            vlasnik = komunikacija.pronadjiVlasnika(vlasnik)as Vlasnik;

            txtId.Text = lj.Id.ToString();
            txtImeLjubimca.Text = lj.Ime;
            cmbZivotinje.SelectedIndex = cmbZivotinje.FindStringExact(lj.Zivotinja.Vrsta); ////////////////////////////////////////////////
            txtRasa.Text = lj.Rasa;
            txtStarost.Text = lj.Starost.ToString();
            txtBoja.Text = lj.Boja;
            if (lj.Pol == "M")
                rbMuski.Checked = true;
            if (lj.Pol == "Z")
                rbZenski.Checked = true;
            txtImeVlasnika.Text = lj.Vlasnik.Ime;
            txtPrezimeVlasnika.Text = lj.Vlasnik.Prezime;
            txtEmail.Text = lj.Vlasnik.Email;
            txtTelefon.Text = lj.Vlasnik.Telefon;
            txtJmbg.Text = lj.Vlasnik.Id.ToString();
            txtZanimanje.Text = vlasnik.Zanimanje.ToString();
            txtNapomena.Text = vlasnik.Napomena.ToString();
        }

        internal bool IzmeniLjubimca(TextBox txtIDljub, TextBox txtImeLjubimca, ComboBox cmbZivotinje, TextBox txtRasa, TextBox txtStarost, TextBox txtBoja, string pol, TextBox txtImeVlasnika, TextBox txtPrezimeVlasnika, TextBox txtEmail, TextBox txtTelefon, TextBox txtJmbg, TextBox txtZanimanje, TextBox txtNapomena, bool odgovor)
        {
            Ljubimac lj = new Ljubimac();

            lj.Id = Convert.ToInt32(txtIDljub.Text);

            if (txtImeLjubimca.Text == "")
            {
                MessageBox.Show("Unesite ime ljubimca!");
                txtImeLjubimca.Focus();
                return false;
            }
            else
            {
                lj.Ime = txtImeLjubimca.Text;
            }

            if (txtRasa.Text == "")
            {
                MessageBox.Show("Unesite rasu ljubimca!");
                txtRasa.Focus();
                return false;
            }
            else
            {
                lj.Rasa = txtRasa.Text;
            }

            if (cmbZivotinje.SelectedItem == null)
            {
                MessageBox.Show("Izaberite vrstu zivotinje");
                cmbZivotinje.Focus();
                return false;
            }
            else
            {
                lj.Zivotinja = cmbZivotinje.SelectedItem as Zivotinja;
            }

            if (txtStarost.Text == "")
            {
                MessageBox.Show("Unesite starost ljubimca!");
                txtStarost.Focus();
                return false;
            }
            else
            {
                try
                {
                    lj.Starost = Convert.ToInt32(txtStarost.Text.Trim());
                    if(lj.Starost <= 0)
                    {
                        MessageBox.Show("Niste uneli starost u odgovarajucem formatu.");
                        return false;
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Niste uneli starost u odgovarajucem formatu.");
                }
            }

            if (txtBoja.Text == "")
            {
                MessageBox.Show("Unesite boju ljubimca!");
                txtBoja.Focus();
                return false;
            }
            else
            {
                lj.Boja = txtBoja.Text;
            }
            if (pol == "")
            {
                MessageBox.Show("Izaberite pol ljubimca!");
                return false;
            }
            else
            {
                lj.Pol = pol;
            }

           
            lj.Vlasnik = new Vlasnik(); ;

            if (txtImeVlasnika.Text == "")
            {
                MessageBox.Show("Unesite ime vlasnika!");
                txtImeVlasnika.Focus();
                return false;
            }
            else
            {
                lj.Vlasnik.Ime = txtImeVlasnika.Text;
            }

            if (txtPrezimeVlasnika.Text == "")
            {
                MessageBox.Show("Unesite prezime vlasnika!");
                txtPrezimeVlasnika.Focus();
                return false;
            }
            else
            {
                lj.Vlasnik.Prezime = txtPrezimeVlasnika.Text;
            }

            if (txtTelefon.Text == "")
            {
                MessageBox.Show("Unesite kontakt telefon vlasnika!");
                txtTelefon.Focus();
                return false;
            }
            else
            {
                lj.Vlasnik.Telefon = txtTelefon.Text;
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Unesite email vlasnika!");
                txtEmail.Focus();
                return false;
            }
            else
            {
                lj.Vlasnik.Email = txtEmail.Text;
            }

            if (txtZanimanje.Text == "")
            {
                MessageBox.Show("Unesite zanimanje vlasnika!");
                txtEmail.Focus();
                return false;
            }
            else
            {
                lj.Vlasnik.Zanimanje = txtZanimanje.Text;
            }

            lj.Vlasnik.Napomena = txtNapomena.Text;
            if (txtJmbg.Text == "")
            {
                MessageBox.Show("Unesite JMBG vlasnika!");
                txtStarost.Focus();
                return false;
            }
            else
            {
                try
                {
                    lj.Vlasnik.Id = Convert.ToInt32(txtJmbg.Text.Trim());
                    if (lj.Starost <= 0)
                    {
                        MessageBox.Show("Niste uneli JMBG u odgovarajucem formatu.");
                        return false;
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Niste uneli JMBG u odgovarajucem formatu.");
                }
            }
            object rezLJ;
            object rezV;

            //*******************************************************
            if (odgovor)
            {
                rezLJ = komunikacija.izmeniLjubimca(lj);
                rezV = komunikacija.izmeniVlasnika(lj.Vlasnik);
                if (rezLJ == null && rezV == null)
                {
                    return false;
                }
                else return true;
            }
            else 
            {
                rezLJ = komunikacija.izmeniLjubimca(lj);
                if (rezLJ == null)
                {
                    return false;
                }else
                return true;
            }

           
        }

        internal void pronadjiLjubimce(TextBox txtPretraga, DataGridView gridLjubimci)
        {
            ljubimac = new Ljubimac();
            ljubimac.USLOVI = " Ime like '" + txtPretraga.Text + "%' or Rasa like '" + txtPretraga + "%'";
            List<Ljubimac> lista = komunikacija.pronadjiLjubimca(ljubimac);
            gridLjubimci.DataSource = lista;
        }

        //internal void pronadjiLjubimce(Vlasnik vlasnik, DataGridView gridLjubimci)
        //{
        //    ljubimac = new Ljubimac();
        //    ljubimac.USLOVI = " IDVlasnik like '" + txtPretraga.Text + "%' or Rasa like '" + txtPretraga + "%'";
        //    List<Ljubimac> lista = komunikacija.pronadjiLjubimca(ljubimac);
        //    gridLjubimci.DataSource = lista;
        //}

        internal void prikaziLjubimce(DataGridView gridLjubimci, Vlasnik vlasnik)
        {
            ljubimac = new Ljubimac();
            List<Ljubimac> lista = new List<Ljubimac>();

            if (vlasnik != null)
            {
                ljubimac.USLOVI = " IDVlasnik = " + vlasnik.Id;
                lista = komunikacija.pronadjiLjubimca(ljubimac);
                return;
            }

            lista = komunikacija.ucitajSveLjubimce(ljubimac);

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

        internal bool sacuvajLjubimca(TextBox txtImeLjubimca, ComboBox cmbZivotinje, TextBox txtRasa, TextBox txtStarost, TextBox txtBoja, string pol, TextBox txtImeVlasnika, TextBox txtPrezimeVlasnika, TextBox txtEmail, TextBox txtTelefon, int id, TextBox txtJmbg, TextBox txtZanimanje)
        {

            ljubimac = new Ljubimac();

            ljubimac.Id = id;

            if (txtImeLjubimca.Text == "")
            {
                MessageBox.Show("Unesite ime ljubimca!");
                txtImeLjubimca.Focus();
                return false;
            } else
            {
                ljubimac.Ime = txtImeLjubimca.Text;
            }

            if (txtRasa.Text == "")
            {
                MessageBox.Show("Unesite rasu ljubimca!");
                txtRasa.Focus();
                return false;
            }
            else
            {
                ljubimac.Rasa = txtRasa.Text;
            }

            if (cmbZivotinje.SelectedItem == null)
            {
                MessageBox.Show("Izaberite vrstu zivotinje");
                cmbZivotinje.Focus();
                return false;
            }
            else
            {
                ljubimac.Zivotinja = cmbZivotinje.SelectedItem as Zivotinja;
            }

            if (txtStarost.Text == "")
            {
                MessageBox.Show("Unesite starost ljubimca!");
                txtStarost.Focus();
                return false;
            }
            else
            {
                try
                {
                    ljubimac.Starost = Convert.ToInt32(txtStarost.Text.Trim());
                    if (ljubimac.Starost <= 0)
                    {
                      MessageBox.Show("Niste uneli starost u odgovarajucem formatu.");
                        return false;
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Niste uneli starost u odgovarajucem formatu.");
                    return false;
                }
            }

            if (txtBoja.Text == "")
            {
                MessageBox.Show("Unesite boju ljubimca!");
                txtBoja.Focus();
                return false;
            }
            else
            {
                ljubimac.Boja = txtBoja.Text;
            }
            if (pol == "")
            {
                MessageBox.Show("Izaberite pol ljubimca!");
                return false;
            }
            else
            {
                ljubimac.Pol = pol;
            }


            ljubimac.Vlasnik = new Vlasnik();

           
            if (txtImeVlasnika.Text == "")
            {
                MessageBox.Show("Unesite ime vlasnika!");
                txtImeVlasnika.Focus();
                return false;
            }
            else
            {
                ljubimac.Vlasnik.Ime = txtImeVlasnika.Text;
            }

            if (txtPrezimeVlasnika.Text == "")
            {
                MessageBox.Show("Unesite prezime vlasnika!");
                txtPrezimeVlasnika.Focus();
                return false;
            }
            else
            {
                ljubimac.Vlasnik.Prezime = txtPrezimeVlasnika.Text;
            }

            if (txtTelefon.Text == "")
            {
                MessageBox.Show("Unesite kontakt telefon vlasnika!");
                txtTelefon.Focus();
                return false;
            }
            else
            {
                ljubimac.Vlasnik.Telefon = txtTelefon.Text;
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Unesite email vlasnika!");
                txtEmail.Focus();
                return false;
            }
            else
            {
                ljubimac.Vlasnik.Email = txtEmail.Text;
            }

            if (txtZanimanje.Text == "")
            {
                MessageBox.Show("Unesite zanimanje vlasnika!");
                txtZanimanje.Focus();
                return false;
            }
            else
            {
                ljubimac.Vlasnik.Zanimanje = txtZanimanje.Text;
            }

            try
            {
                ljubimac.Vlasnik.Id = Convert.ToInt32(txtJmbg.Text);
                if (ljubimac.Vlasnik.Id <= 0)
                {
                    MessageBox.Show("Niste uneli JMBG u odgovarajucem formatu.");
                    return false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "Niste uneli jmbg u odgovarajućem formatu!");
                return false;
            }

            ljubimac.Vlasnik.Zanimanje = txtZanimanje.Text;
            object rez;
            object rezVl;

            if (komunikacija.pronadjiVlasnika(ljubimac.Vlasnik) != null)
            {
                MessageBox.Show("Vlasnik vec postoji u bazi!");
                 rez = komunikacija.sacuvajLjubimca(ljubimac);
                if (rez != null)
                {
                    ljubimac.Vlasnik.Ljubimci.Add(ljubimac);
                    MessageBox.Show("Uspesno ste uneli ljubimca!");
                    return true;
                }
            }
            else 
            {
                
                    rezVl = komunikacija.sacuvajVlasnika(ljubimac.Vlasnik);

                    if (rezVl != null)
                    {
                        rez = komunikacija.sacuvajLjubimca(ljubimac);
                        if (rez != null)
                        {
                        ljubimac.Vlasnik.Ljubimci.Add(ljubimac);
                        MessageBox.Show("Uspesno ste uneli ljubimca!");
                            return true;
                        } else { MessageBox.Show("Došlo je do greške prilikom unosa ljubimca!"); return false; }
                    } else { MessageBox.Show("Došlo je do greške prilikom unosa vlasnika!"); return false; }
                 
            }


            return false;
        }

        internal void izmeniLjubimca(DataGridViewRow currentRow)
        {
            ljubimac = new Ljubimac();
            ljubimac.Ime = currentRow.Cells[2].Value.ToString();
           // MessageBox.Show(ljubimac.Ime);
            ljubimac.Starost = Convert.ToInt32(currentRow.Cells[3].Value.ToString());
            ljubimac.Pol = currentRow.Cells[4].Value.ToString();
            ljubimac.Boja = currentRow.Cells[5].Value.ToString();
            ljubimac.Rasa = currentRow.Cells[7].Value.ToString();
            

            ljubimac.Zivotinja = new Zivotinja();
            ljubimac.Zivotinja.Vrsta = currentRow.Cells[8].Value.ToString();

            //ljubimac.Veterinar = new Veterinar();
            //ljubimac.Veterinar.Ime = currentRow.Cells[7].Value.ToString().Split(' ')[0];
            //ljubimac.Veterinar.Prezime = currentRow.Cells[7].Value.ToString().Split(' ')[1];

            ljubimac.Vlasnik = new Vlasnik();
            ljubimac.Vlasnik.Ime = currentRow.Cells[6].Value.ToString().Split(' ')[0];
            ljubimac.Vlasnik.Prezime = currentRow.Cells[6].Value.ToString().Split(' ')[1];

            

            ljubimac.USLOVI = "lj.Ime = '" + ljubimac.Ime + "' and o.Ime = '" + ljubimac.Vlasnik.Ime + "' and o.Prezime = '" + ljubimac.Vlasnik.Prezime + /*"' and oo.Ime = '" +ljubimac.Veterinar.Ime + "' and oo.Prezime = '" + ljubimac.Veterinar.Prezime + */"'";

            if (komunikacija.pronadjiLjubimcaIzTabele(ljubimac) == null)
            {
                MessageBox.Show("Doslo je do greske");
            }
            else
            {
                new FrmUnesiNovogLjubimca(komunikacija.pronadjiLjubimcaIzTabele(ljubimac)).ShowDialog();

            }

        }

        internal bool obrisiLjubimca(DataGridViewRow currentRow)
        {
            ljubimac = new Ljubimac();
            termin = new Termin();
            vlasnik = new Vlasnik();
            List<Termin> termini = new List<Termin>();
            List<Ljubimac> ljubimci = new List<Ljubimac>();

            ljubimac.Ime = currentRow.Cells[2].Value.ToString();
            // MessageBox.Show(ljubimac.Ime);
            ljubimac.Starost = Convert.ToInt32(currentRow.Cells[3].Value.ToString());
            ljubimac.Pol = currentRow.Cells[4].Value.ToString();
            ljubimac.Boja = currentRow.Cells[5].Value.ToString();
            ljubimac.Rasa = currentRow.Cells[7].Value.ToString();


            ljubimac.Zivotinja = new Zivotinja();
            ljubimac.Zivotinja.Vrsta = currentRow.Cells[8].Value.ToString();

            //ljubimac.Veterinar = new Veterinar();
            //ljubimac.Veterinar.Ime = currentRow.Cells[7].Value.ToString().Split(' ')[0];
            //ljubimac.Veterinar.Prezime = currentRow.Cells[7].Value.ToString().Split(' ')[1];

            ljubimac.Vlasnik = new Vlasnik();
            ljubimac.Vlasnik.Ime = currentRow.Cells[6].Value.ToString().Split(' ')[0];
            ljubimac.Vlasnik.Prezime = currentRow.Cells[6].Value.ToString().Split(' ')[1];

            ljubimac.USLOVI = " lj.Ime = '" + ljubimac.Ime + "' and lj.Rasa = '" + ljubimac.Rasa + "' and o.Ime = '" + ljubimac.Vlasnik.Ime + "' and o.Prezime = '" + ljubimac.Vlasnik.Prezime + /*"' and oo.Ime = '" + ljubimac.Veterinar.Ime + "' and oo.Prezime = '" + ljubimac.Veterinar.Prezime + */"'";
            ljubimac = komunikacija.pronadjiLjubimcaIzTabele(ljubimac);

            termin.USLOVI = " IDLjubimac = " + ljubimac.Id;
            if (komunikacija.vratiTermineZaUslov(termin) != null && komunikacija.vratiTermineZaUslov(termin).Count>0)
            {
                MessageBox.Show("Nije moguće izbrisati ljubimca! Postoje termini za izabranog ljubimca!");
                new FrmRaspored(komunikacija.vratiTermineZaUslov(termin)).ShowDialog();
                return false;
            }
            vlasnik = ljubimac.Vlasnik;
            if (ljubimac.Id != 0 && ljubimac.Vlasnik.Id != 0 && termini.Count == 0)
            {
                ljubimac.USLOVI = " IDVlasnik = " + ljubimac.Vlasnik.Id;
                if (komunikacija.pronadjiLjubimca(ljubimac).Count > 1)
                {
                    MessageBox.Show("Vlasnik ima još ljubimaca.");
                    try
                    {
                        komunikacija.obrisiLjubimca(ljubimac);
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
                        komunikacija.obrisiLjubimca(ljubimac);
                        komunikacija.obrisiVlasnika(vlasnik);
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

        

        internal bool pronadjiVeterinara(TextBox txtUsername, TextBox txtPassword)
        {
            veterinar = new Veterinar();
            veterinar.Username = txtUsername.Text;
            veterinar.Password = txtPassword.Text;

            veterinar.USLOV = " Username = '" + veterinar.Username + "' and Password = '" + veterinar.Password + "'";
            veterinar = komunikacija.pronadjiVeterinara(veterinar) as Veterinar;

            if(veterinar == null)
            {
                MessageBox.Show("Ne postoji uneti veterinar!");
                return false;
            }
            else
            {
                MessageBox.Show("Uspesno ste se prijavili na sistem!");
                return true;
            }
        }

        internal Ljubimac kreirajLjubimca(TextBox txtIDljub, Button btnKreirajIDLj)
        {
            ljubimac = new Ljubimac();
            ljubimac =  komunikacija.kreirajLjubimca(ljubimac);

            if(ljubimac == null)
            {
                MessageBox.Show("Nije moguće kreirati ljubimca :(");
                return null;
            }
            else
            {
                txtIDljub.Text = ljubimac.Id.ToString();
                btnKreirajIDLj.Enabled = false;
                return ljubimac;
            }
        }

        internal void vratiDanasnjeTermine(DataGridView gridTermini)
        {
            termin = new Termin();
            termin.USLOVI = " DatumIVreme >= '" + DateTime.Now.ToString("yyyy-MM-dd 00:00") + "' and DatumIVreme <= '" + DateTime.Now.ToString("yyyy-MM-dd 23:59") + "'";
            List<Termin> lista = komunikacija.vratiTermineZaUslov(termin);

            BindingList<Termin> termini = new BindingList<Termin>(lista);
            gridTermini.DataSource = termini;
            gridTermini.Columns["DatumIVreme"].DefaultCellStyle.Format = "dd.MM.yyyy";
            gridTermini.Columns["Opis"].Visible = false;

        }


    }
    }

