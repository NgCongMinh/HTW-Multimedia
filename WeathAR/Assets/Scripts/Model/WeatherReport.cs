using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class WeatherReport
    {
        public string date { set; get; }

        public string location { set; get; }

        public Dictionary<DayTime, WeatherData> data { set; get; }
    }
}