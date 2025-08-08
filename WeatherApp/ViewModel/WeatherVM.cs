using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WeatherApp.Model;
using WeatherApp.ViewModel.Helpers;
using WeatherApp.ViewModel.Commands;
using System.Collections.ObjectModel;
namespace WeatherApp.ViewModel
{
    internal class WeatherVM : INotifyPropertyChanged
    {
        private string query;

        public string Query
        {
            get { return query; }
            set
            {
                query = value;

                OnPropertyChanged(nameof(Query));
            }
        }

        public ObservableCollection<City> Cities { get; set; }

        private CurrentConditions? currentConditions;

        public CurrentConditions? CurrentConditions
        {
            get { return currentConditions; }
            set
            {
                currentConditions = value;

                OnPropertyChanged(nameof(CurrentConditions));
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnPropertyChanged(nameof(SelectedCity));
                GetCurrentConditions();
            }
        }

        public SearchCommand SearchCommand { get; set; }


        public WeatherVM()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                SelectedCity = new City()
                {
                    LocalizedName = "New York"
                };

                CurrentConditions = new CurrentConditions()
                {
                    WeatherText = "Partly cloudy",
                    Temperature = new Temperature()
                    {
                        Metric = new Units()
                        {
                            Value = "21"
                        }
                    }
                };
            }

            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();
        }

        private async void GetCurrentConditions()
        {
            Query = string.Empty;
            Cities?.Clear();
            CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
        }
        public async void MakeQuery()
        {
            List<City>? cities = new();
            cities = await AccuWeatherHelper.GetCities(Query);
            Cities.Clear();
            if (cities != null)
            {
                foreach (var city in cities)
                {
                    Cities.Add(city);
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}
