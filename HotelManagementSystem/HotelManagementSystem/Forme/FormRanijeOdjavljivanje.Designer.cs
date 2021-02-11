namespace HotelManagementSystem.Forme
{
    partial class FormRanijeOdjavljivanje
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
            this.lvOdjava = new System.Windows.Forms.ListView();
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
            this.dtpDatumDo = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumOd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lvProstorije = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvOdjava
            // 
            this.lvOdjava.AutoArrange = false;
            this.lvOdjava.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.lvOdjava.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.lvOdjava.ForeColor = System.Drawing.Color.White;
            this.lvOdjava.FullRowSelect = true;
            this.lvOdjava.GridLines = true;
            this.lvOdjava.HideSelection = false;
            this.lvOdjava.Location = new System.Drawing.Point(14, 112);
            this.lvOdjava.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lvOdjava.Name = "lvOdjava";
            this.lvOdjava.Size = new System.Drawing.Size(1033, 149);
            this.lvOdjava.TabIndex = 36;
            this.lvOdjava.UseCompatibleStateImageBehavior = false;
            this.lvOdjava.View = System.Windows.Forms.View.Details;
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
            this.sobaKolona.Width = 76;
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
            this.dokumentKolona.Width = 83;
            // 
            // datumOdKolona
            // 
            this.datumOdKolona.Text = "Datum od";
            this.datumOdKolona.Width = 72;
            // 
            // datumDoKolona
            // 
            this.datumDoKolona.Text = "Datum do";
            this.datumDoKolona.Width = 79;
            // 
            // datumRezervacijeKolona
            // 
            this.datumRezervacijeKolona.Text = "Datum odjave";
            this.datumRezervacijeKolona.Width = 99;
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
            // dtpDatumDo
            // 
            this.dtpDatumDo.Location = new System.Drawing.Point(147, 79);
            this.dtpDatumDo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dtpDatumDo.Name = "dtpDatumDo";
            this.dtpDatumDo.Size = new System.Drawing.Size(284, 21);
            this.dtpDatumDo.TabIndex = 40;
            this.dtpDatumDo.ValueChanged += new System.EventHandler(this.dtpDatumDo_ValueChanged);
            // 
            // dtpDatumOd
            // 
            this.dtpDatumOd.Location = new System.Drawing.Point(147, 37);
            this.dtpDatumOd.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dtpDatumOd.Name = "dtpDatumOd";
            this.dtpDatumOd.Size = new System.Drawing.Size(284, 21);
            this.dtpDatumOd.TabIndex = 39;
            this.dtpDatumOd.ValueChanged += new System.EventHandler(this.dtpDatumOd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "Datum do:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Datum od:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 300);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(217, 28);
            this.button1.TabIndex = 41;
            this.button1.Text = "Prostorije koje su prijavljene";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvProstorije
            // 
            this.lvProstorije.AutoArrange = false;
            this.lvProstorije.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.lvProstorije.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvProstorije.ForeColor = System.Drawing.Color.White;
            this.lvProstorije.FullRowSelect = true;
            this.lvProstorije.GridLines = true;
            this.lvProstorije.HideSelection = false;
            this.lvProstorije.Location = new System.Drawing.Point(12, 337);
            this.lvProstorije.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lvProstorije.Name = "lvProstorije";
            this.lvProstorije.Size = new System.Drawing.Size(378, 136);
            this.lvProstorije.TabIndex = 42;
            this.lvProstorije.UseCompatibleStateImageBehavior = false;
            this.lvProstorije.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Broj prostorije";
            this.columnHeader2.Width = 97;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Cena";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Koliko puta je prijavljena";
            this.columnHeader4.Width = 155;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(830, 456);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(217, 37);
            this.btnClose.TabIndex = 43;
            this.btnClose.Text = "Izadji";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(500, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 44;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FormRanijeOdjavljivanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(1065, 506);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvProstorije);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpDatumDo);
            this.Controls.Add(this.dtpDatumOd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvOdjava);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormRanijeOdjavljivanje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRanijeOdjavljivanje";
            this.Load += new System.EventHandler(this.FormRanijeOdjavljivanje_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormRanijeOdjavljivanje_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvOdjava;
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
        private System.Windows.Forms.DateTimePicker dtpDatumDo;
        private System.Windows.Forms.DateTimePicker dtpDatumOd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lvProstorije;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox textBox1;
    }
}