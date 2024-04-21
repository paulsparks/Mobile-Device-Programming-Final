using BearcatWeather.ViewModels;

namespace BearcatWeather.Views
{
    public partial class Weather : ContentPage
    {
        private MainPageViewModel ViewModel;

        public Weather()
        {
            InitializeComponent();
            ViewModel = new MainPageViewModel();
            ViewModel.InitializeAsync();
            BindingContext = ViewModel;
        }
        
        private async void ShareButton_Clicked(object sender, EventArgs e)
        {
            if (ViewModel.Forecast != null)
            {
                var temperature = ViewModel.Forecast.properties.periods[0].temperature;
                var detailedForecast = ViewModel.Forecast.properties.periods[0].detailedForecast;
                
                // Display weather information
                await DisplayAlert("Weather Information", $"Temperature: {temperature}°F\nForecast: {detailedForecast}", "OK");
            }
            else
            {
                await DisplayAlert("Weather Information", "Weather data is not available.", "OK");
            }
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            // Implement save functionality here
            await DisplayAlert("Save", "Weather information saved!", "OK");
        }
    }
}
