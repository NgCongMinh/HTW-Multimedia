package de.htw.mm.weathar.model;

public enum GermanCity {

    BERLIN("Berlin", 13.404954, 52.520008),
    BAVARIA("Bayern", 11.407980, 48.917431),
    BADEN_WUERTTEMBERG("Baden-Wuerttemberg", 9.003540, 48.661709),
    BRANDENBURG("Brandenburg", 13.216249, 52.131393),
    BREMEN("Bremen", 8.801694, 53.079296),
    HAMBURG("Hamburg", 9.993682, 53.551086),
    HESSE("Hessen", 9.004440, 50.526501),
    MECKLENBURG_WESTERN_POMERANIA("Mecklenburg-Vorpommern", 12.429595, 53.612652),
    LOWER_SAXONY("Niedersachsen", 9.126210, 52.593342),
    NORTHRHINE_WESTPHALIA("Nordrhein-Westfalen", 7.663980, 51.426998),
    RHINELAND_PALATINATE("Rheinland-Pfalz", 7.308953, 50.118347),
    SAARLAND("Saarland", 6.880660, 49.375660),
    SAXONY("Sachsen", 13.457050, 50.928089),
    SAXONY_ANHALT("Sachsen-Anhalt", 11.873840, 51.989750),
    SCHLESWIG_HOLSTEIN("Schleswig-Holstein", 9.589030, 54.208321),
    THURINGIA("Thueringen", 10.845346, 51.010990),
    ;

    private String name;

    private double longitude;

    private double latitude;

    GermanCity(String name, double longitude, double latitude) {
        this.name = name;
        this.longitude = longitude;
        this.latitude = latitude;
    }

    public String getName() {
        return name;
    }

    public double getLongitude() {
        return longitude;
    }

    public double getLatitude() {
        return latitude;
    }

    public static GermanCity getCity(String city) {
        for (GermanCity c : values()) {
            if (c.name.equalsIgnoreCase(city)) {
                return c;
            }
        }
        return null;
    }

}
