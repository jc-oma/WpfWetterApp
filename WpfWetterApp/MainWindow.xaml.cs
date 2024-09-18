using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace WpfWetterApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //TODO ViewModel erstellen
        private async void Get_Weather_Click(object sender, RoutedEventArgs e)
        {
            text_block_temperatur.Text = "Downloading...";
            var data = await GetWeather();
            if (data == null)
            {
                text_block_temperatur.Text = "Fehler beim Laden der Daten";
            }
            else
            {
                var temperature = KelvinToCelsiús(data.Main.Temp);
                text_block_temperatur.Text = temperature.ToString("0.00") + " °C";
            }
        }

        private double KelvinToCelsiús(double temp)
        {
            double offset = -272.15;
            return temp + offset;
        }

        //TODO in einen Service auslagern
        public async Task<_200?> GetWeather()
        {
            var httpClient = new HttpClient();
            var apiClient = new WebAPI(httpClient);
            var task = apiClient.CurrentWeatherDataAsync(q: "Rostock",id: "18051", lon: "12.14", lat: "54.08", zip: "18051", mode:null,units: null, lang: null);
            return await task;
        }
    }
}
