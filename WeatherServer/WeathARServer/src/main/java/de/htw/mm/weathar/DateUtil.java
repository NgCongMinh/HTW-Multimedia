package de.htw.mm.weathar;

import java.util.Calendar;
import java.util.Date;

/**
 * Util class which concerns the date.
 *
 * @author Cong Minh Nguyen, Tuan Tung Tran
 * @date 20.07.2019
 */
public final class DateUtil {

    private DateUtil() {
    }

    /**
     * returns true if it is the same day.
     *
     * @param c1 calendar 1
     * @param c2 calendar 2
     * @return true if same day, else false
     */
    private static boolean isSameDay(Calendar c1, Calendar c2) {
        return c1.get(Calendar.DAY_OF_MONTH) == c2.get(Calendar.DAY_OF_MONTH)
                && c1.get(Calendar.MONTH) == c2.get(Calendar.MONTH)
                && c1.get(Calendar.YEAR) == c2.get(Calendar.YEAR);
    }

    /**
     * Returns whether the given date represents today.
     * @param date date
     * @return true if today, else false
     */
    public static boolean isToday(Date date) {
        Calendar today = Calendar.getInstance();

        Calendar specifiedDate = Calendar.getInstance();
        specifiedDate.setTime(date);

        return isSameDay(today, specifiedDate);
    }

    /**
     * Returns whether the given date represents tomorrow.
     * @param date date
     * @return true if tomorrow, else false
     */
    public static boolean isTomorrow(Date date) {
        Calendar today = Calendar.getInstance();
        today.add(Calendar.DAY_OF_YEAR, 1);

        Calendar specifiedDate = Calendar.getInstance();
        specifiedDate.setTime(date);

        return isSameDay(today, specifiedDate);
    }

    /**
     * Returns whether the given date represents the day after tomorrow.
     * @param date date
     * @return true if day after tomorrow, else false
     */
    public static boolean isDayAfterTomorrow(Date date) {
        Calendar today = Calendar.getInstance();
        today.add(Calendar.DAY_OF_YEAR, 2);

        Calendar specifiedDate = Calendar.getInstance();
        specifiedDate.setTime(date);

        return isSameDay(today, specifiedDate);
    }

}
