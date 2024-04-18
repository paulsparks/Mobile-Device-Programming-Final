using BearcatWeather;
using BearcatWeather.Models;
using BearcatWeather.Services;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BearcatWeather.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public Forecast? Forecast { get; set; }

        public async Task InitializeAsync()
        {
            Forecast = await WeatherService.GetForecastAsync();
            OnPropertyChanged(nameof(Forecast));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
