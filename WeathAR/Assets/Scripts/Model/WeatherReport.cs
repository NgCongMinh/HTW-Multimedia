using System;
using System.Collections.Generic;

namespace Model
{
    /**
     * Representation of the weather report construct. Is used as a wrapper object for the response json.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     * 
     */
    [Serializable]
    public class WeatherReport
    {
        public string date { set; get; }

        public string location { set; get; }

        public Dictionary<DayTime, WeatherData> data { set; get; }
    }
}