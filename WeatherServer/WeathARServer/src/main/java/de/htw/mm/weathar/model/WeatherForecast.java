package de.htw.mm.weathar.model;

public class WeatherForecast {

    private WeatherReport today;

    private WeatherReport tomorrow;

    private WeatherReport dayAfterTomorrow;

    public WeatherReport getToday() {
        return today;
    }

    public void setToday(WeatherReport today) {
        this.today = today;
    }

    public WeatherReport getTomorrow() {
        return tomorrow;
    }

    public void setTomorrow(WeatherReport tomorrow) {
        this.tomorrow = tomorrow;
    }

    public WeatherReport getDayAfterTomorrow() {
        return dayAfterTomorrow;
    }

    public void setDayAfterTomorrow(WeatherReport dayAfterTomorrow) {
        this.dayAfterTomorrow = dayAfterTomorrow;
    }
}
