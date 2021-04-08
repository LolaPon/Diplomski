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
            konekcija = new SqlConnection(@"Data Source=DESKTOP-LI8IUG3;Initial Catalog=VeterinarskaOrdinacija;Integrated Security=true");
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

       



    }
}
