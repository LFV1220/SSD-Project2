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
        public Form2(BindingList<candlestick> candlesticks)
        {
            InitializeComponent();
            displayData(candlesticks);
        }

        // Function to display the stock data as a datagridview, stock price chart, and volume chart
        private void displayData(BindingList<candlestick> candlesticks)
        {
            // chart1_stockData.Series.Clear();
            // chart2_stockVolume.Series.Clear();

            Series candlestickSeries = new Series("Candlestick")
            {
                ChartType = SeriesChartType.Candlestick, // use candlestick chart type
                XValueType = ChartValueType.Date,
            };

            Series volumeSeries = new Series("volume")
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
                double pricedifference = Math.Abs((double)cs.close - (double)cs.open);
                datapoint.SetCustomProperty("pricedifference", pricedifference.ToString());

                // set the color based on open and close values
                if (cs.open < cs.close)
                {
                    datapoint.Color = Color.Green;
                }
                else
                {
                    datapoint.Color = Color.Green;
                }

                candlestickSeries.Points.Add(datapoint);
                volumeValues.Add((double)cs.volume);

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
            chart1_stockData.ChartAreas[0].AxisY.Minimum = yValues.Max();
            chart1_stockData.ChartAreas[0].AxisY.LabelStyle.Format = "f0";
            chart2_stockVolume.ChartAreas[0].AxisY.Minimum = volumeValues.Min();
            chart2_stockVolume.ChartAreas[0].AxisY.Maximum = volumeValues.Max();
            chart2_stockVolume.ChartAreas[0].AxisY.LabelStyle.Format = "f0";

            // setting up the title and labels
            //string tickername = combobox1_ticker.selectedindex != -1
            //   ? combobox1_ticker.selecteditem.tostring() + "-" + timeperiod
            //    : path.getfilenamewithoutextension(file);

            chart1_stockData.Titles.Clear();
            chart1_stockData.Titles.Add(new Title("tickername"));
            chart2_stockVolume.Titles.Clear();
            chart2_stockVolume.Titles.Add(new Title("tickername" + " - volume chart"));
            chart1_stockData.ChartAreas[0].AxisX.LabelStyle.Format = "mm/dd/yyyy";
            chart2_stockVolume.ChartAreas[0].AxisX.LabelStyle.Format = "mm/dd/yyyy";
        }

    }
}
