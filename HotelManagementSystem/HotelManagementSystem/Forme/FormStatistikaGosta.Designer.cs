namespace HotelManagementSystem.Forme
{
    partial class FormStatistikaGosta
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartRezPrijavilo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvRazlog = new System.Windows.Forms.ListView();
            this.razlog = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartRezPrijavilo)).BeginInit();
            this.SuspendLayout();
            // 
            // chartRezPrijavilo
            // 
            this.chartRezPrijavilo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.chartRezPrijavilo.BorderlineColor = System.Drawing.Color.Linen;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            chartArea1.Name = "ChartArea1";
            this.chartRezPrijavilo.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRezPrijavilo.Legends.Add(legend1);
            this.chartRezPrijavilo.Location = new System.Drawing.Point(36, 30);
            this.chartRezPrijavilo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chartRezPrijavilo.Name = "chartRezPrijavilo";
            this.chartRezPrijavilo.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chartRezPrijavilo.Series.Add(series1);
            this.chartRezPrijavilo.Size = new System.Drawing.Size(477, 256);
            this.chartRezPrijavilo.TabIndex = 1;
            this.chartRezPrijavilo.Text = "chart1";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(671, 488);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(212, 34);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Izadji";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvRazlog
            // 
            this.lvRazlog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.lvRazlog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.razlog,
            this.columnHeader1,
            this.columnHeader2});
            this.lvRazlog.ForeColor = System.Drawing.Color.White;
            this.lvRazlog.FullRowSelect = true;
            this.lvRazlog.GridLines = true;
            this.lvRazlog.HideSelection = false;
            this.lvRazlog.Location = new System.Drawing.Point(74, 345);
            this.lvRazlog.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lvRazlog.Name = "lvRazlog";
            this.lvRazlog.Size = new System.Drawing.Size(354, 183);
            this.lvRazlog.TabIndex = 31;
            this.lvRazlog.UseCompatibleStateImageBehavior = false;
            this.lvRazlog.View = System.Windows.Forms.View.Details;
            // 
            // razlog
            // 
            this.razlog.Text = "Licni razlozi";
            this.razlog.Width = 95;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Neprofesionalno osoblje";
            this.columnHeader1.Width = 148;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Losi uslovi";
            this.columnHeader2.Width = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "label3";
            // 
            // FormStatistikaGosta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(895, 534);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvRazlog);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chartRezPrijavilo);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormStatistikaGosta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPopust";
            this.Load += new System.EventHandler(this.FormPopust_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormStatistikaGosta_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.chartRezPrijavilo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartRezPrijavilo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvRazlog;
        private System.Windows.Forms.ColumnHeader razlog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}