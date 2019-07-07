package de.htw.mm.weathar;

import java.util.Calendar;
import java.util.Date;

public final class DateUtil {

    private DateUtil() {
    }

    private static boolean isSameDay(Calendar c1, Calendar c2) {
        return c1.get(Calendar.DAY_OF_MONTH) == c2.get(Calendar.DAY_OF_MONTH)
                && c1.get(Calendar.MONTH) == c2.get(Calendar.MONTH)
                && c1.get(Calendar.YEAR) == c2.get(Calendar.YEAR);
    }

    public static boolean isToday(Date date) {
        Calendar today = Calendar.getInstance();

        Calendar specifiedDate = Calendar.getInstance();
        specifiedDate.setTime(date);

        return isSameDay(today, specifiedDate);
    }

    public static boolean isTomorrow(Date date) {
        Calendar today = Calendar.getInstance();
        today.add(Calendar.DAY_OF_YEAR, 1);

        Calendar specifiedDate = Calendar.getInstance();
        specifiedDate.setTime(date);

        return isSameDay(today, specifiedDate);
    }

    public static boolean isDayAfterTomorrow(Date date) {
        Calendar today = Calendar.getInstance();
        today.add(Calendar.DAY_OF_YEAR, 2);

        Calendar specifiedDate = Calendar.getInstance();
        specifiedDate.setTime(date);

        return isSameDay(today, specifiedDate);
    }

}
