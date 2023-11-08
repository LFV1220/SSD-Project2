using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace project2
{
    public partial class Form1 : Form
    {
        private string timePeriod = "Day";

        public Form1()
        {
            InitializeComponent();
            this.loadTickers();
        }

        // Function to load unique ticker symbols into the combobox
        private void loadTickers()
        {
            // Get all .csv files from the Stock Data Folder
            string[] csvFiles = Directory.GetFiles(getFolderPath(), "*.csv");

            // To store unique ticker names
            HashSet<string> uniqueTickers = new HashSet<string>();

            // Iterate through the files to get ticker names
            foreach (string csvFile in csvFiles)
            {
                string[] fileNameParts = Path.GetFileNameWithoutExtension(csvFile).Split('-');

                if (fileNameParts.Length >= 1)
                {
                    string tickerName = fileNameParts[0];
                    uniqueTickers.Add(tickerName);
                }
            }

            comboBox1_ticker.Items.Clear();
            comboBox1_ticker.Items.AddRange(uniqueTickers.ToArray());
        }

        // Function to set the time period
        private void radioButton_CheckedChanged_setPeriod(object sender, EventArgs e)
        {
            if (radioButton1_daily.Checked)
            {
                timePeriod = "Day";
            }
            else if (radioButton2_weekly.Checked)
            {
                timePeriod = "Week";
            }
            else if (radioButton3_monthly.Checked)
            {
                timePeriod = "Month";
            }
        }

        // Function to get the relative path of the Stock Data folder
        public string getFolderPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string parentDirectory = Directory.GetParent(currentDirectory).FullName;
            string parentDirectory1 = Directory.GetParent(parentDirectory).FullName;
            string parentDirectory2 = Directory.GetParent(parentDirectory1).FullName;
            string parentDirectory3 = Directory.GetParent(parentDirectory2).FullName;
            string parentDirectory4 = Directory.GetParent(parentDirectory3).FullName;
            string stockDataPath = Path.Combine(parentDirectory4, "Stock Data");
            return stockDataPath;
        }

        // Function to view ticker information when button is clicked  
        private void button1_viewTicker_Click(object sender, EventArgs e)
        {
            // Check if a ticker is selected
            if (comboBox1_ticker.SelectedIndex == -1)
            {
                // Error, no ticker selected
                MessageBox.Show("Please select a ticker symbol.", "No Ticker Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Look for file matching ticker symbol and date period and open it
            string fileName = comboBox1_ticker.SelectedItem.ToString() + "-" + timePeriod + ".csv";
            string stockDataPath = getFolderPath();
            string filePath = Path.Combine(stockDataPath, fileName);

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Debug.WriteLine($"File not found: {filePath}");
                MessageBox.Show("File not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BindingList<smartCandlestick> candlesticks = readData(filePath);

            // Change to the next form
            String tickerName = comboBox1_ticker.SelectedItem.ToString() + "-" + timePeriod;
            newStockForm(candlesticks, tickerName);
        }

        // Function to use and open a CSV file for stock data
        private void openFile(object sender, EventArgs e)
        {
            // OpenFileDialog
            DialogResult result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                foreach (String filePath in openFileDialog1.FileNames)
                {
                    String tickerName = Path.GetFileNameWithoutExtension(filePath);
                    BindingList<smartCandlestick> candlesticks = readData(filePath);

                    // Change to the next form
                    newStockForm(candlesticks, tickerName);
                }
            }
            else
            {
                // Error opening selected file
                MessageBox.Show("Unable to open selected file. Please try again.", "Unable to open selected file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        // Function to read data from .csv file
        private BindingList<smartCandlestick> readData(string filePath)
        {
            BindingList<smartCandlestick> candlesticks = new BindingList<smartCandlestick>();
            string referenceString = "\"Ticker\",\"Period\",\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (line != referenceString)
                    {
                        // Pass the data to create a candlestick object
                        smartCandlestick cs = new smartCandlestick(line);
                        DateTime csDate = DateTime.Parse(cs.date);
                        candlesticks.Add(cs);
                    }
                }
            }

            // To get the candlesticks in ascending order
            List<smartCandlestick> reversedList = candlesticks.ToList();
            reversedList.Reverse();
            BindingList<smartCandlestick> ascCandlesticks = new BindingList<smartCandlestick>(reversedList);

            return ascCandlesticks;
        }

        // Function to load the stock information in another form
        private void newStockForm(BindingList<smartCandlestick> candlesticks, String tickerName)
        {
            Form2 form2 = new Form2(tickerName, candlesticks);
            form2.Text = tickerName;
            form2.Show();
        }
    }
}