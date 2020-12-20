using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

namespace Domen
{
    [Serializable]
    public class Vlasnik: Osoba
    {
        //int id;
        //string ime;
        //string prezime;
        //string telefon;
        //string email;

        //public int Id { get => id; set => id = value; }
        //public string Ime { get => ime; set => ime = value; }
        //public string Prezime { get => prezime; set => prezime = value; }
        //public string Telefon { get => telefon; set => telefon = value; }
        //public string Email { get => email; set => email = value; }

        string zanimanje;
        string napomena;
        List<Ljubimac> ljubimci;

        public Vlasnik()
        {
            Ljubimci = new List<Ljubimac>();
        }

        public List<Ljubimac> Ljubimci { get => ljubimci; set => ljubimci = value; }
        public string Zanimanje { get => zanimanje; set => zanimanje = value; }
        public string Napomena { get => napomena; set => napomena = value; }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }


        #region ODO
        [Browsable(false)]
        public override string ID
        {
            get { return "ID"; }
        }
        public override string NazivTabele
        {
            get { return "Vlasnik"; }
        }

        public override string UslovID
        {
            get { return "ID =" + Id; }
        }
       // public string USLOVI;
        
        [Browsable(false)]
        public override string UslovOpsti
        {
            get { return USLOVI; }
        }
        [Browsable(false)]
        public override string UslovSort
        {
            get { return " ID"; }
        }

        public override string Insert
        {
            get { return " values (" +Id+ ",'" +zanimanje+"', '" + napomena + "')"; }
            
        }

        public override string Update
        {
            get
            {
                return "Zanimanje = '" + zanimanje + "', Napomena = '" + napomena + "'";
            }
        }

        public override string Update2
        {
            get { return ""; }
        }

        public override OpstiDomenskiObjekat procitajRed(DataRow red)
        {
            Vlasnik v = new Vlasnik();
            v.Id = Convert.ToInt32(red["ID"]);
            //v.Ime = red["Ime"].ToString();
            //v.Prezime = red["Prezime"].ToString();
            //v.Telefon = red["Telefon"].ToString();
            //v.Email = red["Email"].ToString();
            v.zanimanje = red["Zanimanje"].ToString();
            v.napomena = red["Napomena"].ToString();

            return v;
        }
        #endregion

       




    }

   
}
