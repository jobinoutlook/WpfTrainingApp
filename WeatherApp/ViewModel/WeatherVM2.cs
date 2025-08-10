using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    internal class WeatherVM2 : INotifyPropertyChanged
    {
        private string query;

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                WVM2PropertyChanged(nameof(Query));
            }
        }

        public ObservableCollection<City> Cities { get; set; }

        private CurrentConditions currentConditions;

        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set
            {
                currentConditions = value;
                WVM2PropertyChanged(nameof(CurrentConditions));
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set { selectedCity = value; 
            
                WVM2PropertyChanged(nameof(SelectedCity));
                GetCurrentConditions();
            }
        }

        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper2.GetCities(Query);
            Cities.Clear();
            foreach(City city in cities)
            {
                Cities.Add(city);
            }
        }

        private async void GetCurrentConditions()
        {
            Query = string.Empty;
            Cities.Clear();
            var currentConditions = await AccuWeatherHelper2.GetCurrentConditions(selectedCity.Key);
            if(currentConditions != null)
                CurrentConditions = currentConditions;
        }

        //============================================================
        public event PropertyChangedEventHandler? PropertyChanged;

        private void WVM2PropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public SearchCommand2 SearchCommand2 { get; set; }

        public WeatherVM2()
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

            SearchCommand2 =new SearchCommand2(this);
            Cities = new ObservableCollection<City>();
        }
    }
}
