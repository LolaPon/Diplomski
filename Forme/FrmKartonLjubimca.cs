using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domen;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Forme
{
    public partial class FrmKartonLjubimca : Form
    {
        Ljubimac ljub = new Ljubimac();
        KontrolerKI kontroler = new KontrolerKI();
        Termin termin = new Termin();
        public FrmKartonLjubimca()
        {
            InitializeComponent();
        }

        public FrmKartonLjubimca(Ljubimac ljubimac)
        {
            InitializeComponent();
            ljub = ljubimac;
        }

        private void FrmKartonLjubimca_Load(object sender, EventArgs e)
        {
            txtIme.Text = ljub.Ime;
            txtVlasnik.Text = ljub.Vlasnik.ToString();
            txtZivotinja.Text = ljub.Zivotinja.ToString();
            txtStarost.Text = ljub.Starost.ToString();
            gridTermini.DataSource = kontroler.prikaziTermineZaLjubimca(ljub);
            gridTermini.Columns["Opis"].Visible = false;
            //
            gridTermini.Columns[6].Width = 140;
            

        }

        private void gridTermini_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            termin = gridTermini.CurrentRow.DataBoundItem as Termin;
            txtOpis.Text = termin.Opis;
        }

        private void btnKreirajIzvestaj_Click(object sender, EventArgs e)
        {
            kontroler.KreirajIzvestaj(ljub);

        }

        private void btnStampaj_Click(object sender, EventArgs e)
        {
            Document doc = new Document(PageSize.A4.Rotate());

            BaseFont arial = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font_15_bold = new iTextSharp.text.Font(arial, 15, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font_12_normal = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);

            Random rnd = new Random();
            int name = rnd.Next(1, 1000);
            FileStream os = new FileStream("izvestaj" + ljub.Ime + ".pdf", FileMode.Create); 

            using(os)
            {
                PdfWriter.GetInstance(doc, os);
                doc.Open();

                //info o veterin ambulanti
                PdfPTable tabela1 = new PdfPTable(1);
                float[] sirina = new float[] { 40f, 60f };

                PdfPCell cell1 = new PdfPCell(new Phrase("\n\nLABOVET", font_15_bold));
                PdfPCell cell2 = new PdfPCell(new Phrase("Veterinarska ordinacija", font_15_bold));
                PdfPCell cell3 = new PdfPCell(new Phrase("\nZemun, Karađorđev trg 9 \n Kontakt telefon : +381112107757", font_12_normal));

                cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell3.Border = iTextSharp.text.Rectangle.NO_BORDER;

                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

                tabela1.WidthPercentage = 40;
                tabela1.HorizontalAlignment = Element.ALIGN_LEFT;
                tabela1.AddCell(cell1);
                tabela1.AddCell(cell2);
                tabela1.AddCell(cell3);

                tabela1.SpacingAfter = 20;
                tabela1.SpacingBefore = 50;
                doc.Add(tabela1);

                //client

                tabela1 = new PdfPTable(1);
                cell1 = new PdfPCell(new Phrase("ID Ljubimca: " + ljub.Id.ToString() , font_15_bold));
                cell2 = new PdfPCell(new Phrase("Ime Ljubimca: " + txtIme.Text ,font_15_bold));
                cell3 = new PdfPCell(new Phrase("Vlasnik: " + txtVlasnik.Text , font_12_normal));

                cell1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cell2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cell3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

                cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell3.Border = iTextSharp.text.Rectangle.NO_BORDER;

                tabela1.AddCell(cell1);
                tabela1.AddCell(cell2);
                tabela1.AddCell(cell3);

                tabela1.SpacingAfter = 20;
                tabela1.SpacingBefore = 10;

                PdfPTable tabela2 = new PdfPTable(1);
                tabela2.AddCell(tabela1);
                tabela2.HorizontalAlignment = Element.ALIGN_RIGHT;
                tabela2.WidthPercentage = 40;
                doc.Add(tabela2);

                //paragraf sa datumom 

                Paragraph paragraf = new Paragraph(new Phrase("Datum: " + DateTime.Today.ToString() + "\n\n" , font_12_normal));
                paragraf.Add(new Phrase("Izveštaj br: ", font_15_bold));
                paragraf.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(paragraf);

                //

                tabela1 = new PdfPTable(7);

                for(int j = 0; j < 7; j++)
                {
                    cell1 = new PdfPCell(new Phrase(gridTermini.Columns[j].HeaderText));
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.FixedHeight = 20;
                    tabela1.AddCell(cell1);

                }

                for(int i = 0; i < gridTermini.Rows.Count; i++)
                {
                    for(int j = 0; j < 7; j++)
                    {
                        cell1 = new PdfPCell(new Phrase(gridTermini.Rows[i].Cells[j].Value.ToString())); // as string
                        cell1.FixedHeight = 20;
                        tabela1.AddCell(cell1);

                    }

                }

                tabela1.WidthPercentage = 100;
                sirina = new float[] { 300f, 300f, 500f, 300, 300, 2000, 500 };
                tabela1.SetWidths(sirina);
                tabela1.SpacingBefore = 20;
                doc.Add(tabela1);

                /////
                ///
               



                doc.Close();

                //otvara dokument
                System.Diagnostics.Process.Start(@"izvestaj" + ljub.Ime + ".pdf");
            }



            // Graphics izgled = gridTermini.CreateGraphics();
            // bmp = new Bitmap(gridTermini.Size.Width, gridTermini.Size.Height);
            // gridTermini.DrawToBitmap(bmp, new Rectangle(0,0, gridTermini.Width, gridTermini.Height));
            // Graphics noviIzgled = Graphics.FromImage(bmp);
            //// noviIzgled.CopyFromScreen(gridTermini.Location.X, gridTermini.Location.Y, 0, 0, gridTermini.Size);
            // printPreviewDialog1.ShowDialog();
        }
       // Bitmap bmp;


        //private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    e.Graphics.DrawImage(bmp, gridTermini.Location.X, gridTermini.Location.Y);
        //}
    }
}
