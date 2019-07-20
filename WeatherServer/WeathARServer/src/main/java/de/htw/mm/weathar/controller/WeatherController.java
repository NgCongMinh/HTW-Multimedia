package de.htw.mm.weathar.controller;

import de.htw.mm.weathar.model.GermanCity;
import de.htw.mm.weathar.model.JsonResponse;
import de.htw.mm.weathar.model.WeatherForecast;
import de.htw.mm.weathar.model.error.NotDefinedException;
import de.htw.mm.weathar.service.WeatherService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import tk.plogitech.darksky.forecast.ForecastException;

/**
 * API endpoint /weather.
 *
 * @author Cong Minh Nguyen, Tuan Tung Tran
 * @date 20.07.2019
 */
@Controller
@RequestMapping("weather")
public class WeatherController {

    @Autowired
    private WeatherService service;

    /**
     * Returns a response which contains the weather data for the given city.
     * @param city  weather data for the requested city
     * @return response which contains the weather data
     * @throws ForecastException failed to request dark sky api
     * @throws NotDefinedException given city is not defined
     */
    @RequestMapping(
            method = RequestMethod.GET,
            produces = MediaType.APPLICATION_JSON_UTF8_VALUE)
    public ResponseEntity<JsonResponse> getWeather(@RequestParam("city") String city) throws ForecastException, NotDefinedException {

        GermanCity germanCity = GermanCity.getCity(city);
        if (germanCity == null) {
            throw new NotDefinedException("City " + city + " is not defined.");
        }

        WeatherForecast weatherForecast = service.getWeather(germanCity);
        return new ResponseEntity<>(new JsonResponse(weatherForecast), HttpStatus.OK);
    }

}