using System;

namespace Model
{
    /**
     * Representation of the weather forecase construct. Is used as a wrapper object for the response json.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     * 
     */
    [Serializable]
    public class WeatherForecast
    {
        public WeatherReport today { set; get; }

        public WeatherReport tomorrow { set; get; }

        public WeatherReport dayAfterTomorrow { set; get; }
    }
}