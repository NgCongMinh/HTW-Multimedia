package de.htw.mm.weathar.model;

import java.util.HashMap;
import java.util.Map;

public class WeatherReport {

    private String date;

    private String location;

    private Map<DayTime, WeatherData> data;

    public WeatherReport() {
        data = new HashMap<>();
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public String getLocation() {
        return location;
    }

    public void setLocation(String location) {
        this.location = location;
    }

    public Map<DayTime, WeatherData> getData() {
        return data;
    }

    public void setData(Map<DayTime, WeatherData> data) {
        this.data = data;
    }
}
