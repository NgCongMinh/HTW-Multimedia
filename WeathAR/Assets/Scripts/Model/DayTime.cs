using System;

namespace Model
{
    /**
     * Representation of specific times of a day.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     */
    [Serializable]
    public enum DayTime
    {
        // 8 o'clock
        MORNING,

        // 12 o'clock
        NOON,

        //16 o'clock
        EVENING,

        // 20 o'clock
        NIGHT
    }
}