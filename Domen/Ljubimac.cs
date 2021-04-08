using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{

    
    [Serializable]
    public class Ljubimac : OpstiDomenskiObjekat 
    {
        int id;
        string ime;
        int starost;
        string pol;
        string boja;
        string rasa;
        Zivotinja zivotinja;
        Vlasnik vlasnik;
        string status;
       
        [Browsable(false)]
        public int Id { get => id; set => id = value; }
        public string Ime { get => ime; set => ime = value; }
        public int Starost { get => starost; set => starost = value; }
        public string Pol { get => pol; set => pol = value; }
        public string Boja { get => boja; set => boja = value; }
        public Vlasnik Vlasnik { get => vlasnik; set => vlasnik = value; }
        
        public string Rasa { get => rasa; set => rasa = value; }

        public string Status { get => status; set => status = value; }

        [DisplayName("Životinja")]
        public Zivotinja Zivotinja { get => zivotinja; set => zivotinja = value; }

        public override string ToString()
        {
            return ime;
        }



        #region ODO
        [Browsable(false)]
        public string NazivTabele
        {
            get { return "Ljubimac"; }
        }
        [Browsable(false)]
        public string ID
        {
            get { return "ID"; }
        }
        [Browsable(false)]
        public string UslovID
        {
            get { return "ID = " + id; }
        }
        [Browsable(false)]
        public string USLOVI;
        [Browsable(false)]
        public string UslovOpsti
        {
            get { return USLOVI; }
        }
        [Browsable(false)]
        public string UslovSort
        {
            get { return " Ime asc"; }
        }

        [Browsable(false)]
        public string Insert
        {
            get
            {
                return "values (" + id + ",'" + ime + "'," + starost + ",'" + pol + "', '" + boja + "', '" + rasa + "', " + vlasnik.Id + ", " + zivotinja.Id + ", '" + status + "')";
            }
        }
        [Browsable(false)]
        public string Update
        {
            get
            {
                return "Ime = '" + ime + "', Starost = " + starost + ", Pol = '" + pol + "', Boja = '" + boja + "', Rasa = '" + rasa + "'" + ", Status = 'Aktivan'";
            }
        }
        [Browsable(false)]
        public string Update2
        {
            get
            {
                return "Status = 'Neaktivan'";
            }
        }



        public OpstiDomenskiObjekat procitajRed(DataRow red)
        {
            Ljubimac lj = new Ljubimac();
            lj.id = Convert.ToInt32(red["ID"]);
            lj.ime = red["Ime"].ToString();
            lj.starost = Convert.ToInt32(red["Starost"]);
            lj.pol = red["Pol"].ToString();
            lj.boja = red["Boja"].ToString();
            lj.rasa = red["Rasa"].ToString();
            lj.vlasnik = new Vlasnik();
            lj.vlasnik.Id = Convert.ToInt32(red["IDVlasnik"]);
            lj.zivotinja = new Zivotinja();
            lj.zivotinja.Id = Convert.ToInt32(red["IDZivotinja"]);
            lj.status = red["Status"].ToString();

            return lj;
        }

        #endregion
    }
}
