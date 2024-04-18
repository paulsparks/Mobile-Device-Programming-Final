using BearcatWeather.ViewModels;

namespace BearcatWeather
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel ViewModel;

        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainPageViewModel();
            ViewModel.InitializeAsync();
            BindingContext = ViewModel;
        }
    }

}
