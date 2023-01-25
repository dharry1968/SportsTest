using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;


namespace SportsTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dt;
        public MainWindow()
        {
            InitializeComponent();
            lstPlayers.SelectionChanged += new SelectionChangedEventHandler(lstPlayers_SelectedIndexChanged);
            dt = new DataTable();
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("Surname", typeof(string));
            dt.Columns.Add("Age", typeof(string));
            dt.Columns.Add("Height", typeof(string));
            dt.Columns.Add("DOB", typeof(string));
            dt.Columns.Add("Country", typeof(string));
            dt.Columns.Add("Continent", typeof(string));
            this.DataContext = dt;
        }

        private async void btngetPlayers_Click(object sender, RoutedEventArgs e)
        {
            string apiKey = "1d4ee500-9bcb-11ed-b1b1-4ff2250657fc";
            var response = await GetPlayers(apiKey);
            if (response != null)
            {
                RootObject data = JsonConvert.DeserializeObject<RootObject>(response);
                foreach (var player in data.data)
                {
                    dt.Rows.Add(player.firstname, player.lastname, player.age, player.height, player.birthday, player.country.name, player.country.continent);
                }
            }
            else
            {
                txtStatus.Text = "No Data Recieved";
            }
        }

        static async Task<string> GetPlayers(string apikey)
        {
            using (var client = new HttpClient())
            {
                var url = "https://app.sportdataapi.com/api/v1/soccer/players?apikey=" + apikey + "&country_id=42";
                var resp = await client.GetAsync(url);
                if (resp.IsSuccessStatusCode)
                {
                    return await resp.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }

        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)lstPlayers.SelectedItem;

            if (selectedRow != null)
            {
                string name = (string)selectedRow["FirstName"] + " " + (string)selectedRow["Surname"];
                txtPlayerName.Text = name;
            }
        }
    }
}

