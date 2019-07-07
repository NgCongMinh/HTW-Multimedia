package de.htw.mm.weathar.model.error;

public class NotDefinedException extends Exception {

    public NotDefinedException(String message) {
        super(message);
    }

    public NotDefinedException(String message, Throwable cause) {
        super(message, cause);
    }
}
