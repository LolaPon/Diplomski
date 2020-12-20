namespace Forme
{
    partial class FrmPocetna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPocetna));
            this.kalendar = new System.Windows.Forms.MonthCalendar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pacijentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prikaziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unesiNovogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rasporedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vlasniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.krajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblVet = new System.Windows.Forms.Label();
            this.gridTermini = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTermini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kalendar
            // 
            this.kalendar.Location = new System.Drawing.Point(464, 305);
            this.kalendar.Margin = new System.Windows.Forms.Padding(12);
            this.kalendar.Name = "kalendar";
            this.kalendar.TabIndex = 0;
            this.kalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Calendar_DateChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pacijentiToolStripMenuItem,
            this.rasporedToolStripMenuItem,
            this.vlasniciToolStripMenuItem,
            this.krajToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(855, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pacijentiToolStripMenuItem
            // 
            this.pacijentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prikaziToolStripMenuItem,
            this.unesiNovogToolStripMenuItem});
            this.pacijentiToolStripMenuItem.Name = "pacijentiToolStripMenuItem";
            this.pacijentiToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.pacijentiToolStripMenuItem.Text = "Ljubimci";
            // 
            // prikaziToolStripMenuItem
            // 
            this.prikaziToolStripMenuItem.Name = "prikaziToolStripMenuItem";
            this.prikaziToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.prikaziToolStripMenuItem.Text = "Prikazi";
            this.prikaziToolStripMenuItem.Click += new System.EventHandler(this.prikaziToolStripMenuItem_Click);
            // 
            // unesiNovogToolStripMenuItem
            // 
            this.unesiNovogToolStripMenuItem.Name = "unesiNovogToolStripMenuItem";
            this.unesiNovogToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.unesiNovogToolStripMenuItem.Text = "Unesi novog";
            this.unesiNovogToolStripMenuItem.Click += new System.EventHandler(this.unesiNovogToolStripMenuItem_Click);
            // 
            // rasporedToolStripMenuItem
            // 
            this.rasporedToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rasporedToolStripMenuItem.Name = "rasporedToolStripMenuItem";
            this.rasporedToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.rasporedToolStripMenuItem.Text = "Raspored";
            this.rasporedToolStripMenuItem.Click += new System.EventHandler(this.rasporedToolStripMenuItem_Click);
            // 
            // vlasniciToolStripMenuItem
            // 
            this.vlasniciToolStripMenuItem.Name = "vlasniciToolStripMenuItem";
            this.vlasniciToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.vlasniciToolStripMenuItem.Text = "Vlasnici";
            this.vlasniciToolStripMenuItem.Click += new System.EventHandler(this.vlasniciToolStripMenuItem_Click);
            // 
            // krajToolStripMenuItem
            // 
            this.krajToolStripMenuItem.Name = "krajToolStripMenuItem";
            this.krajToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.krajToolStripMenuItem.Text = "Kraj";
            this.krajToolStripMenuItem.Click += new System.EventHandler(this.krajToolStripMenuItem_Click);
            // 
            // lblVet
            // 
            this.lblVet.AutoSize = true;
            this.lblVet.Location = new System.Drawing.Point(-4, 596);
            this.lblVet.Name = "lblVet";
            this.lblVet.Size = new System.Drawing.Size(179, 24);
            this.lblVet.TabIndex = 2;
            this.lblVet.Text = "Ulogovani doktor: ";
            // 
            // gridTermini
            // 
            this.gridTermini.AllowUserToAddRows = false;
            this.gridTermini.AllowUserToDeleteRows = false;
            this.gridTermini.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTermini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTermini.Location = new System.Drawing.Point(45, 104);
            this.gridTermini.Name = "gridTermini";
            this.gridTermini.ReadOnly = true;
            this.gridTermini.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gridTermini.Size = new System.Drawing.Size(761, 125);
            this.gridTermini.TabIndex = 3;
            this.gridTermini.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTermini_CellDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Forme.Properties.Resources.Webp_net_resizeimage__3_;
            this.pictureBox1.Location = new System.Drawing.Point(45, 277);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(316, 303);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(855, 616);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gridTermini);
            this.Controls.Add(this.lblVet);
            this.Controls.Add(this.kalendar);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPocetna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dobro došli!";
            this.Load += new System.EventHandler(this.FrmPocetna_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTermini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar kalendar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pacijentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prikaziToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unesiNovogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rasporedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem krajToolStripMenuItem;
        private System.Windows.Forms.Label lblVet;
        private System.Windows.Forms.DataGridView gridTermini;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem vlasniciToolStripMenuItem;
    }
}