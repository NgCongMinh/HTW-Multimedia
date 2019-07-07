package de.htw.mm.weathar.controller;

import de.htw.mm.weathar.model.Errors;
import de.htw.mm.weathar.model.JsonResponse;
import de.htw.mm.weathar.model.error.NotDefinedException;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.context.request.WebRequest;
import org.springframework.web.servlet.mvc.method.annotation.ResponseEntityExceptionHandler;
import tk.plogitech.darksky.forecast.ForecastException;

@ControllerAdvice
@RestController
public class ExceptionController extends ResponseEntityExceptionHandler {

    @ExceptionHandler(ForecastException.class)
    public final ResponseEntity<JsonResponse> handleDarkSkyError(ForecastException ex, WebRequest request) {
        ex.printStackTrace();
        return new ResponseEntity<>(new JsonResponse(Errors.DARK_SKY_SERVICE_ERROR), HttpStatus.SERVICE_UNAVAILABLE);
    }

    @ExceptionHandler(NotDefinedException.class)
    public final ResponseEntity<JsonResponse> handleNotDefinedArgument(NotDefinedException ex, WebRequest request) {
        ex.printStackTrace();
        return new ResponseEntity<>(new JsonResponse(Errors.NOT_DEFINED), HttpStatus.BAD_REQUEST);
    }

}
