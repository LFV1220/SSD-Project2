namespace project2
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart1_stockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2_stockVolume = new System.Windows.Forms.DataVisualization.Charting.Chart();
            comboBox1_stockPattern = new ComboBox();
            label1_stockPattern = new Label();
            dateTimePicker1_fromDate = new DateTimePicker();
            dateTimePicker2_toDate = new DateTimePicker();
            label2_dateRange = new Label();
            label3_toDate = new Label();
            label4_fromDate = new Label();
            button1_reset = new Button();
            button1_applyDates = new Button();
            button1_applyPattern = new Button();
            ((System.ComponentModel.ISupportInitialize)chart1_stockData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2_stockVolume).BeginInit();
            SuspendLayout();
            // 
            // chart1_stockData
            // 
            chartArea1.Name = "ChartArea1";
            chart1_stockData.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1_stockData.Legends.Add(legend1);
            chart1_stockData.Location = new Point(22, 28);
            chart1_stockData.Name = "chart1_stockData";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            chart1_stockData.Series.Add(series1);
            chart1_stockData.Size = new Size(838, 289);
            chart1_stockData.TabIndex = 0;
            chart1_stockData.Text = "chart1";
            // 
            // chart2_stockVolume
            // 
            chartArea2.Name = "ChartArea1";
            chart2_stockVolume.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart2_stockVolume.Legends.Add(legend2);
            chart2_stockVolume.Location = new Point(22, 348);
            chart2_stockVolume.Name = "chart2_stockVolume";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart2_stockVolume.Series.Add(series2);
            chart2_stockVolume.Size = new Size(838, 289);
            chart2_stockVolume.TabIndex = 1;
            chart2_stockVolume.Text = "chart2";
            // 
            // comboBox1_stockPattern
            // 
            comboBox1_stockPattern.FormattingEnabled = true;
            comboBox1_stockPattern.Items.AddRange(new object[] { "", "Bullish", "Bearish", "Neutral", "Marubozu", "Doji", "Dragonfly Doji", "Gravestone Doji", "Hammer", "Inverted Hammer" });
            comboBox1_stockPattern.Location = new Point(1053, 91);
            comboBox1_stockPattern.Name = "comboBox1_stockPattern";
            comboBox1_stockPattern.Size = new Size(147, 23);
            comboBox1_stockPattern.TabIndex = 2;
            // 
            // label1_stockPattern
            // 
            label1_stockPattern.AutoSize = true;
            label1_stockPattern.Location = new Point(931, 94);
            label1_stockPattern.Name = "label1_stockPattern";
            label1_stockPattern.Size = new Size(116, 15);
            label1_stockPattern.TabIndex = 3;
            label1_stockPattern.Text = "Select stock pattern: ";
            // 
            // dateTimePicker1_fromDate
            // 
            dateTimePicker1_fromDate.Location = new Point(991, 281);
            dateTimePicker1_fromDate.MaxDate = new DateTime(2023, 12, 31, 0, 0, 0, 0);
            dateTimePicker1_fromDate.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePicker1_fromDate.Name = "dateTimePicker1_fromDate";
            dateTimePicker1_fromDate.Size = new Size(200, 23);
            dateTimePicker1_fromDate.TabIndex = 4;
            dateTimePicker1_fromDate.Value = new DateTime(2000, 1, 1, 18, 45, 0, 0);
            // 
            // dateTimePicker2_toDate
            // 
            dateTimePicker2_toDate.Location = new Point(991, 328);
            dateTimePicker2_toDate.MaxDate = new DateTime(2023, 12, 31, 0, 0, 0, 0);
            dateTimePicker2_toDate.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePicker2_toDate.Name = "dateTimePicker2_toDate";
            dateTimePicker2_toDate.Size = new Size(200, 23);
            dateTimePicker2_toDate.TabIndex = 5;
            // 
            // label2_dateRange
            // 
            label2_dateRange.AutoSize = true;
            label2_dateRange.Location = new Point(944, 251);
            label2_dateRange.Name = "label2_dateRange";
            label2_dateRange.Size = new Size(73, 15);
            label2_dateRange.TabIndex = 6;
            label2_dateRange.Text = "Date Range: ";
            // 
            // label3_toDate
            // 
            label3_toDate.AutoSize = true;
            label3_toDate.Location = new Point(952, 334);
            label3_toDate.Name = "label3_toDate";
            label3_toDate.Size = new Size(25, 15);
            label3_toDate.TabIndex = 7;
            label3_toDate.Text = "To: ";
            // 
            // label4_fromDate
            // 
            label4_fromDate.AutoSize = true;
            label4_fromDate.Location = new Point(944, 287);
            label4_fromDate.Name = "label4_fromDate";
            label4_fromDate.Size = new Size(41, 15);
            label4_fromDate.TabIndex = 8;
            label4_fromDate.Text = "From: ";
            // 
            // button1_reset
            // 
            button1_reset.Location = new Point(1020, 547);
            button1_reset.Name = "button1_reset";
            button1_reset.Size = new Size(122, 62);
            button1_reset.TabIndex = 9;
            button1_reset.Text = "Reset";
            button1_reset.UseVisualStyleBackColor = true;
            button1_reset.Click += resetForm;
            // 
            // button1_applyDates
            // 
            button1_applyDates.Location = new Point(1044, 368);
            button1_applyDates.Name = "button1_applyDates";
            button1_applyDates.Size = new Size(67, 36);
            button1_applyDates.TabIndex = 10;
            button1_applyDates.Text = "Apply";
            button1_applyDates.UseVisualStyleBackColor = true;
            button1_applyDates.Click += applyDates;
            // 
            // button1_applyPattern
            // 
            button1_applyPattern.Location = new Point(1044, 130);
            button1_applyPattern.Name = "button1_applyPattern";
            button1_applyPattern.Size = new Size(67, 33);
            button1_applyPattern.TabIndex = 11;
            button1_applyPattern.Text = "Apply";
            button1_applyPattern.UseVisualStyleBackColor = true;
            button1_applyPattern.Click += applyPattern;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(button1_applyPattern);
            Controls.Add(button1_applyDates);
            Controls.Add(button1_reset);
            Controls.Add(label4_fromDate);
            Controls.Add(label3_toDate);
            Controls.Add(label2_dateRange);
            Controls.Add(dateTimePicker2_toDate);
            Controls.Add(dateTimePicker1_fromDate);
            Controls.Add(label1_stockPattern);
            Controls.Add(comboBox1_stockPattern);
            Controls.Add(chart2_stockVolume);
            Controls.Add(chart1_stockData);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)chart1_stockData).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2_stockVolume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1_stockData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2_stockVolume;
        private ComboBox comboBox1_stockPattern;
        private Label label1_stockPattern;
        private DateTimePicker dateTimePicker1_fromDate;
        private DateTimePicker dateTimePicker2_toDate;
        private Label label2_dateRange;
        private Label label3_toDate;
        private Label label4_fromDate;
        private Button button1_reset;
        private Button button1_applyDates;
        private Button button1_applyPattern;
    }
}