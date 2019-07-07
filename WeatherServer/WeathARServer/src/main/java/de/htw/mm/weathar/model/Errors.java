package de.htw.mm.weathar.model;

public enum Errors {

    // error code format:  XXXYYY

    // third party : dark sky
    DARK_SKY_SERVICE_ERROR(100001, "DarkSky service not reachable."),

    // general
    NOT_DEFINED(200001, "The argument is not defined."),

    ;

    private int code;

    private String message;

    Errors(int code, String message) {
        this.code = code;
        this.message = message;
    }

    public int getCode() {
        return code;
    }

    public String getMessage() {
        return message;
    }
}
