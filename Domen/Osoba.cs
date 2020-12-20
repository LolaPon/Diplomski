using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Osoba : OpstiDomenskiObjekat
    {
        int id;
        string ime;
        string prezime;
        string telefon;
        string email;

        public override string ToString()
        {
            return ime + " " + prezime;
        }

        public int Id { get => id; set => id = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Email { get => email; set => email = value; }




        public virtual string NazivTabele
        {
            get { return "Osoba"; }
        }

        public virtual string ID
        {
            get { return "ID"; }
        }

        public virtual string UslovID
        {
            get { return " ID = " + id; }
        }
        public string USLOVI;
        public virtual string UslovOpsti
        {
            get { return USLOVI; }
        }
        public virtual string UslovSort
        {
            get { return " Prezime"; }
        }

        public virtual string Insert
        {
            get
            {
                return "values (" + id + ", '" + Ime + "', '" + Prezime + "', '" + Telefon + "', '" + Email + "')";
            }
        }

        public virtual string Update
        {
            get { return "Ime = '" + ime + "', Prezime = '" + prezime + "', Telefon = '" + telefon + "', Email = '" + email + "'"; }
        }

        public virtual string Update2
        {
            get { return ""; }
        }

       

        public virtual OpstiDomenskiObjekat procitajRed(DataRow red)
        {
            Osoba o = new Osoba();
            o.Id = Convert.ToInt32(red["ID"]);
            o.Ime = red["Ime"].ToString();
            o.Prezime = red["Prezime"].ToString();
            o.Telefon = red["Telefon"].ToString();
            o.Email = red["Email"].ToString();

            return o;
        }
    }
}
