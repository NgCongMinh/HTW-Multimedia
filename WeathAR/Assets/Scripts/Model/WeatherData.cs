using System;

namespace Model
{
    /**
     * Representation of the weather data construct. Is used as a wrapper object for the response json.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     * 
     */
    [Serializable]
    public class WeatherData
    {
        public double temperature;

        public DayTime dayTime;

        public WeatherPhenomena phenomena;
    }
}