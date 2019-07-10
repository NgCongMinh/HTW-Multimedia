package de.htw.mm.weathar.model;

public class WeatherData {

    private String temperature;

    private DayTime dayTime;

    private WeatherPhenomena phenomena;

    public String getTemperature() {
        return temperature;
    }

    public void setTemperature(String temperature) {
        this.temperature = temperature;
    }

    public DayTime getDayTime() {
        return dayTime;
    }

    public void setDayTime(DayTime dayTime) {
        this.dayTime = dayTime;
    }

    public WeatherPhenomena getPhenomena() {
        return phenomena;
    }

    public void setPhenomena(WeatherPhenomena phenomena) {
        this.phenomena = phenomena;
    }
}
