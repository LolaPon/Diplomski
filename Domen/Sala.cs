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
    public class Sala : OpstiDomenskiObjekat
    {
        int id;
        string tip;

        public override string ToString()
        {
            return tip;
        }

        public string Tip { get => tip; set => tip = value; }

        [Browsable(false)]
        public int Id { get => id; set => id = value; }



        public string NazivTabele
        {
            get { return "Sala"; }
        }

        public string ID
        {
            get { return "ID"; }
        }

        public string UslovID
        {
            get { return "ID = " + id; } 
        }

        public string USLOVI;

        public string UslovOpsti
        {
            get { return USLOVI; }
        }
        public string UslovSort
        {
            get { return " ID"; }
        }

        public string Insert
        {
            get { return " values (" + id + ", '" + tip + "')"; }
        }

        public string Update
        {
            get { return " Tip = '" + tip + "'"; }
        }

        public string Update2
        {
            get { return ""; }
        }

       

        public OpstiDomenskiObjekat procitajRed(DataRow red)
        {
            Sala sala = new Sala();
            sala.id = Convert.ToInt32(red["ID"]);
            sala.tip = red["Tip"].ToString();

            return sala;
        }
    }
}
