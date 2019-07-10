package de.htw.mm.weathar.service;

import de.htw.mm.weathar.model.*;
import org.springframework.stereotype.Service;
import tk.plogitech.darksky.api.jackson.DarkSkyJacksonClient;
import tk.plogitech.darksky.forecast.*;
import tk.plogitech.darksky.forecast.model.*;

import java.time.Duration;
import java.time.Instant;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.time.format.DateTimeFormatter;
import java.util.HashMap;
import java.util.Map;

@Service
public class WeatherService {

    private static final String DARK_SKY_AUTH_KEY = "d1ae6e74c33884459cd2d21e13cb7329";

    public WeatherForecast getWeather(GermanCity city) throws ForecastException {
        Double longitude = city.getLongitude();
        Double latitude = city.getLatitude();

        Instant today = Instant.now();
        Forecast todayForecast = requestDarkSky(
                longitude,
                latitude,
                today
        );

        Instant tomorrow = Instant.now().plus(Duration.ofDays(1));
        Forecast tomorrowForecast = requestDarkSky(
                longitude,
                latitude,
                tomorrow
        );

        Instant dayAfterTomorrow = Instant.now().plus(Duration.ofDays(2));
        Forecast dayAfterTomorrowForecast = requestDarkSky(
                longitude,
                latitude,
                dayAfterTomorrow
        );

        WeatherForecast weatherForecast = new WeatherForecast();
        weatherForecast.setToday(convert(today, todayForecast));
        weatherForecast.setTomorrow(convert(tomorrow, tomorrowForecast));
        weatherForecast.setDayAfterTomorrow(convert(dayAfterTomorrow, dayAfterTomorrowForecast));

        return weatherForecast;
    }

    private Forecast requestDarkSky(double longitude, double latitude, Instant instant) throws ForecastException {
        ForecastRequest request = new ForecastRequestBuilder()
                .key(new APIKey(DARK_SKY_AUTH_KEY))
                .location(new GeoCoordinates(new Longitude(longitude), new Latitude(latitude)))
                .time(instant)
                .exclude(
                        ForecastRequestBuilder.Block.currently,
                        ForecastRequestBuilder.Block.minutely,
                        ForecastRequestBuilder.Block.daily
                )
                .build();

        DarkSkyJacksonClient client = new DarkSkyJacksonClient();

        return client.forecast(request);
    }

    private WeatherReport convert(Instant date, Forecast forecast) {
        Map<DayTime, WeatherData> data = new HashMap<>();

        LocalDateTime dateTime = LocalDateTime.ofInstant(date, ZoneId.of("Europe/Berlin"));

        Hourly hourly = forecast.getHourly();
        for (HourlyDataPoint dataPoint : hourly.getData()) {

            LocalDateTime ldt = LocalDateTime.ofInstant(dataPoint.getTime(), ZoneId.of("Europe/Berlin"));

            // only same amount as daytime entries
            if (data.size() == DayTime.values().length) {
                break;
            }

            // same day
            if (ldt.getDayOfMonth() != dateTime.getDayOfMonth()) {
                continue;
            }

            if (ldt.getHour() == DayTime.MORNING.getHour()) {
                data.put(DayTime.MORNING, convertToWeatherData(DayTime.MORNING, dataPoint));
            }
            if (ldt.getHour() == DayTime.NOON.getHour()) {
                data.put(DayTime.NOON, convertToWeatherData(DayTime.NOON, dataPoint));
            }
            if (ldt.getHour() == DayTime.EVENING.getHour()) {
                data.put(DayTime.EVENING, convertToWeatherData(DayTime.EVENING, dataPoint));
            }
            if (ldt.getHour() == DayTime.NIGHT.getHour()) {
                data.put(DayTime.NIGHT, convertToWeatherData(DayTime.NIGHT, dataPoint));
            }
        }

        WeatherReport weatherReport = new WeatherReport();
        weatherReport.setData(data);
        weatherReport.setLocation(forecast.getTimezone());
        weatherReport.setDate(dateTime.format(DateTimeFormatter.ofPattern("dd/MM/yyyy")));

        return weatherReport;
    }

    private WeatherData convertToWeatherData(DayTime dayTime, HourlyDataPoint dailyDataPoint) {
        WeatherData data = new WeatherData();
        data.setPhenomena(getWeatherPhenomena(dailyDataPoint.getIcon()));
        data.setDayTime(dayTime);
        data.setTemperature(dailyDataPoint.getTemperature().toString());
        return data;
    }

    private WeatherPhenomena getWeatherPhenomena(String icon) {
        switch (icon) {
            case "clear-day":
            case "clear-night":
                return WeatherPhenomena.CLEAR;
            case "rain":
                return WeatherPhenomena.RAINY;
            case "cloudy":
            case "partly-cloudy-night":
            case "partly-cloudy-day":
                return WeatherPhenomena.CLOUDY;
            case "snow":
            case "sleet":
                return WeatherPhenomena.SNOWY;
            case "wind":
                return WeatherPhenomena.WINDY;
            case "fog":
                return WeatherPhenomena.FOGGY;
            default:
                return WeatherPhenomena.UNDEFINED;
        }
    }


}
