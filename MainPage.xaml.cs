using BearcatWeather.Views;

namespace BearcatWeather
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Navigation.PushAsync(new Weather());
        }
    }
}
