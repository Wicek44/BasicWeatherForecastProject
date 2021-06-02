using OpenWeatherLibraryJson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BasicWeatherForecast
{
    class WeatherForecastManager : INotifyPropertyChanged
    {
        OpenWeatherClient openWeatherClient;

        protected readonly MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        private string _cityName;
        public string CityName
        {
            get
            {
                return _cityName;
            }

            set
            {
                _cityName = value;
                OnPropertyChanged();
            }
        }

        private string _countrySymbol;
        public string CountrySymbol
        {
            get
            {
                return _countrySymbol;
            }

            set
            {
                _countrySymbol = value;
                OnPropertyChanged();
            }
        }

        private string _countryName;
        public string CountryName
        {
            get
            {
                return _countryName;
            }

            set
            {
                _countryName = value;
                OnPropertyChanged();
            }
        }

        public string IconId;
        
        private float _temperatureFeelsLike;
        public float TemperatureFeelsLike
        {
            get
            {
                return _temperatureFeelsLike;
            }

            set
            {
                _temperatureFeelsLike = value;
                OnPropertyChanged();
            }
        }

        private string _cloudsState;
        public string CloudState
        {
            get
            {
                return _cloudsState;
            }

            set
            {
                _cloudsState = value;
                OnPropertyChanged();
            }
        }


        private float _maxTemperature;
        public float MaxTemperature
        {
            get
            {
                return _maxTemperature;
            }

            set
            {
                _maxTemperature = value;
                OnPropertyChanged();
            }
        }

        private float _minTemperature;
        public float MinTemperature
        {
            get
            {
                return _minTemperature;
            }

            set
            {
                _minTemperature = value;
                OnPropertyChanged();
            }
        }

        private float _windSpeed;
        public float WindSpeed
        {
            get
            {
                return _windSpeed;
            }

            set
            {
                _windSpeed = value;
                OnPropertyChanged();
            }
        }

        private float _humidity;
        public float Humidity
        {
            get
            {
                return _humidity;
            }

            set
            {
                _humidity = value;
                OnPropertyChanged();
            }
        }

        private float _pressure;
        public float Pressure
        {
            get
            {
                return _pressure;
            }

            set
            {
                _pressure = value;
                OnPropertyChanged();
            }
        }


        public WeatherForecastManager()
        {
            string apiKeyPath = @"KeyAPI.txt";
            string apiKey = File.ReadAllText(apiKeyPath);

            openWeatherClient = new OpenWeatherClient(apiKey);
        }


        public async Task GetAndDisplayWeatherInfoData(string nameOfCity)
        {

            var openWeatherInfo = await openWeatherClient.GetWeatherInfoAsync(nameOfCity);
            CityName = openWeatherInfo.NameOfCity;
            CountrySymbol = openWeatherInfo.CountryInfo.CountryInfo;
            IconId = openWeatherInfo.Weather[0].Icon;
            CloudState = openWeatherInfo.Weather[0].Description;
            TemperatureFeelsLike = openWeatherInfo.MainTemperature.TempereatureFeelsLike;
            MaxTemperature = openWeatherInfo.MainTemperature.TemperatureMax;
            MinTemperature = openWeatherInfo.MainTemperature.TemperatureMin;
            WindSpeed = openWeatherInfo.Wind.Speed;
            Humidity = openWeatherInfo.MainTemperature.Humidity;
            Pressure = openWeatherInfo.MainTemperature.Pressure;


            string iconId = openWeatherInfo.Weather[0].Icon;
            string selectedFileName = @"D:\ProgramData\VS\Aplikacje WPF\BasicWeatherForecast\weatherForecastIcons\" + iconId + ".png";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(selectedFileName, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            Image image = new Image();
            image.Source = bitmap;

            image.Width = 150;
            image.Height = 150;
            mainWindow.IconPlaceHolder.Children.Clear();
            mainWindow.IconPlaceHolder.Children.Add(image);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
