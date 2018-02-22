﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherLibrary
{
    class DataService
    {
        public static async Task<dynamic> GetDataFromService(string queryString)  
        {  
            HttpClient client = new HttpClient();  
            var response = await client.GetAsync(queryString);  

            dynamic data = null;  
            if (response != null)  
            {  
                string json = response.Content.ReadAsStringAsync().Result;  
                data = JsonConvert.DeserializeObject(json);  
            }  

            return data;  
        }

        internal static Task<dynamic> getDataFromService(string queryString)
        {
            throw new NotImplementedException();
        }
    }
}
