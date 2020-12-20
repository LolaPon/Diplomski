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
    public class Termin : OpstiDomenskiObjekat
    {
        Zivotinja zivotinja;
        int id;
        Ljubimac ljubimac;
        Veterinar veterinar;
        DateTime datumIvreme;
        Sala sala;
        string vrstaTermina;
        string opis;
        


        [Browsable(false)]
        public int Id { get => id; set => id = value; }

        public Ljubimac Ljubimac { get => ljubimac; set => ljubimac = value; }
        [DisplayName("Životinja")]
        public Zivotinja Zivotinja { get => zivotinja; set => zivotinja = value; }
        public Veterinar Veterinar { get => veterinar; set => veterinar = value; }
        public Sala Sala { get => sala; set => sala = value; }
        [DisplayName("Tip")]
        public string VrstaTermina { get => vrstaTermina; set => vrstaTermina = value; }
        public string Opis { get => opis; set => opis = value; }
        [DisplayName("Datum")]
        public DateTime DatumIvreme { get => datumIvreme; set => datumIvreme = value; }



        #region ODO
        [Browsable(false)]
        public string ID
        {
            get { return "ID"; }
        }
        [Browsable(false)]
        public string NazivTabele
        {
            get { return "Termin"; }
        }
        [Browsable(false)]
        public string USLOVI;
        [Browsable(false)]
        public string UslovID
        {
            get { return "ID =" + id; }
        }
        [Browsable(false)]
        public string UslovOpsti
        {
            get { return USLOVI; }
        }
        [Browsable(false)]
        public string UslovSort
        {
            get { return " DatumIVreme"; }
        }

        [Browsable(false)]
        public string Insert
        {
            get { return "values(" + id + "," +ljubimac.Id+ "," +veterinar.Id+ ",'" + datumIvreme.ToString("yyyy-MM-dd HH:mm")+ "'," +sala.Id+ ",'" +vrstaTermina+ "', '" +opis+ "')"; }
        }
        [Browsable(false)]
        public string Update
        {
            get { return "IDLjubimac =" + ljubimac.Id + ", IDVeterinar =" + veterinar.Id + ", IDSala =" + sala.Id + ", Opis ='" + opis + "', DatumIVreme = '" + datumIvreme.ToString("yyyy-MM-dd HH:mm") + "', VrstaTermina = '" +vrstaTermina+ "'"; }          
        }
        [Browsable(false)]
        public string Update2
        {
            get { return "Opis = '" + opis + "'"; }
        }

        

        [Browsable(false)]
        public OpstiDomenskiObjekat procitajRed(DataRow red)
        {
            Termin t = new Termin();
            t.id = Convert.ToInt32(red["ID"]);
            t.ljubimac = new Ljubimac();
            t.ljubimac.Id = Convert.ToInt32(red["IDLjubimac"]);
            t.veterinar = new Veterinar();
            t.veterinar.Id = Convert.ToInt32(red["IDVeterinar"]);
            t.datumIvreme = Convert.ToDateTime(red["DatumIVreme"]);
            t.sala = new Sala();
            t.sala.Id = Convert.ToInt32(red["IDSala"]);
            t.vrstaTermina = red["VrstaTermina"].ToString();
            t.opis = red["Opis"].ToString();

            return t;
        }

        public override bool Equals(object obj)
        {
            return obj is Termin termin &&
                   id == termin.id;
        }

        #endregion
    }
}
