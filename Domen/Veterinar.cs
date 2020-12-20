using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Veterinar : Osoba
    {
        //int id;
        //string ime;
        //string prezime;
        string username;
        string password;
        string specijalizacija;
        //string telefon;
        //string email;

        //public int Id { get => id; set => id = value; }

        //public string Ime { get => ime; set => ime = value; }
        //public string Prezime { get => prezime; set => prezime = value; }
        //public string Telefon { get => telefon; set => telefon = value; }
        //public string Email { get => email; set => email = value; }
        public string Specijalizacija { get => specijalizacija; set => specijalizacija = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }







        public override string ID
        {
            get { return "ID"; }
        }
        public override string NazivTabele
        {
            get { return "Veterinar"; }
        }

        public override string UslovID
        {
            get { return "ID =" + Id; }
        }

        public string USLOV;
        public override string UslovOpsti
        {
            get { return USLOV; }
        }
        public override string UslovSort
        {
            get { return " ID"; }
        }
        public override string Insert
        {
            get { return " "; }
        }

        public override string Update => throw new NotImplementedException();

        public override string Update2 => throw new NotImplementedException();

        public override OpstiDomenskiObjekat procitajRed(DataRow red)
        {
            Veterinar v = new Veterinar();
            v.Id = Convert.ToInt32(red["ID"]);
           // v.Ime = red["Ime"].ToString();
           // v.Prezime = red["Prezime"].ToString();
            v.username = red["Username"].ToString();
            v.password = red["Password"].ToString();
            v.specijalizacija = red["Specijalizacija"].ToString();
          //  v.Telefon = red["Telefon"].ToString();
          //  v.Email = red["Email"].ToString();

            return v;
        }



    }
}
