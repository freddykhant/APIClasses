using Newtonsoft.Json;
using RestSharp;
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

namespace ClientApp
{
    public partial class MainWindow : Window
    {
        private RestClient client;
        private string URL = "http://localhost:5116";

        public MainWindow()
        {
            InitializeComponent();

            client = new RestClient(URL);
        }

        private async void GoButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IndexBox.Text))
            {
                MessageBox.Show("Please enter an index.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int index;
            if (!Int32.TryParse(IndexBox.Text, out index))
            {
                MessageBox.Show("Please enter a valid index.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            RestRequest request = new RestRequest("api/data/" + index.ToString());


            // Using ExecuteAsync to make it asynchronous
            RestResponse resp = await client.ExecuteAsync(request);

            if (resp.IsSuccessful)
            {
                APIClasses.DataIntermed dataIntermed = JsonConvert.DeserializeObject<APIClasses.DataIntermed>(resp.Content);
                UpdateGui(dataIntermed);
            }
            else
            {
                MessageBox.Show($"Error fetching data: {resp.StatusDescription}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                MessageBox.Show("Please enter a search string.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            APIClasses.SearchData mySearch = new APIClasses.SearchData();
            mySearch.searchStr = SearchBox.Text;

            RestRequest request = new RestRequest("api/data/search/");
            request.AddJsonBody(mySearch);
            RestResponse resp = client.Post(request);

            // Using ExecuteAsync to make it asynchronous
            //RestResponse resp = await client.ExecuteAsync(request);

            if (resp.IsSuccessful)
            {
                APIClasses.DataIntermed dataIntermed = JsonConvert.DeserializeObject<APIClasses.DataIntermed>(resp.Content);
                UpdateGui(dataIntermed);
            }
            else
            {
                MessageBox.Show($"Error fetching data: {resp.StatusDescription}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void UpdateGui(APIClasses.DataIntermed account)
        {
            if (account != null)
            {
                FNameBox.Text = account.fname;
                LNameBox.Text = account.lname;
                BalanceBox.Text = account.bal.ToString("C");
                AcctNoBox.Text = account.acct.ToString();
                PinBox.Text = account.pin.ToString("D4");

            }
        }
    }
}
