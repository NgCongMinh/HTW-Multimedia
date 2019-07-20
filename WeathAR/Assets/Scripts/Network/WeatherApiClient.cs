using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Model;
using UnityEngine;
using UnityEngine.Networking;

namespace Network
{
    
    /**
     * API Client which communicates to the custom weather api.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     * 
     */
    public class WeatherApiClient : MonoBehaviour
    {
        private const string Url = "http://localhost:8080";

        private const string WeatherPath = "/weather";

        private static Dictionary<string, WeatherForecast> cache;

        public void Start()
        {
            cache = new Dictionary<string, WeatherForecast>();
        }

        /**
         * @param[in] city city to request the weather data from
         * @param[in] callback callback handles the response accordingly
         */
        public void GetWeather(string city, Action<WeatherForecast> callback)
        {
            StartCoroutine(RequestRoutine(Url + WeatherPath + "?city=", city, callback));
        }

        private static IEnumerator RequestRoutine(string url, string city, Action<WeatherForecast> callback)
        {
            if (cache.ContainsKey(city))
            {
                callback(cache[city]);
            }
            else
            {
                // Using the static constructor
                UnityWebRequest request = UnityWebRequest.Get(url + city);

                // Wait for the response and then get our data
                yield return request.SendWebRequest();

                string data = request.downloadHandler.text;
                Debug.Log(data);

                JSONObject jsonObject = new JSONObject(data)["data"];

                WeatherForecast weatherForecast = ConvertToWeatherForecast(jsonObject);

                cache[city] = weatherForecast;

                callback(weatherForecast);
            }
        }

        private static WeatherForecast ConvertToWeatherForecast(JSONObject json)
        {
            return new WeatherForecast
            {
                today = ConvertToWeatherReport(json["today"]),
                tomorrow = ConvertToWeatherReport(json["tomorrow"]),
                dayAfterTomorrow = ConvertToWeatherReport(json["dayAfterTomorrow"])
            };
        }

        private static WeatherReport ConvertToWeatherReport(JSONObject json)
        {
            return new WeatherReport
            {
                date = json["date"].str,
                location = json["location"].str,
                data = ConvertToOverview(json["data"])
            };
        }

        private static Dictionary<DayTime, WeatherData> ConvertToOverview(JSONObject json)
        {
            Dictionary<DayTime, WeatherData> overview = new Dictionary<DayTime, WeatherData>();

            foreach (string key in json.keys)
            {
                DayTime dayTime = (DayTime) Enum.Parse(typeof(DayTime), key);
                overview[dayTime] = ConvertToWeatherData(json[key]);
            }

            return overview;
        }

        private static WeatherData ConvertToWeatherData(JSONObject json)
        {
            WeatherData weatherData = new WeatherData();

            double result;
            string temp = json["temperature"].str.Replace(".", ",");
            
            // CAUTION for iOS
            //string temp = json["temperature"].str;
            
            
            //Try parsing in the current culture
            if (!double.TryParse(temp, NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                //Then try in US english
                !double.TryParse(temp, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"),
                    out result) &&
                //Then in neutral language
                !double.TryParse(temp, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = 0.0;
            }

            weatherData.temperature = result;

            DayTime dayTime;
            Enum.TryParse(json["dayTime"].str, true, out dayTime);
            weatherData.dayTime = dayTime;

            WeatherPhenomena phenomena;
            Enum.TryParse(json["phenomena"].str, true, out phenomena);
            weatherData.phenomena = phenomena;

            return weatherData;
        }
    }
}