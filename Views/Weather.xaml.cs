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
            // Implement share functionality here
            await DisplayAlert("Share", "Weather information shared!", "OK");
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            // Implement save functionality here
            await DisplayAlert("Save", "Weather information saved!", "OK");
        }
    }
}
