using System;

namespace Model
{
    /**
     * Representation of the weather data construct.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     * 
     */
    [Serializable]
    public enum WeatherPhenomena
    {
        CLEAR,

        RAINY,

        CLOUDY,

        SNOWY,

        WINDY,

        FOGGY,

        UNDEFINED
    }
}