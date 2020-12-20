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
    public class Zivotinja : OpstiDomenskiObjekat
    {
        int id;
        string vrsta;
        
        List<Ljubimac> ljubimci;

        public Zivotinja()
        {
            ljubimci = new List<Ljubimac>();
        }
        [Browsable(false)]
        public int Id { get => id; set => id = value; }
       
        public string Vrsta { get => vrsta; set => vrsta = value; }
        public List<Ljubimac> Ljubimci { get => ljubimci; set => ljubimci = value; }

        public override string ToString()
        {
            return vrsta;
        }



        #region ODO
        [Browsable(false)]
        public string ID
        {
            get { return "ID"; }
        }

        public string NazivTabele
        {
            get { return "Zivotinja"; }
        }

        public string UslovID
        {
            get { return "ID =" + id; }
        }

        public string USLOVI;
        [Browsable(false)]
        public string UslovOpsti
        {
            get { return USLOVI; }
        }

        public string UslovSort
        {
            get { return " Vrsta"; }
        }
        public string Insert
        {
            get {
                return "(ID) values (" + id + ")";
                }
        }

        public string Update
        {
            get
            {
                return " Vrsta ='" + vrsta + "'";
            }
        }

        public string Update2
        {
            get { return "WOW"; }
        }

        public OpstiDomenskiObjekat procitajRed(DataRow red)
        {
            Zivotinja z = new Zivotinja();
            z.id = Convert.ToInt32(red["ID"]);
            z.vrsta = red["Vrsta"].ToString();
            return z;
        }
        #endregion
    }
}
