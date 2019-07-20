namespace Util
{
    /**
     * Util class which converts the celsius to fahrenheit.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     *
     */
    public static class TemperatureConverter
    {
        /**
         * Converts celsius to fahrenheit.
         *
         * @param[in] celsius celsius value
         */
        public static double ToFahrenheit(double celsius)
        {
            return celsius * 33.8;
        }
    }
}