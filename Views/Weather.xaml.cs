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
    }
}
