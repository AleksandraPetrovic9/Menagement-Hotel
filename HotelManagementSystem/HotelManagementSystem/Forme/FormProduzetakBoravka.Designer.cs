namespace HotelManagementSystem.Forme
{
    partial class FormProduzetakBoravka
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
            this.dtpProduzetak = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.lvlPrijava = new System.Windows.Forms.ListView();
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
            this.btnPronadjiRez = new System.Windows.Forms.Button();
            this.txtGost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpProduzetak
            // 
            this.dtpProduzetak.Location = new System.Drawing.Point(14, 295);
            this.dtpProduzetak.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpProduzetak.Name = "dtpProduzetak";
            this.dtpProduzetak.Size = new System.Drawing.Size(245, 21);
            this.dtpProduzetak.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(14, 335);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(245, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "Produzi boravak ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvlPrijava
            // 
            this.lvlPrijava.AutoArrange = false;
            this.lvlPrijava.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.lvlPrijava.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idKolona,
            this.imeKolona,
            this.prezimeKolona,
            this.sobaKolona,
            this.brojTelefonaKolona,
            this.emailKolona,
            this.dokumentKolona,
            this.datumOdKolona,
            this.datumDoKolona,
            this.datumRezervacijeKolona});
            this.lvlPrijava.ForeColor = System.Drawing.Color.White;
            this.lvlPrijava.FullRowSelect = true;
            this.lvlPrijava.GridLines = true;
            this.lvlPrijava.HideSelection = false;
            this.lvlPrijava.Location = new System.Drawing.Point(13, 114);
            this.lvlPrijava.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lvlPrijava.Name = "lvlPrijava";
            this.lvlPrijava.Size = new System.Drawing.Size(1087, 158);
            this.lvlPrijava.TabIndex = 8;
            this.lvlPrijava.UseCompatibleStateImageBehavior = false;
            this.lvlPrijava.View = System.Windows.Forms.View.Details;
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
            this.sobaKolona.Width = 78;
            // 
            // brojTelefonaKolona
            // 
            this.brojTelefonaKolona.Text = "Broj telefona";
            this.brojTelefonaKolona.Width = 100;
            // 
            // emailKolona
            // 
            this.emailKolona.Text = "E-mail";
            this.emailKolona.Width = 139;
            // 
            // dokumentKolona
            // 
            this.dokumentKolona.Text = "Dokument";
            this.dokumentKolona.Width = 100;
            // 
            // datumOdKolona
            // 
            this.datumOdKolona.Text = "Datum od";
            this.datumOdKolona.Width = 107;
            // 
            // datumDoKolona
            // 
            this.datumDoKolona.Text = "Datum do";
            this.datumDoKolona.Width = 102;
            // 
            // datumRezervacijeKolona
            // 
            this.datumRezervacijeKolona.Text = "Datum rezervacije";
            this.datumRezervacijeKolona.Width = 125;
            // 
            // btnPronadjiRez
            // 
            this.btnPronadjiRez.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPronadjiRez.Location = new System.Drawing.Point(14, 57);
            this.btnPronadjiRez.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPronadjiRez.Name = "btnPronadjiRez";
            this.btnPronadjiRez.Size = new System.Drawing.Size(245, 28);
            this.btnPronadjiRez.TabIndex = 13;
            this.btnPronadjiRez.Text = "Pronadjite prijavljenog gosta";
            this.btnPronadjiRez.UseVisualStyleBackColor = true;
            this.btnPronadjiRez.Click += new System.EventHandler(this.btnPronadjiRez_Click);
            // 
            // txtGost
            // 
            this.txtGost.Location = new System.Drawing.Point(139, 26);
            this.txtGost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGost.Name = "txtGost";
            this.txtGost.Size = new System.Drawing.Size(120, 21);
            this.txtGost.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Unesite email adresu";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(943, 335);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(157, 28);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Izadji";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // FormProduzetakBoravka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(1114, 392);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPronadjiRez);
            this.Controls.Add(this.txtGost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpProduzetak);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lvlPrijava);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormProduzetakBoravka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormProduzetakBoravka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpProduzetak;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lvlPrijava;
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
        private System.Windows.Forms.Button btnPronadjiRez;
        private System.Windows.Forms.TextBox txtGost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}