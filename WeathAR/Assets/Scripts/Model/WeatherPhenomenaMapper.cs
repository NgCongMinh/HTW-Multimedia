using UnityEngine;

namespace Model
{
    public class WeatherPhenomenaMapper
    {
        public static Material GetWeatherMaterial(WeatherPhenomena phenomena)
        {
            switch (phenomena)
            {
                case WeatherPhenomena.CLEAR:
                    return Resources.Load("Materials/sunny") as Material;
                case WeatherPhenomena.FOGGY:
                    return Resources.Load("Materials/schnee") as Material;
                case WeatherPhenomena.RAINY:
                    return Resources.Load("Materials/rainy") as Material;
                case WeatherPhenomena.SNOWY:
                    return Resources.Load("Materials/snowy") as Material;
                case WeatherPhenomena.WINDY:
                    return Resources.Load("Materials/schnee") as Material;
                case WeatherPhenomena.CLOUDY:
                    return Resources.Load("Materials/cloudy") as Material;
                case WeatherPhenomena.UNDEFINED:
                default:
                    return null;
            }
        }
    }
}