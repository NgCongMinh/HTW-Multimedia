using System;

namespace Model
{
    [Serializable]
    public class WeatherData
    {
        public double temperature;

        public DayTime dayTime;

        public WeatherPhenomena phenomena;
    }
}