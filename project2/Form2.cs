using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace project2
{
    public partial class Form2 : Form
    {
        private BindingList<smartCandlestick> candlesticks { get; set; }
        private String tickerName { get; set; }

        public Form2(String tickerName, BindingList<smartCandlestick> candlesticks)
        {
            InitializeComponent();

            // Get/set variables
            this.candlesticks = candlesticks;
            this.tickerName = tickerName;

            displayData(candlesticks);
        }

        // Function to show the specific stock data pattern, selected by the user
        private void applyPattern(object sender, EventArgs e)
        {
            // Check if selectedindex isnt 0 
            if (comboBox1_stockPattern.SelectedIndex == -1 || comboBox1_stockPattern.SelectedIndex == 0)
            {
                // Error, no ticker selected
                MessageBox.Show("Please select a stock pattern.", "No Stock Pattern Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Loop through candlestick list 
            // Check if the candlestick is in the date range
            // Check smartCandlestick attributes

        }

        // Function to apply the date range to the stock charts
        private void applyDates(object sender, EventArgs e)
        {
            BindingList<smartCandlestick> candlesticksInRange = new BindingList<smartCandlestick>();

            // Check for valid date range
            if (dateTimePicker2_toDate.Value < dateTimePicker1_fromDate.Value)
            {
                // Error, invalid date range
                MessageBox.Show("Please make sure the \"from\" date is before the \"to\" date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Iterate over all the candlesticks and only add the ones in the date range to new candlesticks list
            foreach (var cs in this.candlesticks)
            {
                DateTime csDate = DateTime.Parse(cs.date);
                if (csDate < dateTimePicker2_toDate.Value && csDate > dateTimePicker1_fromDate.Value)
                {
                    candlesticksInRange.Add(cs);
                }
            }

            // Call displayData function with new candlesticks list
            displayData(candlesticksInRange);
        }

        // Function to reset what is on the form/page
        private void resetForm(object sender, EventArgs e)
        {
            // Set comboBox and dates to default value


            // Call displayData function with global candlesticks list 
            displayData(this.candlesticks);
        }

        // Function to display the stock data as a stock price chart and volume chart
        private void displayData(BindingList<smartCandlestick> candlesticks)
        {
            chart1_stockData.Series.Clear();
            chart2_stockVolume.Series.Clear();

            Series candlestickSeries = new Series("Candlestick")
            {
                ChartType = SeriesChartType.Candlestick, // use candlestick chart type
                XValueType = ChartValueType.Date,
            };

            Series volumeSeries = new Series("Volume")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.Date,
            };

            List<double> yValues = new List<double>();
            List<double> volumeValues = new List<double>();

            foreach (var cs in candlesticks)
            {
                DataPoint datapoint = new DataPoint
                {
                    XValue = DateTime.Parse(cs.date).ToOADate(),
                    YValues = new double[] { (double)cs.open, (double)cs.high, (double)cs.low, (double)cs.close }
                };

                // candlestick size based on price difference
                double priceDifference = Math.Abs((double)cs.close - (double)cs.open);
                datapoint.SetCustomProperty("PriceDifference", priceDifference.ToString());

                // set the color based on open and close values
                if (cs.open < cs.close)
                {
                    datapoint.Color = Color.Green;
                }
                else
                {
                    datapoint.Color = Color.Red;
                }

                candlestickSeries.Points.Add(datapoint);
                volumeValues.Add(cs.volume);

                yValues.Add((double)cs.open);
                yValues.Add((double)cs.high);
                yValues.Add((double)cs.low);
                yValues.Add((double)cs.close);
            }

            // for the volume chart
            for (int i = 0; i < candlesticks.Count; i++)
            {
                DataPoint datapoint = new DataPoint
                {
                    XValue = DateTime.Parse(candlesticks[i].date).ToOADate(),
                    YValues = new double[] { (double)candlesticks[i].volume }
                };
                volumeSeries.Points.Add(datapoint);
            }

            chart1_stockData.Series.Add(candlestickSeries);
            chart2_stockVolume.Series.Add(volumeSeries);

            chart1_stockData.ChartAreas[0].AxisY.Minimum = yValues.Min();
            chart1_stockData.ChartAreas[0].AxisY.Maximum = yValues.Max();
            chart1_stockData.ChartAreas[0].AxisY.LabelStyle.Format = "F0";
            chart2_stockVolume.ChartAreas[0].AxisY.Minimum = volumeValues.Min();
            chart2_stockVolume.ChartAreas[0].AxisY.Maximum = volumeValues.Max();
            chart2_stockVolume.ChartAreas[0].AxisY.LabelStyle.Format = "F0";

            chart1_stockData.Titles.Clear();
            chart1_stockData.Titles.Add(new Title(tickerName));
            chart2_stockVolume.Titles.Clear();
            chart2_stockVolume.Titles.Add(new Title(tickerName + " - Volume"));
            chart1_stockData.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd/yyyy";
            chart2_stockVolume.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd/yyyy";
        }

    }
}
