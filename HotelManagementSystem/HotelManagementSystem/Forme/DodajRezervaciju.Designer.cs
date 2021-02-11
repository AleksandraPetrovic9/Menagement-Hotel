namespace HotelManagementSystem.Forme
{
    partial class DodajRezervaciju
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label3;
            this.dgvProstorije = new System.Windows.Forms.DataGridView();
            this.btnDodajGoste = new System.Windows.Forms.Button();
            this.lvGosti = new System.Windows.Forms.ListView();
            this.Ime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prezime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValidacioniDokument = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Telefon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnZapamtiRezervaciju = new System.Windows.Forms.Button();
            this.btnIzracunajCenu = new System.Windows.Forms.Button();
            this.lblCena = new System.Windows.Forms.Label();
            this.dtpDatumDo = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumOd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProstorija = new System.Windows.Forms.Label();
            this.cmbProstorija = new System.Windows.Forms.ComboBox();
            this.btnIzadji = new System.Windows.Forms.Button();
            this.btnPopust = new System.Windows.Forms.Button();
            this.lvPopust = new System.Windows.Forms.ListView();
            this.idKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imeKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prezimeKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sobaKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.brojTelefonaKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emailKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dokumentKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.datumOdKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.datumDoKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.datumRezervacijeKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Licno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Osoblje = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Uslovi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOstvariPopust = new System.Windows.Forms.Button();
            this.lblPopust = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnStatistika = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProstorije)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(68, 256);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(38, 16);
            label3.TabIndex = 25;
            label3.Text = "Gosti:";
            // 
            // dgvProstorije
            // 
            this.dgvProstorije.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.dgvProstorije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProstorije.GridColor = System.Drawing.Color.White;
            this.dgvProstorije.Location = new System.Drawing.Point(68, 152);
            this.dgvProstorije.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvProstorije.Name = "dgvProstorije";
            this.dgvProstorije.RowHeadersWidth = 51;
            this.dgvProstorije.RowTemplate.Height = 24;
            this.dgvProstorije.Size = new System.Drawing.Size(356, 95);
            this.dgvProstorije.TabIndex = 32;
            this.dgvProstorije.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProstorije_CellContentClick);
            // 
            // btnDodajGoste
            // 
            this.btnDodajGoste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodajGoste.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDodajGoste.Location = new System.Drawing.Point(138, 252);
            this.btnDodajGoste.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDodajGoste.Name = "btnDodajGoste";
            this.btnDodajGoste.Size = new System.Drawing.Size(286, 29);
            this.btnDodajGoste.TabIndex = 31;
            this.btnDodajGoste.Text = "Dodaj goste";
            this.btnDodajGoste.UseVisualStyleBackColor = true;
            this.btnDodajGoste.Click += new System.EventHandler(this.btnDodajGoste_Click);
            // 
            // lvGosti
            // 
            this.lvGosti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.lvGosti.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ime,
            this.Prezime,
            this.ValidacioniDokument,
            this.Email,
            this.Telefon});
            this.lvGosti.ForeColor = System.Drawing.Color.White;
            this.lvGosti.FullRowSelect = true;
            this.lvGosti.GridLines = true;
            this.lvGosti.HideSelection = false;
            this.lvGosti.Location = new System.Drawing.Point(68, 297);
            this.lvGosti.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lvGosti.Name = "lvGosti";
            this.lvGosti.Size = new System.Drawing.Size(435, 95);
            this.lvGosti.TabIndex = 30;
            this.lvGosti.UseCompatibleStateImageBehavior = false;
            this.lvGosti.View = System.Windows.Forms.View.Details;
            // 
            // Ime
            // 
            this.Ime.Text = "Ime";
            // 
            // Prezime
            // 
            this.Prezime.Text = "Prezime";
            this.Prezime.Width = 98;
            // 
            // ValidacioniDokument
            // 
            this.ValidacioniDokument.Text = "Validacioni dokument";
            this.ValidacioniDokument.Width = 150;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            // 
            // Telefon
            // 
            this.Telefon.Text = "Telefon";
            // 
            // btnZapamtiRezervaciju
            // 
            this.btnZapamtiRezervaciju.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZapamtiRezervaciju.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnZapamtiRezervaciju.Location = new System.Drawing.Point(70, 664);
            this.btnZapamtiRezervaciju.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnZapamtiRezervaciju.Name = "btnZapamtiRezervaciju";
            this.btnZapamtiRezervaciju.Size = new System.Drawing.Size(175, 33);
            this.btnZapamtiRezervaciju.TabIndex = 28;
            this.btnZapamtiRezervaciju.Text = "Zapamti rezervaciju";
            this.btnZapamtiRezervaciju.UseVisualStyleBackColor = true;
            this.btnZapamtiRezervaciju.Click += new System.EventHandler(this.btnZapamtiRezervaciju_Click);
            // 
            // btnIzracunajCenu
            // 
            this.btnIzracunajCenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzracunajCenu.Location = new System.Drawing.Point(71, 600);
            this.btnIzracunajCenu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnIzracunajCenu.Name = "btnIzracunajCenu";
            this.btnIzracunajCenu.Size = new System.Drawing.Size(119, 28);
            this.btnIzracunajCenu.TabIndex = 27;
            this.btnIzracunajCenu.Text = "Izracunaj cenu:";
            this.btnIzracunajCenu.UseVisualStyleBackColor = true;
            this.btnIzracunajCenu.Click += new System.EventHandler(this.btnIzracunajCenu_Click);
            // 
            // lblCena
            // 
            this.lblCena.AutoSize = true;
            this.lblCena.Location = new System.Drawing.Point(194, 612);
            this.lblCena.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCena.Name = "lblCena";
            this.lblCena.Size = new System.Drawing.Size(41, 16);
            this.lblCena.TabIndex = 26;
            this.lblCena.Text = "label1";
            // 
            // dtpDatumDo
            // 
            this.dtpDatumDo.Location = new System.Drawing.Point(180, 66);
            this.dtpDatumDo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpDatumDo.Name = "dtpDatumDo";
            this.dtpDatumDo.Size = new System.Drawing.Size(244, 21);
            this.dtpDatumDo.TabIndex = 24;
            // 
            // dtpDatumOd
            // 
            this.dtpDatumOd.Location = new System.Drawing.Point(180, 20);
            this.dtpDatumOd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpDatumOd.Name = "dtpDatumOd";
            this.dtpDatumOd.Size = new System.Drawing.Size(244, 21);
            this.dtpDatumOd.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Datum do:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Datum od:";
            // 
            // lblProstorija
            // 
            this.lblProstorija.AutoSize = true;
            this.lblProstorija.Location = new System.Drawing.Point(68, 109);
            this.lblProstorija.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProstorija.Name = "lblProstorija";
            this.lblProstorija.Size = new System.Drawing.Size(146, 16);
            this.lblProstorija.TabIndex = 19;
            this.lblProstorija.Text = "Prikazi slobodne prostorije:";
            // 
            // cmbProstorija
            // 
            this.cmbProstorija.FormattingEnabled = true;
            this.cmbProstorija.Location = new System.Drawing.Point(284, 106);
            this.cmbProstorija.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbProstorija.Name = "cmbProstorija";
            this.cmbProstorija.Size = new System.Drawing.Size(140, 24);
            this.cmbProstorija.TabIndex = 18;
            this.cmbProstorija.SelectedIndexChanged += new System.EventHandler(this.cmbProstorija_SelectedIndexChanged);
            // 
            // btnIzadji
            // 
            this.btnIzadji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzadji.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnIzadji.Location = new System.Drawing.Point(713, 660);
            this.btnIzadji.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnIzadji.Name = "btnIzadji";
            this.btnIzadji.Size = new System.Drawing.Size(175, 33);
            this.btnIzadji.TabIndex = 33;
            this.btnIzadji.Text = "Izadji";
            this.btnIzadji.UseVisualStyleBackColor = true;
            this.btnIzadji.Click += new System.EventHandler(this.btnIzadji_Click);
            // 
            // btnPopust
            // 
            this.btnPopust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPopust.Location = new System.Drawing.Point(68, 433);
            this.btnPopust.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPopust.Name = "btnPopust";
            this.btnPopust.Size = new System.Drawing.Size(174, 28);
            this.btnPopust.TabIndex = 34;
            this.btnPopust.Text = "Ranije odjave";
            this.btnPopust.UseVisualStyleBackColor = true;
            this.btnPopust.Click += new System.EventHandler(this.btnPopust_Click);
            this.btnPopust.MouseHover += new System.EventHandler(this.btnPopust_MouseHover);
            // 
            // lvPopust
            // 
            this.lvPopust.AutoArrange = false;
            this.lvPopust.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.lvPopust.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idKolona,
            this.imeKolona,
            this.prezimeKolona,
            this.sobaKolona,
            this.brojTelefonaKolona,
            this.emailKolona,
            this.dokumentKolona,
            this.datumOdKolona,
            this.datumDoKolona,
            this.datumRezervacijeKolona,
            this.Licno,
            this.Osoblje,
            this.Uslovi});
            this.lvPopust.ForeColor = System.Drawing.Color.White;
            this.lvPopust.FullRowSelect = true;
            this.lvPopust.GridLines = true;
            this.lvPopust.HideSelection = false;
            this.lvPopust.Location = new System.Drawing.Point(68, 469);
            this.lvPopust.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvPopust.Name = "lvPopust";
            this.lvPopust.Size = new System.Drawing.Size(818, 122);
            this.lvPopust.TabIndex = 35;
            this.lvPopust.UseCompatibleStateImageBehavior = false;
            this.lvPopust.View = System.Windows.Forms.View.Details;
            // 
            // idKolona
            // 
            this.idKolona.Text = "Id";
            this.idKolona.Width = 0;
            // 
            // imeKolona
            // 
            this.imeKolona.Text = "Ime";
            this.imeKolona.Width = 86;
            // 
            // prezimeKolona
            // 
            this.prezimeKolona.Text = "Prezime";
            this.prezimeKolona.Width = 87;
            // 
            // sobaKolona
            // 
            this.sobaKolona.Text = "Broj prostorije";
            this.sobaKolona.Width = 41;
            // 
            // brojTelefonaKolona
            // 
            this.brojTelefonaKolona.Text = "Broj telefona";
            this.brojTelefonaKolona.Width = 100;
            // 
            // emailKolona
            // 
            this.emailKolona.Text = "E-mail";
            this.emailKolona.Width = 150;
            // 
            // dokumentKolona
            // 
            this.dokumentKolona.Text = "Dokument";
            this.dokumentKolona.Width = 100;
            // 
            // datumOdKolona
            // 
            this.datumOdKolona.Text = "Datum od";
            this.datumOdKolona.Width = 112;
            // 
            // datumDoKolona
            // 
            this.datumDoKolona.Text = "Datum do";
            this.datumDoKolona.Width = 120;
            // 
            // datumRezervacijeKolona
            // 
            this.datumRezervacijeKolona.Text = "Datum odjave";
            this.datumRezervacijeKolona.Width = 125;
            // 
            // Licno
            // 
            this.Licno.Text = "Licno";
            // 
            // Osoblje
            // 
            this.Osoblje.Text = "Osoblje";
            // 
            // Uslovi
            // 
            this.Uslovi.Text = "Uslovi";
            // 
            // btnOstvariPopust
            // 
            this.btnOstvariPopust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOstvariPopust.Location = new System.Drawing.Point(71, 634);
            this.btnOstvariPopust.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOstvariPopust.Name = "btnOstvariPopust";
            this.btnOstvariPopust.Size = new System.Drawing.Size(174, 28);
            this.btnOstvariPopust.TabIndex = 36;
            this.btnOstvariPopust.Text = "Popust";
            this.btnOstvariPopust.UseVisualStyleBackColor = true;
            this.btnOstvariPopust.Click += new System.EventHandler(this.btnOstvariPopust_Click);
            // 
            // lblPopust
            // 
            this.lblPopust.AutoSize = true;
            this.lblPopust.Location = new System.Drawing.Point(267, 622);
            this.lblPopust.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPopust.Name = "lblPopust";
            this.lblPopust.Size = new System.Drawing.Size(0, 16);
            this.lblPopust.TabIndex = 37;
            // 
            // btnStatistika
            // 
            this.btnStatistika.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistika.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStatistika.Location = new System.Drawing.Point(68, 398);
            this.btnStatistika.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStatistika.Name = "btnStatistika";
            this.btnStatistika.Size = new System.Drawing.Size(286, 29);
            this.btnStatistika.TabIndex = 38;
            this.btnStatistika.Text = " Vidi statistiku  goste";
            this.btnStatistika.UseVisualStyleBackColor = true;
            this.btnStatistika.Click += new System.EventHandler(this.btnStatistika_Click);
            // 
            // DodajRezervaciju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(917, 705);
            this.Controls.Add(this.btnStatistika);
            this.Controls.Add(this.lblPopust);
            this.Controls.Add(this.btnOstvariPopust);
            this.Controls.Add(this.lvPopust);
            this.Controls.Add(this.btnPopust);
            this.Controls.Add(this.btnIzadji);
            this.Controls.Add(this.dgvProstorije);
            this.Controls.Add(this.btnDodajGoste);
            this.Controls.Add(this.lvGosti);
            this.Controls.Add(this.btnZapamtiRezervaciju);
            this.Controls.Add(this.btnIzracunajCenu);
            this.Controls.Add(this.lblCena);
            this.Controls.Add(label3);
            this.Controls.Add(this.dtpDatumDo);
            this.Controls.Add(this.dtpDatumOd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProstorija);
            this.Controls.Add(this.cmbProstorija);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "DodajRezervaciju";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DodajRezervaciju";
            this.Load += new System.EventHandler(this.DodajRezervaciju_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DodajRezervaciju_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProstorije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProstorije;
        private System.Windows.Forms.Button btnDodajGoste;
        private System.Windows.Forms.ListView lvGosti;
        private System.Windows.Forms.ColumnHeader Ime;
        private System.Windows.Forms.ColumnHeader Prezime;
        private System.Windows.Forms.ColumnHeader ValidacioniDokument;
        private System.Windows.Forms.Button btnZapamtiRezervaciju;
        private System.Windows.Forms.Button btnIzracunajCenu;
        private System.Windows.Forms.Label lblCena;
        private System.Windows.Forms.DateTimePicker dtpDatumDo;
        private System.Windows.Forms.DateTimePicker dtpDatumOd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProstorija;
        private System.Windows.Forms.ComboBox cmbProstorija;
        private System.Windows.Forms.Button btnIzadji;
        private System.Windows.Forms.Button btnPopust;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Telefon;
        private System.Windows.Forms.ListView lvPopust;
        private System.Windows.Forms.ColumnHeader idKolona;
        private System.Windows.Forms.ColumnHeader imeKolona;
        private System.Windows.Forms.ColumnHeader prezimeKolona;
        private System.Windows.Forms.ColumnHeader sobaKolona;
        private System.Windows.Forms.ColumnHeader brojTelefonaKolona;
        private System.Windows.Forms.ColumnHeader emailKolona;
        private System.Windows.Forms.ColumnHeader dokumentKolona;
        private System.Windows.Forms.ColumnHeader datumOdKolona;
        private System.Windows.Forms.ColumnHeader datumDoKolona;
        private System.Windows.Forms.ColumnHeader datumRezervacijeKolona;
        private System.Windows.Forms.ColumnHeader Licno;
        private System.Windows.Forms.ColumnHeader Osoblje;
        private System.Windows.Forms.ColumnHeader Uslovi;
        private System.Windows.Forms.Button btnOstvariPopust;
        private System.Windows.Forms.Label lblPopust;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnStatistika;
    }
}