using Domen;
using OfficeOpenXml;
using Sesija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
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


        internal void kreirajIzvestajZaVeterinara(ComboBox cmbMeseci)
        {
            if(cmbMeseci.SelectedItem == null)
            {
                MessageBox.Show("Izaberite mesec");
                return;
            }
            termin = new Termin();
            List<Termin> termini = new List<Termin>();
            termin.USLOVI = " MONTH(DatumIVreme) = " +  Convert.ToInt32(cmbMeseci.SelectedIndex)  + "+1 and IDVeterinar = " + veterinar.Id;
            termini = komunikacija.vratiTermineZaUslov(termin);

            if(termini.Count == 0)
            { MessageBox.Show("Nema termina za izveštaj."); return; }
            if (termini.Count == 0)
            { MessageBox.Show("Došlo je do greške!"); }


            string spreadsheetPath = @"C:\Users\Selena Matijevic\Desktop\Izvestaji\" + "izvestaj" + veterinar.Ime + cmbMeseci.SelectedItem +".xlsx";
            File.Delete(spreadsheetPath);
            FileInfo spsInfo = new FileInfo(spreadsheetPath);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage pckIzvestaj = new ExcelPackage(spsInfo);

            try
            {
                var terminWorkSheet = pckIzvestaj.Workbook.Worksheets.Add("Izveštaj" + DateTime.Now.ToString("dd/MM/yyyy"));

                terminWorkSheet.Cells["A1:C1"].Merge = true;
                terminWorkSheet.Cells["A1"].Value = "LABOVET";
                terminWorkSheet.Cells["A1"].Style.Font.Bold = true;
                terminWorkSheet.Cells["A2:C2"].Merge = true;
                terminWorkSheet.Cells["A2"].Value = "Veterinarska ordinacija";
                terminWorkSheet.Cells["A1:A2"].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                terminWorkSheet.Cells["G1:G2"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                terminWorkSheet.Cells["A1:G1"].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                terminWorkSheet.Cells["A2:G2"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                terminWorkSheet.Cells["E1:G1"].Merge = true;
                terminWorkSheet.Cells["E1"].Value = "Zemun, KAradjordjev trg 9";
                terminWorkSheet.Cells["E2:G2"].Merge = true;
                terminWorkSheet.Cells["E2"].Value = "Kontakt tel: +381112107757";

                terminWorkSheet.Row(1).Height = 35;
                terminWorkSheet.Row(2).Height = 35;
                terminWorkSheet.Cells["A1:A2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                terminWorkSheet.Cells["A1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                terminWorkSheet.Cells["A2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;

                terminWorkSheet.Cells["E1:E2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                terminWorkSheet.Cells["E1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Bottom;
                terminWorkSheet.Cells["E2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;

                terminWorkSheet.Column(3).Width = 16;
                terminWorkSheet.Column(4).Width = 13;
                terminWorkSheet.Column(6).Width = 16;
                terminWorkSheet.Column(7).Width = 13;

                terminWorkSheet.Cells["A4"].Value = "Rbr";
                terminWorkSheet.Cells["B4"].Value = "Ljubimac";
                terminWorkSheet.Cells["C4"].Value = "Veterinar";
                terminWorkSheet.Cells["D4"].Value = "Datum";
                terminWorkSheet.Cells["E4"].Value = "Vreme";
                //terminWorkSheet.Cells["F1"].Value = "Sala";
                terminWorkSheet.Cells["F4"].Value = "Vrsta";
                terminWorkSheet.Cells["G4"].Value = "Opis";
                terminWorkSheet.Cells["A4:G4"].Style.Font.Bold = true;

                //Popunjavanje

                int currentRow = 5;

                foreach (Termin t in termini)
                {
                    terminWorkSheet.Cells["A" + currentRow.ToString()].Value = currentRow - 4;
                    terminWorkSheet.Cells["B" + currentRow.ToString()].Value = t.Ljubimac.Ime;
                    terminWorkSheet.Cells["C" + currentRow.ToString()].Value = t.Veterinar.ToString();
                    terminWorkSheet.Cells["D" + currentRow.ToString()].Value = t.DatumIvreme.ToString("dd.MM.yyyy.");
                    terminWorkSheet.Cells["E" + currentRow.ToString()].Value = t.DatumIvreme.ToString("HH:mm");
                    // terminWorkSheet.Cells["F" + currentRow.ToString()].Value = t.Sala.Tip;
                    terminWorkSheet.Cells["F" + currentRow.ToString()].Value = t.VrstaTermina;
                    terminWorkSheet.Cells["G" + currentRow.ToString()].Value = t.Opis;

                    currentRow++;
                }

                terminWorkSheet.View.FreezePanes(currentRow, 1);


                pckIzvestaj.Save();
                MessageBox.Show("Uspešno ste kreirali izveštaj!");
                //ProcessStartInfo startInfo = new ProcessStartInfo();
                //startInfo.FileName = @"C:\\Users\\Selena Matijevic\\Desktop\\" + ljub.Ime + ".xlsx"; // Your absolute PATH 
                //Process.Start(startInfo);
                //System.Diagnostics.Process.Start(@"C:\\Users\\Selena Matijevic\\Desktop\\"+ljub.Ime+".xlsx");
                //File.Open(@"C:\\Users\Selena Matijevic\\Desktop\\Izvestaji"+ljub.Ime+".xlsx", FileMode.Open);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        internal void prikaziNeaktivne(DataGridView gridLjubimci)
        {
            ljubimac = new Ljubimac();
            List<Ljubimac> lista = new List<Ljubimac>();
            ljubimac.USLOVI = "Status = 'Neaktivan'";
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
    

        public void kraj()
        {
            komunikacija.kraj();
        }


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

        internal void KreirajIzvestaj(Ljubimac ljub)
        {
            termin = new Termin();
            termin.USLOVI = " IDLjubimac = " + ljub.Id;
            List<Termin> lista = komunikacija.vratiTermineZaUslov(termin);

            string spreadsheetPath = @"C:\Users\Selena Matijevic\Desktop\Izvestaji\" + "izvestaj" + ljub.Ime + ".xlsx";
            File.Delete(spreadsheetPath);
            FileInfo spsInfo = new FileInfo(spreadsheetPath);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage pckIzvestaj = new ExcelPackage(spsInfo);

            try
            {
                var terminWorkSheet = pckIzvestaj.Workbook.Worksheets.Add("Izveštaj" + DateTime.Now.ToString("dd/MM/yyyy"));

                terminWorkSheet.Cells["A1:C1"].Merge = true;
                terminWorkSheet.Cells["A1"].Value = "LABOVET";
                terminWorkSheet.Cells["A1"].Style.Font.Bold = true;
                terminWorkSheet.Cells["A2:C2"].Merge = true;
                terminWorkSheet.Cells["A2"].Value = "Veterinarska ordinacija";
                terminWorkSheet.Cells["A1:A2"].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                terminWorkSheet.Cells["G1:G2"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                terminWorkSheet.Cells["A1:G1"].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                terminWorkSheet.Cells["A2:G2"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                terminWorkSheet.Cells["E1:G1"].Merge = true;
                terminWorkSheet.Cells["E1"].Value = "Zemun, Karadjordjev trg 9";
                terminWorkSheet.Cells["E2:G2"].Merge = true;
                terminWorkSheet.Cells["E2"].Value = "Kontakt tel: +381112107757";
        
                terminWorkSheet.Row(1).Height = 35;
                terminWorkSheet.Row(2).Height = 35;
                terminWorkSheet.Cells["A1:A2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                terminWorkSheet.Cells["A1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                terminWorkSheet.Cells["A2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;

                terminWorkSheet.Cells["E1:E2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                terminWorkSheet.Cells["E1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Bottom;
                terminWorkSheet.Cells["E2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;

                terminWorkSheet.Column(3).Width = 16;
                terminWorkSheet.Column(4).Width = 13;
                terminWorkSheet.Column(6).Width = 16;
                terminWorkSheet.Column(7).Width = 30;

                terminWorkSheet.Cells["A4"].Value = "Rbr";
                terminWorkSheet.Cells["B4"].Value = "Ljubimac";
                terminWorkSheet.Cells["C4"].Value = "Veterinar";
                terminWorkSheet.Cells["D4"].Value = "Datum";
                terminWorkSheet.Cells["E4"].Value = "Vreme";
                //terminWorkSheet.Cells["F1"].Value = "Sala";
                terminWorkSheet.Cells["F4"].Value = "Vrsta";
                terminWorkSheet.Cells["G4"].Value = "Opis";
                terminWorkSheet.Cells["A4:G4"].Style.Font.Bold = true;

                //Popunjavanje

                int currentRow = 5;

                foreach (Termin t in lista)
                {
                    terminWorkSheet.Cells["A" + currentRow.ToString()].Value = currentRow - 4;
                    terminWorkSheet.Cells["B" + currentRow.ToString()].Value = t.Ljubimac.Ime;
                    terminWorkSheet.Cells["C" + currentRow.ToString()].Value = t.Veterinar.ToString();
                    terminWorkSheet.Cells["D" + currentRow.ToString()].Value = t.DatumIvreme.ToString("dd.MM.yyyy.");
                    terminWorkSheet.Cells["E" + currentRow.ToString()].Value = t.DatumIvreme.ToString("HH:mm");
                    // terminWorkSheet.Cells["F" + currentRow.ToString()].Value = t.Sala.Tip;
                    terminWorkSheet.Cells["F" + currentRow.ToString()].Value = t.VrstaTermina;
                    terminWorkSheet.Cells["G" + currentRow.ToString()].Value = t.Opis;
                    terminWorkSheet.Cells["G" + currentRow.ToString()].Style.WrapText = true;

                    currentRow++;
                }

                terminWorkSheet.View.FreezePanes(currentRow, 1);


                pckIzvestaj.Save();
                MessageBox.Show("Uspešno ste kreirali izveštaj!");
                //ProcessStartInfo startInfo = new ProcessStartInfo();
                //startInfo.FileName = @"C:\\Users\\Selena Matijevic\\Desktop\\" + ljub.Ime + ".xlsx"; // Your absolute PATH 
                //Process.Start(startInfo);
                //System.Diagnostics.Process.Start(@"C:\\Users\\Selena Matijevic\\Desktop\\"+ljub.Ime+".xlsx");
                //File.Open(@"C:\\Users\Selena Matijevic\\Desktop\\Izvestaji"+ljub.Ime+".xlsx", FileMode.Open);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            

        }

        internal void sacuvajVlasnika(Vlasnik vlasnik, ComboBox cmbVlasnici, TextBox txtIme,TextBox txtPrezime, TextBox txtTelefon, TextBox txtEmail, TextBox txtZanimanje, TextBox txtNapomenan)
        {
            List<Vlasnik> vlasnici = new List<Vlasnik>();
            vlasnik.Ime = txtIme.Text;
            vlasnik.Prezime = txtPrezime.Text;
            vlasnik.Telefon = txtTelefon.Text;
            vlasnik.Email = txtEmail.Text;
            vlasnik.Zanimanje = txtZanimanje.Text;
            vlasnik.Napomena = txtNapomenan.Text;

            if(komunikacija.izmeniVlasnika(vlasnik)!= null)
            {
                MessageBox.Show("Uspešno ste izmenili vlasnika!");
                vlasnici = komunikacija.vratiSveVlasnike(vlasnik);
                if (vlasnici != null)
                {
                    cmbVlasnici.Items.Clear();
                    cmbVlasnici.Text = vlasnik.ToString();
                    foreach (Vlasnik v in vlasnici)
                    {
                        cmbVlasnici.Items.Add(v);
                    }
                }
            }
            else { MessageBox.Show("Došlo je do greške!"); }



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
            vlasnik.USLOVI = " JMBG = '" + vlasnik.Jmbg + "'";
            
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
                { MessageBox.Show("Nije moguće zameniti termin za izabrani datum. \n Izabran datum je prošao!");
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

        internal void prikaziTermineZaVet(DataGridView gridRaspored, List<Termin> lista)
        {
            if (lista == null || lista.Count == 0)
            {
                termin = new Termin();
                termin.USLOVI = " DatumIvreme >= '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm") + "'" ;
                lista = komunikacija.vratiTermineZaUslov(termin);
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
        

        internal void prikaziTermineZaDatum(DataGridView gridRaspored, DateTimePicker dateTimePicker)
        {
            termin = new Termin();
            termin.USLOVI = " DatumIVreme >= '" + dateTimePicker.Value.ToString("yyyy-MM-dd 00:00") + "' AND DatumIVreme <= '" + dateTimePicker.Value.ToString("yyyy-MM-dd 23:59") + "'";
            List<Termin> lista = komunikacija.vratiTermineZaUslov(termin);

            if (lista == null)
            {
                MessageBox.Show("Ne možemo da ucitamo termine!");
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

        internal void popuniFormu(TextBox txtImeLjubimca,ComboBox cmbZivotinje,TextBox txtRasa,TextBox txtStarost,TextBox txtBoja,RadioButton rbMuski ,RadioButton rbZenski,TextBox txtIDljub,Button btnSacuvajLj,Ljubimac lj,TextBox txtID,TextBox txtJmbg,TextBox txtIme,TextBox txtPrezime,TextBox txtEmail,TextBox txtTelefon,TextBox txtZanimanje ,TextBox txtNapomena)
        {
            vlasnik = new Vlasnik();
            vlasnik.Id = lj.Vlasnik.Id;
            vlasnik = komunikacija.pronadjiVlasnika(vlasnik)as Vlasnik;

            txtIDljub.Text = lj.Id.ToString();
            txtImeLjubimca.Text = lj.Ime;
            cmbZivotinje.SelectedIndex = cmbZivotinje.FindStringExact(lj.Zivotinja.Vrsta); ////////////////////////////////////////////////
            txtRasa.Text = lj.Rasa;
            txtStarost.Text = lj.Starost.ToString();
            txtBoja.Text = lj.Boja;
            if (lj.Pol == "M")
                rbMuski.Checked = true;
            if (lj.Pol == "Z")
                rbZenski.Checked = true;

            txtID.Text = vlasnik.Id.ToString();
            txtJmbg.Text = vlasnik.Jmbg.ToString();
            txtIme.Text = vlasnik.Ime;
            txtPrezime.Text = vlasnik.Prezime;
            txtEmail.Text = vlasnik.Email;
            txtTelefon.Text = vlasnik.Telefon;
            txtZanimanje.Text = vlasnik.Zanimanje;
            txtNapomena.Text = vlasnik.Napomena;
        }

        internal bool IzmeniLjubimca(TextBox txtIDljub, TextBox txtImeLjubimca,ComboBox cmbZivotinje, TextBox txtRasa, TextBox txtStarost, TextBox txtBoja,string pol, TextBox txtId, TextBox txtJmbg, TextBox txtIme, TextBox txtPrezime, TextBox txtEmail, TextBox txtTelefon, TextBox txtZanimanje, TextBox txtNapomena,  bool odgovor)
        {
            /////////////////////////txtIDljub, txtImeLjubimca, cmbZivotinje, txtRasa, txtStarost, txtBoja, pol,txtJmbg, txtJmbg,txtIme, txtPrezime, txtEmail, txtTelefon, txtZanimanje,txtNapomena ,odgovor
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
                 lj.Ime = txtImeLjubimca.Text.Trim();
                
                //Encoding enc = Encoding.UTF8;
                //byte[] utf8 = enc.GetBytes(txtImeLjubimca.Text.Trim()); ///////// PROBA
                //lj.Ime = enc.GetString(utf8);
            }

            if (txtRasa.Text == "")
            {
                MessageBox.Show("Unesite rasu ljubimca!");
                txtRasa.Focus();
                return false;
            }
            else
            {
                lj.Rasa = txtRasa.Text.Trim();
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
                lj.Boja = txtBoja.Text.Trim();
            }
            if (pol == "")
            {
                MessageBox.Show("Izaberite pol ljubimca!");
                return false;
            }
            else
            {
                lj.Pol = pol.Trim();
            }

           
            lj.Vlasnik = new Vlasnik();

            lj.Vlasnik.Id = Convert.ToInt32(txtId.Text.Trim()); 

            if (txtIme.Text == "")
            {
                MessageBox.Show("Unesite ime vlasnika!");
                txtIme.Focus();
                return false;
            }
            else
            {
                lj.Vlasnik.Ime = txtIme.Text.Trim();
            }

            if (txtPrezime.Text == "")
            {
                MessageBox.Show("Unesite prezime vlasnika!");
                txtPrezime.Focus();
                return false;
            }
            else
            {
                lj.Vlasnik.Prezime = txtPrezime.Text.Trim();
            }

            if (txtTelefon.Text == "")
            {
                MessageBox.Show("Unesite kontakt telefon vlasnika!");
                txtTelefon.Focus();
                return false;
            }
            else
            {
                lj.Vlasnik.Telefon = txtTelefon.Text.Trim();
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Unesite email vlasnika!");
                txtEmail.Focus();
                return false;
            }
            else
            {
                lj.Vlasnik.Email = txtEmail.Text.Trim();
            }

            if (txtZanimanje.Text == "")
            {
                MessageBox.Show("Unesite zanimanje vlasnika!");
                txtEmail.Focus();
                return false;
            }
            else
            {
                lj.Vlasnik.Zanimanje = txtZanimanje.Text.Trim();
            }

            lj.Vlasnik.Napomena = txtNapomena.Text.Trim();

            if (txtJmbg.Text == "")
            {
                MessageBox.Show("Unesite JMBG vlasnika!");
                txtStarost.Focus();
                return false;
            }
            else
            {
                
                
                    lj.Vlasnik.Jmbg = txtJmbg.Text.Trim();
                    if (lj.Vlasnik.Jmbg == "")
                    {
                        MessageBox.Show("Niste uneli JMBG u odgovarajucem formatu.");
                        return false;
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
            ljubimac.USLOVI = " (Ime like '" + txtPretraga.Text + "%' or Rasa like '" + txtPretraga + "%') and Status = 'Aktivan'";
            List<Ljubimac> lista = komunikacija.pronadjiLjubimca(ljubimac);
            gridLjubimci.DataSource = lista;
        }

        internal void prikaziLjubimce(DataGridView gridLjubimci, Vlasnik vlasnik)
        {
            ljubimac = new Ljubimac();
            List<Ljubimac> lista = new List<Ljubimac>();

            if (vlasnik != null)
            {
                ljubimac.USLOVI = " IDVlasnik = " + vlasnik.Id + "and Status = 'Aktivan'";
                lista = komunikacija.pronadjiLjubimca(ljubimac);
                return;
            }

            ljubimac.USLOVI = "Status = 'Aktivan'";
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

        internal bool sacuvajLjubimca(TextBox txtImeLjubimca, ComboBox cmbZivotinje, TextBox txtRasa, TextBox txtStarost, TextBox txtBoja, string pol, TextBox txtImeVlasnika, TextBox txtPrezimeVlasnika, TextBox txtEmail, TextBox txtJmbg, int id, TextBox txtId, TextBox txtZanimanje, TextBox txtTelefon)
        {//////////////////////////////txtImeLjubimca, cmbZivotinje, txtRasa,                                                                                          txtStarost, txtBoja, pol, txtIme, txtPrezime, txtEmail, txtJmbg, lj.Id , txtID, txtZanimanje

            ljubimac = new Ljubimac();

            ljubimac.Id = id;

            if (txtImeLjubimca.Text == "")
            {
                MessageBox.Show("Unesite ime ljubimca!");
                txtImeLjubimca.Focus();
                return false;
            } else
            {
                ljubimac.Ime = txtImeLjubimca.Text.Trim();
                //Encoding enc = Encoding.UTF8;
                //byte[] utf8 = enc.GetBytes(ljubimac.Ime); ///////// PROBA
                //ljubimac.Ime = enc.GetString(utf8);
            }

            if (txtRasa.Text == "")
            {
                MessageBox.Show("Unesite rasu ljubimca!");
                txtRasa.Focus();
                return false;
            }
            else
            {
                ljubimac.Rasa = txtRasa.Text.Trim();
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
                ljubimac.Boja = txtBoja.Text.Trim();
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

            ljubimac.Status = "Aktivan";

            ljubimac.Vlasnik = new Vlasnik();

           
            if (txtImeVlasnika.Text == "")
            {
                MessageBox.Show("Unesite ime vlasnika!");
                txtImeVlasnika.Focus();
                return false;
            }
            else
            {
                ljubimac.Vlasnik.Ime = txtImeVlasnika.Text.Trim();
            }

            if (txtPrezimeVlasnika.Text == "")
            {
                MessageBox.Show("Unesite prezime vlasnika!");
                txtPrezimeVlasnika.Focus();
                return false;
            }
            else
            {
                ljubimac.Vlasnik.Prezime = txtPrezimeVlasnika.Text.Trim();
            }

            if (txtTelefon.Text == "")
            {
                MessageBox.Show("Unesite kontakt telefon vlasnika!");
                txtTelefon.Focus();
                return false;
            }
            else
            {
                ljubimac.Vlasnik.Telefon = txtTelefon.Text.Trim();
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Unesite email vlasnika!");
                txtEmail.Focus();
                return false;
            }
            else
            {
                ljubimac.Vlasnik.Email = txtEmail.Text.Trim();
            }

            if (txtZanimanje.Text == "")
            {
                MessageBox.Show("Unesite zanimanje vlasnika!");
                txtZanimanje.Focus();
                return false;
            }
            else
            {
                ljubimac.Vlasnik.Zanimanje = txtZanimanje.Text.Trim();
            }

            
                ljubimac.Vlasnik.Jmbg = txtJmbg.Text;
                if (ljubimac.Vlasnik.Jmbg == "")
                {
                    MessageBox.Show("Niste uneli JMBG u odgovarajucem formatu.");
                    return false;
                }
            

            ljubimac.Vlasnik.Id = Convert.ToInt32(txtId.Text);

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
            
            

            ljubimac.Starost = Convert.ToInt32(currentRow.Cells[3].Value.ToString());
            ljubimac.Pol = currentRow.Cells[4].Value.ToString();
            ljubimac.Boja = currentRow.Cells[5].Value.ToString();
            ljubimac.Rasa = currentRow.Cells[7].Value.ToString();
            

            ljubimac.Zivotinja = new Zivotinja();
            ljubimac.Zivotinja.Vrsta = currentRow.Cells[8].Value.ToString();

            ljubimac.Vlasnik = new Vlasnik();
            ljubimac.Vlasnik.Ime = currentRow.Cells[6].Value.ToString().Split(' ')[0];
            ljubimac.Vlasnik.Prezime = currentRow.Cells[6].Value.ToString().Split(' ')[1];

            

            ljubimac.USLOVI = "lj.Ime = '" + ljubimac.Ime + "' and o.Ime = '" + ljubimac.Vlasnik.Ime + "' and o.Prezime = '" + ljubimac.Vlasnik.Prezime + "'";

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
            ljubimac.Starost = Convert.ToInt32(currentRow.Cells[3].Value.ToString());
            ljubimac.Pol = currentRow.Cells[4].Value.ToString();
            ljubimac.Boja = currentRow.Cells[5].Value.ToString();
            ljubimac.Rasa = currentRow.Cells[7].Value.ToString();


            ljubimac.Zivotinja = new Zivotinja();
            ljubimac.Zivotinja.Vrsta = currentRow.Cells[8].Value.ToString();

            ljubimac.Vlasnik = new Vlasnik();
            ljubimac.Vlasnik.Ime = currentRow.Cells[6].Value.ToString().Split(' ')[0];
            ljubimac.Vlasnik.Prezime = currentRow.Cells[6].Value.ToString().Split(' ')[1];

            ljubimac.USLOVI = " lj.Ime = '" + ljubimac.Ime + "' and lj.Rasa = '" + ljubimac.Rasa + "' and o.Ime = '" + ljubimac.Vlasnik.Ime + "' and o.Prezime = '" + ljubimac.Vlasnik.Prezime + "'";
            ljubimac = komunikacija.pronadjiLjubimcaIzTabele(ljubimac);

            termin.USLOVI = " DatumIVreme >= '" + DateTime.Now.ToString("yyyy-MM-dd 00:00") + "' and IDLjubimac = " + ljubimac.Id;
            if (komunikacija.vratiTermineZaUslov(termin) != null && komunikacija.vratiTermineZaUslov(termin).Count>0)
            {
                MessageBox.Show("Nije moguće obrisati podatke o ljubimcu! Postoje termini za izabranog ljubimca!");
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
                        MessageBox.Show("Uspešno ste obrisali podatke o ljubimcu!");
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
                        //komunikacija.obrisiVlasnika(vlasnik);
                        MessageBox.Show("Uspešno ste obrisali podatke o ljubimcu!");
                        return true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Došlo je do greške.");
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
                MessageBox.Show("Uspešno ste se prijavili na sistem!");
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
            termin.USLOVI = " DatumIVreme >= '" + DateTime.Now.ToString("yyyy-MM-dd 00:00") + "' and DatumIVreme <= '" + DateTime.Now.ToString("yyyy-MM-dd 23:59") + "' and IDVeterinar = " + veterinar.Id;
            List<Termin> lista = komunikacija.vratiTermineZaUslov(termin);

            BindingList<Termin> termini = new BindingList<Termin>(lista);
            gridTermini.DataSource = termini;
            gridTermini.Columns["DatumIVreme"].DefaultCellStyle.Format = "dd.MM.yyyy";
            gridTermini.Columns["Opis"].Visible = false;

        }

        internal void promeniStatusLjubimca(DataGridViewRow currentRow, Vlasnik v)
        {
            ljubimac = new Ljubimac();
            vlasnik = new Vlasnik();

            ljubimac.Ime = currentRow.Cells[0].Value.ToString();
            ljubimac.Status = currentRow.Cells[6].Value.ToString().Trim();
            vlasnik = v;
            ljubimac.USLOVI = " Ime = '" + ljubimac.Ime + "' and IDVlasnik = " + vlasnik.Id + " and Status = '" + ljubimac.Status + "'";
            List<Ljubimac> lista = komunikacija.pronadjiLjubimca(ljubimac);
            ljubimac = lista[0];
            if (ljubimac.Status == "Aktivan")
            {
                if (komunikacija.obrisiLjubimca(ljubimac) != null)
                { MessageBox.Show("Uspešno ste obrisali podatke o ljubimcu!"); }
            }
            else
            {
                if (komunikacija.izmeniLjubimca(ljubimac) != null)
                { MessageBox.Show("Uspešno ste aktivirali ljubimca!"); }
            }

        }

    }
    }

