namespace Model
{
    public enum DayType
    {
        Today,

        Tomorrow,

        DayAfterTomorrow
    }

    public static class DayTypeConverter
    {
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