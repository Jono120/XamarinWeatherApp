using System;
using System.Threading.Tasks;

namespace WeatherLibrary
{
    public class Core  
    {  
        public static async Task<Weather> GetWeather(string zipCode)  
        {  
            //Sign up for a free API key at http://openweathermap.org/appid  
            string key = "ca398670ddd104dd70a63acc40ec7943";  
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip="  
                                 + zipCode + ",us&appid=" + key + "&units=metric";  

            //Make sure developers running this sample replaced the API key
            if (key == "ca398670ddd104dd70a63acc40ec7943")
            {
                throw new ArgumentException("You must obtain an API key from openweathermap.org/appid and save it in the 'key' variable.");
            }

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);  

            if (results["weather"] != null)  
            {  
                Weather weather = new Weather();  
                weather.Title = (string)results["name"];                  
                weather.Temperature = (string)results["main"]["temp"] + " F";  
                weather.Wind = (string)results["wind"]["speed"] + " mph";                  
                weather.Humidity = (string)results["main"]["humidity"] + " %";  
                weather.Visibility = (string)results["weather"][0]["main"];  

                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0);  
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);  
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);  
                weather.Sunrise = sunrise.ToString() + " NZDT";  
                weather.Sunset = sunset.ToString() + " NZDT";  
                return weather;  
            }  
            else  
            {  
                return null;  
            }  
        }  
    }  
}  
