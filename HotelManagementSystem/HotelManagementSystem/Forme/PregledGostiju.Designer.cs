namespace HotelManagementSystem.Forme
{
    partial class PregledGostiju
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
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.azurirajButton = new System.Windows.Forms.Button();
            this.izbrisiButton = new System.Windows.Forms.Button();
            this.pregledGostijuListView = new System.Windows.Forms.ListView();
            this.idKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imeKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prezimeKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sobaKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.brojTelefonaKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emailKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dokumentKolona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filterComboBox
            // 
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Items.AddRange(new object[] {
            "Ime",
            "Prezime",
            "Broj prostorije"});
            this.filterComboBox.Location = new System.Drawing.Point(311, 38);
            this.filterComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(131, 25);
            this.filterComboBox.TabIndex = 0;
            // 
            // azurirajButton
            // 
            this.azurirajButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.azurirajButton.Location = new System.Drawing.Point(14, 528);
            this.azurirajButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.azurirajButton.Name = "azurirajButton";
            this.azurirajButton.Size = new System.Drawing.Size(142, 30);
            this.azurirajButton.TabIndex = 2;
            this.azurirajButton.Text = "Azuriraj";
            this.azurirajButton.UseVisualStyleBackColor = true;
            this.azurirajButton.Click += new System.EventHandler(this.azurirajButton_Click);
            // 
            // izbrisiButton
            // 
            this.izbrisiButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.izbrisiButton.Location = new System.Drawing.Point(184, 528);
            this.izbrisiButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.izbrisiButton.Name = "izbrisiButton";
            this.izbrisiButton.Size = new System.Drawing.Size(150, 30);
            this.izbrisiButton.TabIndex = 3;
            this.izbrisiButton.Text = "Izbrisi";
            this.izbrisiButton.UseVisualStyleBackColor = true;
            this.izbrisiButton.Click += new System.EventHandler(this.izbrisiButton_Click_1);
            // 
            // pregledGostijuListView
            // 
            this.pregledGostijuListView.AutoArrange = false;
            this.pregledGostijuListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.pregledGostijuListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idKolona,
            this.imeKolona,
            this.prezimeKolona,
            this.sobaKolona,
            this.brojTelefonaKolona,
            this.emailKolona,
            this.dokumentKolona});
            this.pregledGostijuListView.ForeColor = System.Drawing.Color.White;
            this.pregledGostijuListView.FullRowSelect = true;
            this.pregledGostijuListView.GridLines = true;
            this.pregledGostijuListView.HideSelection = false;
            this.pregledGostijuListView.Location = new System.Drawing.Point(14, 86);
            this.pregledGostijuListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pregledGostijuListView.Name = "pregledGostijuListView";
            this.pregledGostijuListView.Size = new System.Drawing.Size(744, 433);
            this.pregledGostijuListView.TabIndex = 4;
            this.pregledGostijuListView.UseCompatibleStateImageBehavior = false;
            this.pregledGostijuListView.View = System.Windows.Forms.View.Details;
            // 
            // idKolona
            // 
            this.idKolona.Text = "Id";
            this.idKolona.Width = 0;
            // 
            // imeKolona
            // 
            this.imeKolona.Text = "Ime";
            this.imeKolona.Width = 100;
            // 
            // prezimeKolona
            // 
            this.prezimeKolona.Text = "Prezime";
            this.prezimeKolona.Width = 100;
            // 
            // sobaKolona
            // 
            this.sobaKolona.Text = "Broj prostorije";
            this.sobaKolona.Width = 104;
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
            this.dokumentKolona.Width = 133;
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(14, 38);
            this.textBoxFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(142, 22);
            this.textBoxFilter.TabIndex = 5;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            this.textBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFilter_KeyPress);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(608, 528);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Izadji";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PregledGostiju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(794, 576);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.pregledGostijuListView);
            this.Controls.Add(this.izbrisiButton);
            this.Controls.Add(this.azurirajButton);
            this.Controls.Add(this.filterComboBox);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PregledGostiju";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PregledGostiju";
            this.Load += new System.EventHandler(this.PregledGostiju_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PregledGostiju_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox filterComboBox;
        private System.Windows.Forms.Button azurirajButton;
        private System.Windows.Forms.Button izbrisiButton;
        private System.Windows.Forms.ColumnHeader prezimeKolona;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.ColumnHeader sobaKolona;
        private System.Windows.Forms.ColumnHeader brojTelefonaKolona;
        private System.Windows.Forms.ColumnHeader emailKolona;
        private System.Windows.Forms.ColumnHeader dokumentKolona;
        private System.Windows.Forms.ColumnHeader imeKolona;
        private System.Windows.Forms.ListView pregledGostijuListView;
        private System.Windows.Forms.ColumnHeader idKolona;
        private System.Windows.Forms.Button button1;
    }
}