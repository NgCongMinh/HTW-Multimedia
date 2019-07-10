using System;

namespace Model
{
    [Serializable]
    public class WeatherForecast
    {
        public WeatherReport today { set; get; }

        public WeatherReport tomorrow { set; get; }

        public WeatherReport dayAfterTomorrow { set; get; }
    }
}