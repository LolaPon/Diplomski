namespace Forme
{
    partial class FrmLjubimci
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLjubimci));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridLjubimci = new System.Windows.Forms.DataGridView();
            this.imeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.starostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.polDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bojaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlasnikDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rasaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zivotinjaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIzmeni = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnObrisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLjubimci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridLjubimci);
            this.groupBox1.Location = new System.Drawing.Point(22, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1168, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // gridLjubimci
            // 
            this.gridLjubimci.AllowUserToAddRows = false;
            this.gridLjubimci.AllowUserToDeleteRows = false;
            this.gridLjubimci.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLjubimci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLjubimci.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imeDataGridViewTextBoxColumn,
            this.starostDataGridViewTextBoxColumn,
            this.polDataGridViewTextBoxColumn,
            this.bojaDataGridViewTextBoxColumn,
            this.vlasnikDataGridViewTextBoxColumn,
            this.rasaDataGridViewTextBoxColumn,
            this.zivotinjaDataGridViewTextBoxColumn,
            this.btnIzmeni,
            this.btnObrisi});
            this.gridLjubimci.Location = new System.Drawing.Point(19, 21);
            this.gridLjubimci.Name = "gridLjubimci";
            this.gridLjubimci.ReadOnly = true;
            this.gridLjubimci.RowHeadersWidth = 51;
            this.gridLjubimci.RowTemplate.Height = 24;
            this.gridLjubimci.Size = new System.Drawing.Size(1143, 375);
            this.gridLjubimci.TabIndex = 0;
            this.gridLjubimci.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLjubimci_CellContentClick);
            this.gridLjubimci.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLjubimci_CellContentDoubleClick);
            // 
            // imeDataGridViewTextBoxColumn
            // 
            this.imeDataGridViewTextBoxColumn.DataPropertyName = "Ime";
            this.imeDataGridViewTextBoxColumn.HeaderText = "Ime";
            this.imeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.imeDataGridViewTextBoxColumn.Name = "imeDataGridViewTextBoxColumn";
            this.imeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // starostDataGridViewTextBoxColumn
            // 
            this.starostDataGridViewTextBoxColumn.DataPropertyName = "Starost";
            this.starostDataGridViewTextBoxColumn.HeaderText = "Starost";
            this.starostDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.starostDataGridViewTextBoxColumn.Name = "starostDataGridViewTextBoxColumn";
            this.starostDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // polDataGridViewTextBoxColumn
            // 
            this.polDataGridViewTextBoxColumn.DataPropertyName = "Pol";
            this.polDataGridViewTextBoxColumn.HeaderText = "Pol";
            this.polDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.polDataGridViewTextBoxColumn.Name = "polDataGridViewTextBoxColumn";
            this.polDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bojaDataGridViewTextBoxColumn
            // 
            this.bojaDataGridViewTextBoxColumn.DataPropertyName = "Boja";
            this.bojaDataGridViewTextBoxColumn.HeaderText = "Boja";
            this.bojaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.bojaDataGridViewTextBoxColumn.Name = "bojaDataGridViewTextBoxColumn";
            this.bojaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlasnikDataGridViewTextBoxColumn
            // 
            this.vlasnikDataGridViewTextBoxColumn.DataPropertyName = "Vlasnik";
            this.vlasnikDataGridViewTextBoxColumn.HeaderText = "Vlasnik";
            this.vlasnikDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.vlasnikDataGridViewTextBoxColumn.Name = "vlasnikDataGridViewTextBoxColumn";
            this.vlasnikDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rasaDataGridViewTextBoxColumn
            // 
            this.rasaDataGridViewTextBoxColumn.DataPropertyName = "Rasa";
            this.rasaDataGridViewTextBoxColumn.HeaderText = "Rasa";
            this.rasaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.rasaDataGridViewTextBoxColumn.Name = "rasaDataGridViewTextBoxColumn";
            this.rasaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // zivotinjaDataGridViewTextBoxColumn
            // 
            this.zivotinjaDataGridViewTextBoxColumn.DataPropertyName = "Zivotinja";
            this.zivotinjaDataGridViewTextBoxColumn.HeaderText = "Životinja";
            this.zivotinjaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.zivotinjaDataGridViewTextBoxColumn.Name = "zivotinjaDataGridViewTextBoxColumn";
            this.zivotinjaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnIzmeni
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Transparent;
            this.btnIzmeni.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnIzmeni.HeaderText = "Izmeni";
            this.btnIzmeni.MinimumWidth = 6;
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.ReadOnly = true;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseColumnTextForButtonValue = true;
            // 
            // btnObrisi
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnObrisi.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnObrisi.HeaderText = "Obriši";
            this.btnObrisi.MinimumWidth = 6;
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.ReadOnly = true;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseColumnTextForButtonValue = true;
            // 
            // txtPretraga
            // 
            this.txtPretraga.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPretraga.Location = new System.Drawing.Point(197, 96);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(265, 28);
            this.txtPretraga.TabIndex = 1;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPretrazi.Location = new System.Drawing.Point(490, 80);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(144, 61);
            this.btnPretrazi.TabIndex = 2;
            this.btnPretrazi.Text = "Pretraži";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Forme.Properties.Resources.asia1;
            this.pictureBox2.Location = new System.Drawing.Point(835, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(204, 184);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // FrmLjubimci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 684);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLjubimci";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spisak ljubimaca";
            this.Load += new System.EventHandler(this.FrmLjubimci_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLjubimci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridLjubimci;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Starost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Boja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vlasnik;
        private System.Windows.Forms.DataGridViewTextBoxColumn Veterinar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rasa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zivotinja;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn imeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn starostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn polDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bojaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlasnikDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rasaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zivotinjaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnIzmeni;
        private System.Windows.Forms.DataGridViewButtonColumn btnObrisi;
    }
}