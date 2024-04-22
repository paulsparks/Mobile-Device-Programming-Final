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
        
                // Construct the message to share
                var message = $"Temperature: {temperature}°F\nForecast: {detailedForecast}";
        
                // Share the message using the built-in share functionality
                await Share.RequestAsync(new ShareTextRequest
                {
                    Title = "Weather Information",
                    Text = message
                });
            }
            else
            {
                await DisplayAlert("Weather Information", "Weather data is not available.", "OK");
            }
        }


        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (ViewModel.Forecast != null)
            {
                var temperature = ViewModel.Forecast.properties.periods[0].temperature;
                var detailedForecast = ViewModel.Forecast.properties.periods[0].detailedForecast;
        
                // Construct the message to save
                var message = $"Temperature: {temperature}°F\nForecast: {detailedForecast}";
        
                // Save the message to the clipboard
                await Clipboard.SetTextAsync(message);
        
                await DisplayAlert("Save", "Weather information saved to clipboard!", "OK");
            }
            else
            {
                await DisplayAlert("Save", "Weather data is not available.", "OK");
            }
        }
    }
}
