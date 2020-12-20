using Domen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sesija
{
    public class Broker
    {

        SqlConnection konekcija;
        SqlTransaction transakcija;
        SqlCommand komanda;

       

        SqlDataReader citac;

        private Broker()
        {
            konektujSe();
        }

        static Broker instanca;
        void konektujSe()
        {
            konekcija = new SqlConnection(@"Data Source=DESKTOP-LI8IUG3;Initial Catalog=VeterinarskaOrdinacija;Integrated Security=True");
            komanda = konekcija.CreateCommand();
        }

        public static Broker vratiKonekciju()
        {
            if (instanca == null)
            { instanca = new Broker(); }

            return instanca;
        }
        public void potvrdiTransakciju()
        {
            try
            {
                transakcija.Commit();
            }
            catch (Exception)
            {

                MessageBox.Show("Nije moguće potvrditi transakciju");
            }
        }
        public void zapocniTransakciju()
        {
            try
            {
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("", konekcija, transakcija);
            }
            catch (Exception)
            {

                MessageBox.Show("Nije moguće započeti transakciju!");
            }
        }

        

        public void ponistiTransakciju()
        {
            try
            {
                transakcija.Rollback();
            }
            catch (Exception)
            {

                MessageBox.Show("Nije moguće poništiti transakciju!");
            }
        }
        public void zatvoriKonekciju()
        {
            try
            {
                konekcija.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Nije moguće zatvoriti konekciju sa bazom!");
            }
        }
        public void otvoriKonekciju()
        {
            try
            {
                konekcija = new SqlConnection(@"Data Source=DESKTOP-LI8IUG3;Initial Catalog=VeterinarskaOrdinacija;Integrated Security=True");
                konekcija.Open();
            }
            catch (Exception)
            {

                MessageBox.Show("Ne može da se uspostavi konekcija sa bazom!");
            }
        }
        public int updateJedan(OpstiDomenskiObjekat odo)
        {
            try
            {
                komanda.CommandText = "Update " + odo.NazivTabele + " set " + odo.Update + " where " + odo.UslovID;
                return komanda.ExecuteNonQuery();

                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int update2(OpstiDomenskiObjekat odo)
        {
            try
            {
                komanda.CommandText = "Update " + odo.NazivTabele + " set " + odo.Update2 + " where " + odo.UslovID;
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool deleteJedan(OpstiDomenskiObjekat odo)
        {
            try
            {
                komanda.CommandText = "Delete from " + odo.NazivTabele + " where " + odo.UslovID;
                komanda.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public void deleteVise(OpstiDomenskiObjekat odo)
        {
            try
            {
                komanda.CommandText = "Delete from " + odo.NazivTabele + " where " + odo.UslovOpsti;
                komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<OpstiDomenskiObjekat> vratiSVe(OpstiDomenskiObjekat odo)
        {
            List<OpstiDomenskiObjekat> lista = new List<OpstiDomenskiObjekat>();
            try
            {
                komanda.CommandText = "Select * from " + odo.NazivTabele + " order by " + odo.UslovSort;
                citac = komanda.ExecuteReader();
                DataTable tabela = new DataTable();
                tabela.Load(citac);

                foreach(DataRow red in tabela.Rows)
                {
                    lista.Add(odo.procitajRed(red));
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {
                citac.Close();
                throw;
            }
        }
        public List<OpstiDomenskiObjekat> vratiSveZaUslovOpsti(OpstiDomenskiObjekat odo)
        {
            List<OpstiDomenskiObjekat> lista = new List<OpstiDomenskiObjekat>();
            try
            {
                komanda.CommandText = "Select * from " + odo.NazivTabele + " where " + odo.UslovOpsti + " order by " + odo.UslovSort;
                citac = komanda.ExecuteReader();
                DataTable tabela = new DataTable();
                tabela.Load(citac);
                foreach (DataRow red in tabela.Rows)
                {
                    lista.Add(odo.procitajRed(red));
                }

                citac.Close();
                return lista;
            }
            catch (Exception)
            {
                citac.Close();
                throw;
            }
        }
        public OpstiDomenskiObjekat vratiJedanZaUslovOpsti(OpstiDomenskiObjekat odo)
        {
            try
            {
                komanda.CommandText = "Select * from " + odo.NazivTabele + " where " + odo.UslovOpsti;
                citac = komanda.ExecuteReader();
                DataTable tabela = new DataTable();
                tabela.Load(citac);
                citac.Close();

                if (tabela.Rows.Count == 0)
                {
                    return null;
                }
                else {
                    return odo.procitajRed(tabela.Rows[0]);
                }
            }
            catch (Exception)
            {
                citac.Close();
                throw;
            }
        }
        public OpstiDomenskiObjekat vratiJedanZaID(OpstiDomenskiObjekat odo)
        {
            try
            {
                komanda.CommandText = "Select * from " + odo.NazivTabele + " where " + odo.UslovID;
                citac = komanda.ExecuteReader();
                DataTable tabela = new DataTable();
                tabela.Load(citac);
                citac.Close();
                if(tabela.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return odo.procitajRed(tabela.Rows[0]);
                }
            }
            catch (Exception)
            {
                citac.Close();
                throw;
            }
        }
        public int vratiID(OpstiDomenskiObjekat odo)
        {
            try
            {
                komanda.CommandText = "Select max(" + odo.ID + ") From " + odo.NazivTabele;
                try
                {
                    return Convert.ToInt32(komanda.ExecuteScalar()) + 1;
                }
                catch (Exception)
                {

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void insert(OpstiDomenskiObjekat odo)
        {
            try
            {
                komanda.CommandText = "Insert into " + odo.NazivTabele + " " + odo.Insert;
                komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw new Exception ("Greska u radu sa bazom");
            }
        }

        public object vratiLjubimcaIzTabele(OpstiDomenskiObjekat odo)
        {
            try
            {
                komanda.CommandText = "Select z.Vrsta, lj.*, o.Ime, o.Prezime, o.Telefon, o.Email, v.Zanimanje from Zivotinja z join Ljubimac lj on z.ID = lj.IDZivotinja join Osoba o on lj.IDVlasnik = o.ID join Vlasnik v on o.ID = v.ID where " + odo.UslovOpsti;
                citac = komanda.ExecuteReader();
                Ljubimac lj = new Ljubimac();

                while (citac.Read())
                {
                    lj.Id = Convert.ToInt32(citac[1]);
                    lj.Ime = citac[2].ToString();
                    lj.Boja = citac[5].ToString();
                    lj.Pol = citac[4].ToString();
                    lj.Starost = Convert.ToInt32(citac[3]);

                    lj.Vlasnik = new Vlasnik();
                    lj.Vlasnik.Id = Convert.ToInt32(citac[7]);
                    lj.Vlasnik.Ime = citac[9].ToString();
                    lj.Vlasnik.Prezime = citac[10].ToString();
                    lj.Vlasnik.Telefon = citac[11].ToString();
                    lj.Vlasnik.Email = citac[12].ToString();
                    lj.Vlasnik.Zanimanje = citac[13].ToString();
                    

                    //lj.Veterinar = new Veterinar();
                    //lj.Veterinar.Jmbg = Convert.ToInt32(citac[8]);
                    //lj.Veterinar.Ime = citac[15].ToString();
                    //lj.Veterinar.Prezime = citac[16].ToString();
                    //lj.Veterinar.Telefon = citac[17].ToString();
                    //lj.Veterinar.Telefon = citac[17].ToString();

                    lj.Rasa = citac[6].ToString();
                    lj.Zivotinja = new Zivotinja();
                    lj.Zivotinja.Id = Convert.ToInt32(citac[8]);
                    lj.Zivotinja.Vrsta = citac[0].ToString();

                }
                citac.Close();
                return lj;

            }
            catch (Exception)
            {
                citac.Close();
                throw;
            }
        }


        public List<OpstiDomenskiObjekat> vratiTermineJoin(OpstiDomenskiObjekat odo)
        {
            try
            {
                komanda.CommandText = "Select * from Termin t join Ljubimac lj on t.IDLjubimac = lj.ID join Vlasnik v on lj.IDVlasnik = v.JMBG join Zivotinja z on z.ID = lj.IDZivotinja where " + odo.UslovOpsti;
                citac = komanda.ExecuteReader();
                Termin t = new Termin();
                List<OpstiDomenskiObjekat> termini = new List<OpstiDomenskiObjekat>();

                while (citac.Read())
                {
                    t.Id = Convert.ToInt32(citac[0]); 
                    t.DatumIvreme = Convert.ToDateTime(citac[3]);
                    t.Sala = new Sala();
                    t.Sala.Id = Convert.ToInt32(citac[4]);

                    t.Opis = citac[5].ToString();

                    t.Ljubimac = new Ljubimac();
                    t.Ljubimac.Id = Convert.ToInt32(citac[1]);
                    t.Ljubimac.Ime = citac[7].ToString();
                    t.Ljubimac.Boja = citac[10].ToString();
                    t.Ljubimac.Pol = citac[9].ToString();
                    t.Ljubimac.Starost = Convert.ToInt32(citac[8]);

                    t.Ljubimac.Vlasnik = new Vlasnik();
                    t.Ljubimac.Vlasnik.Id = Convert.ToInt32(citac[12]);
                    t.Ljubimac.Vlasnik.Ime = citac[16].ToString();
                    t.Ljubimac.Vlasnik.Prezime = citac[17].ToString();
                    t.Ljubimac.Vlasnik.Telefon = citac[18].ToString();
                    t.Ljubimac.Vlasnik.Email = citac[19].ToString();

                    //t.Ljubimac.Veterinar = new Veterinar();
                    //t.Ljubimac.Veterinar.Jmbg = Convert.ToInt32(citac[2]);
                    


                    t.Ljubimac.Rasa = citac[11].ToString();
                    t.Ljubimac.Zivotinja = new Zivotinja();
                    t.Ljubimac.Zivotinja.Id = Convert.ToInt32(citac[16]);
                    t.Ljubimac.Zivotinja.Vrsta = citac[21].ToString();


                }
                citac.Close();
                return termini;
            }
            catch
            {
                throw;
            }
        }

        public List<OpstiDomenskiObjekat> vratiOsobeVlasnik(OpstiDomenskiObjekat odo)
        {
            try
            {
                Vlasnik vlasnik = new Vlasnik();
                List<OpstiDomenskiObjekat> lista = new List<OpstiDomenskiObjekat>();
                komanda.CommandText = "Select * from Vlasnik v join Osoba o on v.ID = o.ID where " + odo.UslovOpsti;
                citac = komanda.ExecuteReader();
                while(citac.Read())
                {
                    vlasnik.Id = Convert.ToInt32(citac["ID"]);
                    vlasnik.Ime = citac["Ime"].ToString();
                    vlasnik.Prezime = citac["Prezime"].ToString();
                    vlasnik.Telefon = citac["Telefon"].ToString();
                    vlasnik.Email = citac["Email"].ToString();
                    vlasnik.Zanimanje = citac["Zanimanje"].ToString();
                    vlasnik.Napomena = citac["Napomena"].ToString();

                    lista.Add(vlasnik);
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                throw;
            }

        }






        //public List<OpstiDomenskiObjekat> vratiTermineProba(OpstiDomenskiObjekat odo)
        //{
        //    try
        //    {
        //        komanda.CommandText = "z.Vrsta, t.* from Zivotinja z join Ljubimac lj on z.ID = lj.IDZivotinja join Termin t on lj.ID = t.IDLjubimac";
        //        citac = komanda.ExecuteReader();
        //        Termin t = new Termin();
        //        List<OpstiDomenskiObjekat> termini = new List<OpstiDomenskiObjekat>();

        //        while (citac.Read())
        //        {
        //            t.Ljubimac = new Ljubimac();
        //            t.Ljubimac.Zivotinja = new Zivotinja();
        //            t.Ljubimac.Vlasnik = new Vlasnik();

        //            t.Ljubimac.Id = Convert.ToInt32(citac[4]);
        //            t.Ljubimac.Ime = citac[0].ToString();
        //            t.Ljubimac.Vlasnik.Id = Convert.ToInt32(citac["IDVlasnik"]);


        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }


        //}








        //*******************************************************************************************************************

        // metode
        public Veterinar logIn(Veterinar v)
        {
            
            try
            {
                konekcija.Open();
                komanda = new SqlCommand("Select * From Veterinar Where Username = '" + v.Username + "' and Password = '" + v.Password + "'");
                komanda.Connection = konekcija;
                SqlDataReader citac = komanda.ExecuteReader();

                if (citac.Read())
                {
                    v.Id = Convert.ToInt32(citac["JMBG"]);
                    v.Ime = citac["Ime"].ToString();
                    v.Prezime = citac["Prezime"].ToString();
                    v.Specijalizacija = citac["Specijalizacija"].ToString();
                    v.Telefon = citac["Telefon"].ToString();
                    v.Email = citac["Email"].ToString();

                    return v;
                }
                citac.Close();
                return null;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if(konekcija!= null)
                konekcija.Close();
            }

        }
        public List<Termin> vratiTermine(Veterinar v)
        {
            List<Termin> termini = new List<Termin>();
            Veterinar ve = v;

            try
            {
                konekcija.Open();
                komanda = new SqlCommand("Select * From Termin Where IDVeterinar =" + ve.Id ) ;
                komanda.Connection = konekcija;
                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    Termin t = new Termin();
                    t.Id = Convert.ToInt32(citac["ID"]);
                    t.Veterinar = ve;
                    //DateTime date = DateTime.ParseExact(citac["DatumIVreme"].ToString(), "yyyy-MM-dd", null);
                    //t.DatumIvreme = date;
                    t.DatumIvreme = Convert.ToDateTime(citac["DatumIVreme"]);
                    t.Sala = new Sala();
                    t.Sala.Id = Convert.ToInt32(citac["IDSala"]);
                    t.Opis = citac["Opis"].ToString();
                    t.Ljubimac = new Ljubimac();
                    t.Ljubimac.Id = Convert.ToInt32(citac["IDLjubimac"]);

                    termini.Add(t);
                }

                citac.Close();

                foreach (Termin t in termini)
                {
                    t.Ljubimac = vratiLjubimca(t.Ljubimac.Id);
                }
                return termini;

            }
            catch (Exception)
            {

                throw;
            }
            finally { if(konekcija != null) konekcija.Close(); }

        }
        Ljubimac vratiLjubimca(int id)
        {
            Ljubimac lj = new Ljubimac();
            try
            {
                komanda = new SqlCommand("Select * From Ljubimac Where ID = " + id);
                komanda.Connection = konekcija;
                SqlDataReader citac = komanda.ExecuteReader();

                if (citac.Read())
                {
                    lj.Id = Convert.ToInt32(citac["IDZivotinja"]);
                    lj.Id = Convert.ToInt32(citac["ID"]);
                    lj.Ime = citac["Ime"].ToString();
                    lj.Boja = citac["Boja"].ToString();
                    lj.Pol = citac["Pol"].ToString();
                    lj.Starost = Convert.ToInt32(citac["Starost"]);
                    lj.Vlasnik = new Vlasnik();
                    lj.Vlasnik.Id = Convert.ToInt32(citac["IDVlasnik"]);
                    //lj.Veterinar = new Veterinar();
                    //lj.Veterinar.Jmbg = Convert.ToInt32(citac["IDVeterinar"]);
                    lj.Rasa = citac["Rasa"].ToString();
                    lj.Zivotinja = new Zivotinja();
                    lj.Zivotinja.Id = Convert.ToInt32(citac["IDZivotinja"]);

                }
                citac.Close();
               
                lj.Vlasnik = vratiVlasnika(lj.Vlasnik.Id);
                //lj.Veterinar = vratiVet(lj.Vlasnik.Jmbg);

                return lj;

            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public List<Ljubimac> vratiSveLjubimce()
        {
            List<Ljubimac> ljubimci = new List<Ljubimac>();

            try
            {
                konekcija.Open();
                komanda = new SqlCommand("Select * From Ljubimac");
                komanda.Connection = konekcija;
                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    Ljubimac lj = new Ljubimac();
                    lj.Id = Convert.ToInt32(citac["IDZivotinja"]);
                    lj.Id = Convert.ToInt32(citac["ID"]);
                    lj.Ime = citac["Ime"].ToString();
                    lj.Boja = citac["Boja"].ToString();
                    lj.Pol = citac["Pol"].ToString();
                    lj.Vlasnik = new Vlasnik();
                    lj.Vlasnik.Id = Convert.ToInt32(citac["IDVlasnik"]);
                    //lj.Veterinar = new Veterinar();
                    //lj.Veterinar.Jmbg = Convert.ToInt32(citac["IDVeterinar"]);
                    lj.Rasa = citac["Rasa"].ToString();
                    lj.Zivotinja = new Zivotinja();
                    lj.Id = Convert.ToInt32(citac["IDZivotinja"]);
                    
                    

                    ljubimci.Add(lj);
                }
                citac.Close();


                foreach (Ljubimac lj in ljubimci)
                {
                   lj.Vlasnik =  vratiVlasnika(lj.Vlasnik.Id);
                   //lj.Veterinar = vratiVet(lj.Vlasnik.Jmbg);
                   lj.Zivotinja = vratiZivotinju(lj.Zivotinja.Id);
                }
                

                return ljubimci;
                
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }

        }
        Vlasnik vratiVlasnika(int id)
        {
            Vlasnik v = new Vlasnik();
            try
            {
                komanda = new SqlCommand("Select * From Vlasnik Where ID = " + id );
                komanda.Connection = konekcija;
                SqlDataReader cit = komanda.ExecuteReader();

                if (cit.Read())
                {
                    v.Id = Convert.ToInt32(cit["ID"]);
                    v.Ime = cit["Ime"].ToString();
                    v.Prezime = cit["Prezime"].ToString();
                    v.Telefon = cit["Telefon"].ToString();
                    v.Email = cit["Email"].ToString();

                }
                cit.Close();
                return v;
            }
            catch (Exception)
            {

                throw;
            }
        }
        Zivotinja vratiZivotinju(int id)
        {
            Zivotinja z = new Zivotinja();
            try
            {
                komanda = new SqlCommand("Select * From Zivotinja Where ID = " + id);
                komanda.Connection = konekcija;
                SqlDataReader cit = komanda.ExecuteReader();

                if (cit.Read())
                {
                    z.Id = Convert.ToInt32(cit["ID"]);
                    z.Vrsta = cit["Vrsta"].ToString();

                }
                cit.Close();
                return z;
            }
            catch (Exception)
            {

                throw;
            }
        }
        Veterinar vratiVet(int id)
        {
            Veterinar v = new Veterinar();
            try
            {
                komanda = new SqlCommand("Select * From Veterinar Where JMBG = " + id);
                komanda.Connection = konekcija;
                SqlDataReader cit = komanda.ExecuteReader();

                if (cit.Read())
                {
                    v.Id = Convert.ToInt32(cit["ID"]);
                    v.Ime = cit["Ime"].ToString();
                    v.Prezime = cit["Prezime"].ToString();
                    v.Telefon = cit["Telefon"].ToString();
                    v.Email = cit["Email"].ToString();
                    v.Username = cit["Username"].ToString();
                    v.Password = cit["Password"].ToString();
                    v.Specijalizacija = cit["Specijalizacija"].ToString();
                }
                cit.Close();
                return v;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Veterinar> vratiVet()
        {
            List<Veterinar> veterinari = new List<Veterinar>();
            try
            {
                konekcija.Open();
                komanda = new SqlCommand("Select * From Veterinar  ");
                komanda.Connection = konekcija;
                SqlDataReader cit = komanda.ExecuteReader();


                while (cit.Read())
                {
                    Veterinar v = new Veterinar();
                    v.Id = Convert.ToInt32(cit["ID"]);
                    v.Ime = cit["Ime"].ToString();
                    v.Prezime = cit["Prezime"].ToString();
                    v.Telefon = cit["Telefon"].ToString();
                    v.Email = cit["Email"].ToString();
                    v.Username = cit["Username"].ToString();
                    v.Password = cit["Password"].ToString();
                    v.Specijalizacija = cit["Specijalizacija"].ToString();

                    veterinari.Add(v);
                }
                cit.Close();
                return veterinari;
            }
            catch (Exception)
            {

                throw;
            }
            finally { konekcija.Close(); }
        }
        public List<Zivotinja> vratiZivotinje()
        {

            List<Zivotinja> zivotinje = new List<Zivotinja>();
            try
            {
                konekcija.Open();
                komanda = new SqlCommand("Select * From Zivotinja");
                komanda.Connection = konekcija;
                SqlDataReader cit = komanda.ExecuteReader();


                while (cit.Read())
                {
                    Zivotinja z = new Zivotinja();
                    z.Id = Convert.ToInt32(cit["ID"]);
                    z.Vrsta = cit["Vrsta"].ToString();

                    zivotinje.Add(z);
                }
                cit.Close();
                return zivotinje;
            }
            catch (Exception)
            {

                throw;
            }
            finally { konekcija.Close(); }
        }

        public List<Termin> vratiTermine(Veterinar vet, string datum)
        {
            List<Termin> termini = new List<Termin>();
            Veterinar ve = vet;

            try
            {
                konekcija.Open();
                komanda = new SqlCommand("Select * From Termin Where IDVeterinar =" + ve.Id + "and DatumIVreme = '" + datum + "'");
                komanda.Connection = konekcija;
                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    Termin t = new Termin();
                    t.Id = Convert.ToInt32(citac["ID"]);
                    t.Veterinar = ve;
                    DateTime date = DateTime.ParseExact(citac["DatumIVreme"].ToString(), "yyyy-MM-dd", null);
                    t.DatumIvreme = date;
                    t.Sala = new Sala();
                    t.Sala.Id = Convert.ToInt32(citac["IDSala"]);
                    t.Opis = citac["Opis"].ToString();
                    t.Ljubimac = new Ljubimac();
                    t.Ljubimac.Id = Convert.ToInt32(citac["IDLjubimac"]);

                    termini.Add(t);
                }

                citac.Close();

                foreach (Termin t in termini)
                {
                    t.Ljubimac = vratiLjubimca(t.Ljubimac.Id);
                }
                return termini;

            }
            catch (Exception)
            {

                throw;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }



    }
}
