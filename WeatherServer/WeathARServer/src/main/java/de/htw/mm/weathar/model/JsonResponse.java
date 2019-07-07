package de.htw.mm.weathar.model;

import com.fasterxml.jackson.annotation.JsonCreator;
import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonSetter;

@JsonInclude(value = JsonInclude.Include.NON_NULL)
public class JsonResponse {

    public static final JsonResponse EMPTY = new JsonResponse();

    @JsonProperty("data")
    private Object payload;

    private Error error;

    @JsonCreator
    public JsonResponse() {
    }

    public JsonResponse(Object payload) {
        this.payload = payload;
    }

    public JsonResponse(int errorCode, String errorMessage) {
        this.error = new Error(errorCode, errorMessage);
    }

    public JsonResponse(Errors errors) {
        this.error = new Error(errors.getCode(), errors.getMessage());
    }

    public Object getPayload() {
        return this.payload;
    }

    @JsonSetter
    public void setPayload(Object payload) {
        this.payload = payload;
    }

    public Error getError() {
        return this.error;
    }

    @JsonSetter
    public void setError(Error error) {
        this.error = error;
    }

    @JsonInclude(JsonInclude.Include.NON_DEFAULT)
    public static class Error {

        private int code;

        private String message;

        @JsonCreator
        public Error() {
        }

        public Error(int code, String message) {
            this.code = code;
            this.message = message;
        }

        public int getCode() {
            return this.code;
        }

        public void setCode(int code) {
            this.code = code;
        }

        public String getMessage() {
            return this.message;
        }

        public void setMessage(String message) {
            this.message = message;
        }

    }

}
