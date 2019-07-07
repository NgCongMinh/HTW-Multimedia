package de.htw.mm.weathar.model;

public enum GermanCity {

    BERLIN("Berlin", 13.404954, 52.520008),
    BAVARIA("Bayern", 13.404954, 52.520008),
    BADEN_WUERTTEMBERG("Baden-Wuerttemberg", 13.404954, 52.520008),
    BRANDENBURG("Brandenburg", 13.404954, 52.520008),
    BREMEN("Bremen", 13.404954, 52.520008),
    HAMBURG("Hamburg", 13.404954, 52.520008),
    HESSE("Hessen", 13.404954, 52.520008),
    MECKLENBURG_WESTERN_POMERANIA("Mecklenburg-Vorpommern", 13.404954, 52.520008),
    LOWER_SAXONY("Niedersachsen", 13.404954, 52.520008),
    NORTHRHINE_WESTPHALIA("Nordrhein-Westfalen", 13.404954, 52.520008),
    RHINELAND_PALATINATE("Rheinland-Pfalz", 13.404954, 52.520008),
    SAARLAND("Saarland", 13.404954, 52.520008),
    SAXONY("Sachsen", 13.404954, 52.520008),
    SAXONY_ANHALT("Sachsen-Anhalt", 13.404954, 52.520008),
    SCHLESWIG_HOLSTEIN("Schleswig-Holstein", 13.404954, 52.520008),
    THURINGIA("Thueringen", 13.404954, 52.520008),
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
            if (c.name.equals(city)) {
                return c;
            }
        }
        return null;
    }

}
