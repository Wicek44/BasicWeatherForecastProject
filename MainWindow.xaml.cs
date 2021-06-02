using OpenWeatherLibraryJson;
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

namespace BasicWeatherForecast
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // OpenWeatherClient openWeatherClient;

        WeatherForecastManager weatherForecastManager;

        public MainWindow()
        {
            InitializeComponent();
            weatherForecastManager = new WeatherForecastManager();
            DataContext = weatherForecastManager;
        }

        private async void InputCityNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            { 
                await weatherForecastManager.GetAndDisplayWeatherInfoData(InputCityNameBox.Text);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

    }
}
