using Model;
using UnityEngine;

namespace Util
{
    /**
     * Util class which converts the WeatherPhenomena to a readable text.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     * 
     */
    public static class WeatherPhenomenaMapper
    {
        /**
         * Converts the given phenomena to a readable text.
         * 
         * @param[in] col collider object
         */
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