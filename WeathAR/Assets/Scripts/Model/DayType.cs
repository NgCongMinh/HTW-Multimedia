namespace Model
{
    /**
     * Representation of specific type of a day.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     */
    public enum DayType
    {
        Today,

        Tomorrow,

        DayAfterTomorrow
    }

    /**
     * Util class which converts the DayType to a readable text.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     */
    public static class DayTypeConverter
    {
        /**
         * Converts the given dayType to a readable text.
         * 
         * @param[in] dayType day type
         */
        public static string getLabel(DayType dayType)
        {
            switch (dayType)
            {
                case DayType.Today:
                    return "Heute";
                case DayType.Tomorrow:
                    return "Morgen";
                case DayType.DayAfterTomorrow:
                    return "Übermorgen";
                default:
                    return null;
            }
        }
    }
}