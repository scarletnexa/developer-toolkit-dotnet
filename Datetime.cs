using System;

namespace Developer_Toolkit
{
    /// <summary>
    /// A utility class that provides various date and time-related functions.
    /// </summary>
    public class Datetime
    {
        private static string[] months = new string[]
        {
            "January", "February", "March", "April",
            "May", "June", "July", "August",
            "September", "October", "November", "December"
        };

        /// <summary>
        /// Formats the date in the following format: "Month day year".
        /// </summary>
        /// <param name="date">The date to format.</param>
        /// <returns>The formatted date as a string.</returns>
        public static string FDate(DateTime date)
        {
            int day = date.Day;
            int monthIndex = date.Month - 1;
            int year = date.Year;

            return $"{months[monthIndex]} {day} {year}";
        }

        /// <summary>
        /// Formats the time in the following format: "hours:minutes" or "hours:minutes:seconds".
        /// </summary>
        /// <param name="date">The date to format.</param>
        /// <param name="seconds">Include seconds in the formatted time. Default is false.</param>
        /// <returns>The formatted time as a string.</returns>
        public static string FTime(DateTime date, bool seconds = false)
        {
            int hours = date.Hour;
            int minutes = date.Minute;
            int secs = date.Second;

            return $"{hours}:{minutes}{(seconds ? $":{secs}" : "")}";
        }

        /// <summary>
        /// Calculates the amount of time that has passed since the given date.
        /// </summary>
        /// <param name="date">The date to compare.</param>
        /// <returns>A string indicating the amount of time that has passed since the given date.</returns>
        public static string DateAmount(DateTime date)
        {
            TimeSpan diff = DateTime.Now - date;
            int diffDays = (int)diff.TotalDays;

            if (diffDays == 0)
            {
                return "Today";
            }
            else if (diffDays == 1)
            {
                return "Yesterday";
            }
            else
            {
                return $"{diffDays} days ago";
            }
        }

        /// <summary>
        /// Checks if a given year is a leap year.
        /// </summary>
        /// <param name="year">The year to check.</param>
        /// <returns>True if the year is a leap year, otherwise false.</returns>
        public static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        /// <summary>
        /// Gets the number of days in a specific month of a given year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month (1 to 12).</param>
        /// <returns>The number of days in the specified month of the given year.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the month is not in the range of 1 to 12.</exception>
        public static int DaysInMonth(int year, int month)
        {
            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException("Month must be between 1 and 12.");

            return DateTime.DaysInMonth(year, month);
        }

        /// <summary>
        /// Adds a specified number of business days to a given date.
        /// </summary>
        /// <param name="date">The starting date.</param>
        /// <param name="businessDays">The number of business days to add. A negative value subtracts business days.</param>
        /// <returns>The date after adding the specified number of business days.</returns>
        public static DateTime AddBusinessDays(DateTime date, int businessDays)
        {
            int direction = Math.Sign(businessDays);
            int remainingDays = Math.Abs(businessDays);
            while (remainingDays > 0)
            {
                date = date.AddDays(direction);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    remainingDays--;
            }
            return date;
        }

        /// <summary>
        /// Calculates the age based on the provided birthdate and the current date.
        /// </summary>
        /// <param name="birthdate">The birthdate to calculate the age from.</param>
        /// <returns>The age as an integer.</returns>
        public static int GetAge(DateTime birthdate)
        {
            int age = DateTime.Now.Year - birthdate.Year;
            if (DateTime.Now.DayOfYear < birthdate.DayOfYear)
                age--;

            return age;
        }
    }
}
