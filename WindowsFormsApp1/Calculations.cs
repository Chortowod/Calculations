namespace WindowsFormsApp1
{
    static class Calculations
    {
        public static string MinuteCheck (int min)
        {
            if (min >= 5 && min <= 20)
                return " минут";
            else if (min % 10 == 1)
                return " минуту";
            else if (min % 10 >= 2 && min % 10 <= 4)
                return " минуты";
            else return " минут";
        }

        public static string HourCheck(int hour)
        {
            if (hour >= 5 && hour <= 20)
                return " часов";
            if (hour % 10 == 1)
                return " час";
            else if (hour % 10 >= 2 && hour % 10 <= 4)
                return " часа";
            else return " часов";
        }
    }
}
