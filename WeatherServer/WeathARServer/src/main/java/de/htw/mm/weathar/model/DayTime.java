package de.htw.mm.weathar.model;

public enum DayTime {

    // 8 o'clock
    MORNING(8),

    // 12 o'clock
    NOON(12),

    //16 o'clock
    EVENING(16),

    // 20 o'clock
    NIGHT(20);

    private int hour;

    DayTime(int hour) {
        this.hour = hour;
    }

    public int getHour() {
        return hour;
    }

}
