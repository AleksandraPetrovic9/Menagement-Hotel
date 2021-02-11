namespace HotelManagementSystem
{
    partial class PregledSobe
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.txtPoBrojuSobe = new System.Windows.Forms.TextBox();
            this.txtPoCeni = new System.Windows.Forms.TextBox();
            this.txtPoKlimi = new System.Windows.Forms.TextBox();
            this.txtGosti = new System.Windows.Forms.TextBox();
            this.btnGostiZaSobu = new System.Windows.Forms.Button();
            this.txtListaGostiju = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(10, 348);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 51);
            this.button1.TabIndex = 1;
            this.button1.Text = "Dodaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObrisi.Location = new System.Drawing.Point(155, 350);
            this.btnObrisi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(121, 48);
            this.btnObrisi.TabIndex = 2;
            this.btnObrisi.Text = "Obrisi ";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzmeni.Location = new System.Drawing.Point(299, 350);
            this.btnIzmeni.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(121, 51);
            this.btnIzmeni.TabIndex = 3;
            this.btnIzmeni.Text = "Izmeni ";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(8, 35);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(565, 288);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // txtPoBrojuSobe
            // 
            this.txtPoBrojuSobe.Location = new System.Drawing.Point(579, 56);
            this.txtPoBrojuSobe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPoBrojuSobe.Name = "txtPoBrojuSobe";
            this.txtPoBrojuSobe.Size = new System.Drawing.Size(159, 22);
            this.txtPoBrojuSobe.TabIndex = 7;
            this.txtPoBrojuSobe.TextChanged += new System.EventHandler(this.txtPoBrojuSobe_TextChanged);
            // 
            // txtPoCeni
            // 
            this.txtPoCeni.Location = new System.Drawing.Point(579, 120);
            this.txtPoCeni.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPoCeni.Name = "txtPoCeni";
            this.txtPoCeni.Size = new System.Drawing.Size(159, 22);
            this.txtPoCeni.TabIndex = 8;
            this.txtPoCeni.TextChanged += new System.EventHandler(this.txtPoCeni_TextChanged);
            // 
            // txtPoKlimi
            // 
            this.txtPoKlimi.Location = new System.Drawing.Point(579, 177);
            this.txtPoKlimi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPoKlimi.Name = "txtPoKlimi";
            this.txtPoKlimi.Size = new System.Drawing.Size(159, 22);
            this.txtPoKlimi.TabIndex = 10;
            this.txtPoKlimi.TextChanged += new System.EventHandler(this.txtPoKlimi_TextChanged);
            // 
            // txtGosti
            // 
            this.txtGosti.Location = new System.Drawing.Point(463, 386);
            this.txtGosti.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGosti.Name = "txtGosti";
            this.txtGosti.Size = new System.Drawing.Size(251, 22);
            this.txtGosti.TabIndex = 12;
            // 
            // btnGostiZaSobu
            // 
            this.btnGostiZaSobu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGostiZaSobu.Location = new System.Drawing.Point(463, 348);
            this.btnGostiZaSobu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGostiZaSobu.Name = "btnGostiZaSobu";
            this.btnGostiZaSobu.Size = new System.Drawing.Size(251, 30);
            this.btnGostiZaSobu.TabIndex = 11;
            this.btnGostiZaSobu.Text = "Za uneti broj prostorije vidi listu gostiju:";
            this.btnGostiZaSobu.UseVisualStyleBackColor = true;
            this.btnGostiZaSobu.Click += new System.EventHandler(this.btnGostiZaSobu_Click);
            // 
            // txtListaGostiju
            // 
            this.txtListaGostiju.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.txtListaGostiju.ForeColor = System.Drawing.Color.White;
            this.txtListaGostiju.Location = new System.Drawing.Point(463, 432);
            this.txtListaGostiju.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtListaGostiju.Multiline = true;
            this.txtListaGostiju.Name = "txtListaGostiju";
            this.txtListaGostiju.Size = new System.Drawing.Size(251, 85);
            this.txtListaGostiju.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(581, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Pretraga po broju  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(581, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Pretraga po ceni";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(575, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Pretraga po postojanju klime";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(763, 477);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 40);
            this.button2.TabIndex = 17;
            this.button2.Text = "Izadji";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PregledSobe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(909, 539);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtListaGostiju);
            this.Controls.Add(this.txtGosti);
            this.Controls.Add(this.btnGostiZaSobu);
            this.Controls.Add(this.txtPoKlimi);
            this.Controls.Add(this.txtPoCeni);
            this.Controls.Add(this.txtPoBrojuSobe);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PregledSobe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PregledSobe";
            this.Load += new System.EventHandler(this.PregledSobe_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PregledSobe_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox txtPoBrojuSobe;
        private System.Windows.Forms.TextBox txtPoCeni;
        private System.Windows.Forms.TextBox txtPoKlimi;
        private System.Windows.Forms.TextBox txtGosti;
        private System.Windows.Forms.Button btnGostiZaSobu;
        private System.Windows.Forms.TextBox txtListaGostiju;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}