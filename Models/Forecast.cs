using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls.Shapes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BearcatWeather.Models
{
    public partial class Forecast
    {
        public string? Error { get; set; } = null;

        public Properties? properties { get; set; }
    }

    public class Properties
    {
        public List<Period>? periods { get; set; }
    }

    public class Period
    {
        public int? temperature { get; set; } = null;
        public string? detailedForecast { get; set; } = null;
    }
}
