namespace Forme
{
    partial class FrmRaspored
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRaspored));
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.gbRaspored = new System.Windows.Forms.GroupBox();
            this.gridRaspored = new System.Windows.Forms.DataGridView();
            this.btnDodajNovi = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnPonisti = new System.Windows.Forms.Button();
            this.gbRaspored.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRaspored)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker.Location = new System.Drawing.Point(43, 21);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(353, 28);
            this.dateTimePicker.TabIndex = 1;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // gbRaspored
            // 
            this.gbRaspored.Controls.Add(this.gridRaspored);
            this.gbRaspored.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbRaspored.Location = new System.Drawing.Point(26, 78);
            this.gbRaspored.Name = "gbRaspored";
            this.gbRaspored.Size = new System.Drawing.Size(918, 294);
            this.gbRaspored.TabIndex = 2;
            this.gbRaspored.TabStop = false;
            this.gbRaspored.Text = "Raspored";
            // 
            // gridRaspored
            // 
            this.gridRaspored.AllowUserToAddRows = false;
            this.gridRaspored.AllowUserToDeleteRows = false;
            this.gridRaspored.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridRaspored.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRaspored.Location = new System.Drawing.Point(17, 27);
            this.gridRaspored.Name = "gridRaspored";
            this.gridRaspored.ReadOnly = true;
            this.gridRaspored.RowHeadersWidth = 51;
            this.gridRaspored.RowTemplate.Height = 24;
            this.gridRaspored.Size = new System.Drawing.Size(881, 249);
            this.gridRaspored.TabIndex = 0;
            this.gridRaspored.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRaspored_CellClick);
            this.gridRaspored.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridRaspored_RowHeaderMouseClick);
            // 
            // btnDodajNovi
            // 
            this.btnDodajNovi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDodajNovi.Location = new System.Drawing.Point(965, 93);
            this.btnDodajNovi.Name = "btnDodajNovi";
            this.btnDodajNovi.Size = new System.Drawing.Size(165, 64);
            this.btnDodajNovi.TabIndex = 3;
            this.btnDodajNovi.Text = "Dodaj novi";
            this.btnDodajNovi.UseVisualStyleBackColor = true;
            this.btnDodajNovi.Click += new System.EventHandler(this.btnDodajNovi_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnObrisi.Location = new System.Drawing.Point(965, 200);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(165, 64);
            this.btnObrisi.TabIndex = 4;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnIzmeni.Location = new System.Drawing.Point(965, 312);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(165, 64);
            this.btnIzmeni.TabIndex = 5;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnPonisti
            // 
            this.btnPonisti.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPonisti.Location = new System.Drawing.Point(436, 12);
            this.btnPonisti.Name = "btnPonisti";
            this.btnPonisti.Size = new System.Drawing.Size(124, 49);
            this.btnPonisti.TabIndex = 6;
            this.btnPonisti.Text = "Poništi";
            this.btnPonisti.UseVisualStyleBackColor = true;
            this.btnPonisti.Click += new System.EventHandler(this.btnPonisti_Click);
            // 
            // FrmRaspored
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 580);
            this.Controls.Add(this.btnPonisti);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnDodajNovi);
            this.Controls.Add(this.gbRaspored);
            this.Controls.Add(this.dateTimePicker);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRaspored";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raspored termina";
            this.Load += new System.EventHandler(this.FrmRaspored_Load);
            this.gbRaspored.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRaspored)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.GroupBox gbRaspored;
        private System.Windows.Forms.DataGridView gridRaspored;
        private System.Windows.Forms.Button btnDodajNovi;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnPonisti;
    }
}