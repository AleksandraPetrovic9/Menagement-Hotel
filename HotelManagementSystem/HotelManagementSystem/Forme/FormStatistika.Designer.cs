namespace HotelManagementSystem.Forme
{
    partial class FormStatistika
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartRezPrijavilo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartOdjava = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.chartPoMesecima = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartRezPrijavilo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOdjava)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPoMesecima)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartRezPrijavilo
            // 
            this.chartRezPrijavilo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.chartRezPrijavilo.BorderlineColor = System.Drawing.Color.Linen;
            chartArea13.Area3DStyle.Enable3D = true;
            chartArea13.Area3DStyle.IsRightAngleAxes = false;
            chartArea13.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            chartArea13.Name = "ChartArea1";
            this.chartRezPrijavilo.ChartAreas.Add(chartArea13);
            legend13.Name = "Legend1";
            this.chartRezPrijavilo.Legends.Add(legend13);
            this.chartRezPrijavilo.Location = new System.Drawing.Point(7, 32);
            this.chartRezPrijavilo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartRezPrijavilo.Name = "chartRezPrijavilo";
            this.chartRezPrijavilo.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            series13.YValuesPerPoint = 2;
            this.chartRezPrijavilo.Series.Add(series13);
            this.chartRezPrijavilo.Size = new System.Drawing.Size(409, 208);
            this.chartRezPrijavilo.TabIndex = 0;
            this.chartRezPrijavilo.Text = "chart1";
            // 
            // chartOdjava
            // 
            this.chartOdjava.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            chartArea14.Area3DStyle.Enable3D = true;
            chartArea14.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            chartArea14.Name = "ChartArea1";
            this.chartOdjava.ChartAreas.Add(chartArea14);
            legend14.Name = "Legend1";
            this.chartOdjava.Legends.Add(legend14);
            this.chartOdjava.Location = new System.Drawing.Point(476, 32);
            this.chartOdjava.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartOdjava.Name = "chartOdjava";
            this.chartOdjava.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series14.Legend = "Legend1";
            series14.Name = "Series1";
            series14.YValuesPerPoint = 2;
            this.chartOdjava.Series.Add(series14);
            this.chartOdjava.Size = new System.Drawing.Size(409, 208);
            this.chartOdjava.TabIndex = 1;
            this.chartOdjava.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 522);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // chartPoMesecima
            // 
            this.chartPoMesecima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            chartArea15.Area3DStyle.Enable3D = true;
            chartArea15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            chartArea15.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea15.BackSecondaryColor = System.Drawing.Color.White;
            chartArea15.Name = "ChartArea1";
            this.chartPoMesecima.ChartAreas.Add(chartArea15);
            legend15.Enabled = false;
            legend15.Name = "Legend1";
            this.chartPoMesecima.Legends.Add(legend15);
            this.chartPoMesecima.Location = new System.Drawing.Point(17, 260);
            this.chartPoMesecima.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartPoMesecima.Name = "chartPoMesecima";
            this.chartPoMesecima.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series15.ChartArea = "ChartArea1";
            series15.Legend = "Legend1";
            series15.Name = "Series1";
            this.chartPoMesecima.Series.Add(series15);
            this.chartPoMesecima.Size = new System.Drawing.Size(868, 208);
            this.chartPoMesecima.TabIndex = 3;
            this.chartPoMesecima.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chartRezPrijavilo);
            this.groupBox1.Controls.Add(this.chartPoMesecima);
            this.groupBox1.Controls.Add(this.chartOdjava);
            this.groupBox1.Location = new System.Drawing.Point(27, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(892, 487);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistika";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(786, 545);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 31);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Izadji";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(27, 545);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ranije odjavljivanje";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(27, 582);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 31);
            this.button2.TabIndex = 7;
            this.button2.Text = "Otkaz rezervacija";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormStatistika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(933, 621);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormStatistika";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStatistika";
            this.Load += new System.EventHandler(this.FormStatistika_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormStatistika_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.chartRezPrijavilo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOdjava)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPoMesecima)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartRezPrijavilo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOdjava;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPoMesecima;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}