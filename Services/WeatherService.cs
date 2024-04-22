using BearcatWeather.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace BearcatWeather.Services
{
    public class WeatherService
    {
        public static async Task<Forecast?> GetForecastAsync()
        {
            try
            {
                string apiUrl = "https://api.weather.gov/gridpoints/ILN/36,38/forecast/hourly";
                string userAgent = "(sparkspaul.com, psparks1225@gmail.com)";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", userAgent);

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStreamAsync();
                        try
                        {
                            var weatherResult = await JsonSerializer.DeserializeAsync<Forecast>(content);
                            Debug.WriteLine("WEATHER DATA:\n" + await response.Content.ReadAsStringAsync());

                            //Celcius Conversion
                            if (weatherResult?.properties?.periods != null)
                            {
                                foreach (var period in weatherResult.properties.periods)
                                {
                                    if (period.temperature != null)
                                    {
                                        period.tempC = FahrenheitToCelsius(period.temperature.Value);
                                    }
                                }
                            }
                            return weatherResult;
                        } 
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                            return null;
                        }
                    }
                    else
                    {
                        return JsonSerializer.Deserialize<Forecast>("{" +  $"'Error': '{response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                return JsonSerializer.Deserialize<Forecast>("{" + $"'Exception': '{ex.Message}'" + "}");
            }
        }

        private static int FahrenheitToCelsius(int fahrenheit)
        {
            return (int)((fahrenheit - 32) * 5 / 9);
        }
    }
}
