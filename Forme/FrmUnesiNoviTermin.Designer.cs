namespace Forme
{
    partial class FrmUnesiNoviTermin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUnesiNoviTermin));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtVrsta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMinuti = new System.Windows.Forms.ComboBox();
            this.cmbSati = new System.Windows.Forms.ComboBox();
            this.cmbSala = new System.Windows.Forms.ComboBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbVeterinar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridLjubimci = new System.Windows.Forms.DataGridView();
            this.txtLjubimac = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLjubimci)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtVrsta);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbMinuti);
            this.groupBox1.Controls.Add(this.cmbSati);
            this.groupBox1.Controls.Add(this.cmbSala);
            this.groupBox1.Controls.Add(this.btnSacuvaj);
            this.groupBox1.Controls.Add(this.txtOpis);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbVeterinar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.gridLjubimci);
            this.groupBox1.Controls.Add(this.txtLjubimac);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(28, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(771, 675);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dodajte novi termin";
            // 
            // txtVrsta
            // 
            this.txtVrsta.Location = new System.Drawing.Point(116, 452);
            this.txtVrsta.Name = "txtVrsta";
            this.txtVrsta.Size = new System.Drawing.Size(207, 28);
            this.txtVrsta.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 456);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 24);
            this.label8.TabIndex = 15;
            this.label8.Text = "Vrsta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(500, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "Vreme";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(657, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 29);
            this.label6.TabIndex = 1;
            this.label6.Text = ":";
            // 
            // cmbMinuti
            // 
            this.cmbMinuti.FormattingEnabled = true;
            this.cmbMinuti.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cmbMinuti.Location = new System.Drawing.Point(681, 311);
            this.cmbMinuti.Name = "cmbMinuti";
            this.cmbMinuti.Size = new System.Drawing.Size(68, 30);
            this.cmbMinuti.TabIndex = 13;
            // 
            // cmbSati
            // 
            this.cmbSati.FormattingEnabled = true;
            this.cmbSati.Items.AddRange(new object[] {
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21"});
            this.cmbSati.Location = new System.Drawing.Point(583, 311);
            this.cmbSati.Name = "cmbSati";
            this.cmbSati.Size = new System.Drawing.Size(68, 30);
            this.cmbSati.TabIndex = 12;
            // 
            // cmbSala
            // 
            this.cmbSala.FormattingEnabled = true;
            this.cmbSala.Location = new System.Drawing.Point(116, 384);
            this.cmbSala.Name = "cmbSala";
            this.cmbSala.Size = new System.Drawing.Size(208, 30);
            this.cmbSala.TabIndex = 11;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSacuvaj.Location = new System.Drawing.Point(603, 602);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(146, 54);
            this.btnSacuvaj.TabIndex = 1;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(115, 516);
            this.txtOpis.Multiline = true;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(341, 140);
            this.txtOpis.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 520);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Opis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sala";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(115, 313);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(370, 28);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Datum";
            // 
            // cmbVeterinar
            // 
            this.cmbVeterinar.FormattingEnabled = true;
            this.cmbVeterinar.Location = new System.Drawing.Point(116, 249);
            this.cmbVeterinar.Name = "cmbVeterinar";
            this.cmbVeterinar.Size = new System.Drawing.Size(208, 30);
            this.cmbVeterinar.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Veterinar";
            // 
            // gridLjubimci
            // 
            this.gridLjubimci.AllowUserToAddRows = false;
            this.gridLjubimci.AllowUserToDeleteRows = false;
            this.gridLjubimci.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLjubimci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLjubimci.Location = new System.Drawing.Point(9, 106);
            this.gridLjubimci.Name = "gridLjubimci";
            this.gridLjubimci.ReadOnly = true;
            this.gridLjubimci.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridLjubimci.RowHeadersWidth = 51;
            this.gridLjubimci.RowTemplate.Height = 24;
            this.gridLjubimci.Size = new System.Drawing.Size(740, 105);
            this.gridLjubimci.TabIndex = 2;
            this.gridLjubimci.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLjubimci_CellContentClick);
            // 
            // txtLjubimac
            // 
            this.txtLjubimac.Location = new System.Drawing.Point(115, 51);
            this.txtLjubimac.Name = "txtLjubimac";
            this.txtLjubimac.Size = new System.Drawing.Size(209, 28);
            this.txtLjubimac.TabIndex = 1;
            this.txtLjubimac.TextChanged += new System.EventHandler(this.txtLjubimac_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ljubimac";
            // 
            // FrmUnesiNoviTermin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 730);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUnesiNoviTermin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UnesiTermin";
            this.Load += new System.EventHandler(this.Termin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLjubimci)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbVeterinar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridLjubimci;
        private System.Windows.Forms.TextBox txtLjubimac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.ComboBox cmbSala;
        private System.Windows.Forms.ComboBox cmbMinuti;
        private System.Windows.Forms.ComboBox cmbSati;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVrsta;
        private System.Windows.Forms.Label label8;
    }
}