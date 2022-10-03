using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Home24_Асинхронне_програмування_
{
    class Program
    {

        string API = "025f73b9b662ae95cf1adc73a02b8cfa";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter city name");
            string cityName = Console.ReadLine();
            string urlCity = $"https://api.openweathermap.org/data/2.5/weather?q=London&units=metric&appid=025f73b9b662ae95cf1adc73a02b8cfa";
            HttpWebRequest  httpRequest = (HttpWebRequest)WebRequest.Create(urlCity);
            HttpWebResponse  httpResponce = (HttpWebResponse)httpRequest.GetResponse();

            string answer;
            using (StreamReader streamReader = new StreamReader(httpResponce.GetResponseStream()))
            {
                answer = streamReader.ReadToEnd();
            }
            WeatherHope weatherHope = JsonConvert.DeserializeObject<WeatherHope>(answer);
            Console.WriteLine("Temperature in {0} : {1} ℃", weatherHope.Name, weatherHope.Main.Temp);
            Console.ReadLine();
        }


    }
}
//checked
