using System;

namespace Developer_Toolkit
{
    /// <summary>
    /// A utility class that provides various number-related functions.
    /// </summary>
    public class Numbers
    {
        /// <summary>
        /// Generates a random integer between the specified minimum and maximum values.
        /// </summary>
        /// <param name="max">The maximum value (exclusive).</param>
        /// <param name="min">The minimum value (inclusive). Default is 10.</param>
        /// <returns>A random integer within the specified range.</returns>
        public static int Random(int max, int min = 10)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        /// <summary>
        /// Formats an integer with thousands separators.
        /// </summary>
        /// <param name="number">The number to format.</param>
        /// <returns>The formatted number as a string with thousands separators.</returns>
        public static string Format(int number)
        {
            return number.ToString("N0");
        }

        /// <summary>
        /// Checks if a number is even.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>True if the number is even, otherwise false.</returns>
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Checks if a number is prime.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>True if the number is prime, otherwise false.</returns>
        public static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            if (number == 2)
                return true;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Calculates the factorial of a non-negative integer.
        /// </summary>
        /// <param name="number">The non-negative integer to calculate the factorial of.</param>
        /// <returns>The factorial of the input number.</returns>
        /// <exception cref="ArgumentException">Thrown when the input number is negative.</exception>
        public static int Factorial(int number)
        {
            if (number < 0)
                throw new ArgumentException("Factorial is not defined for negative numbers.");

            if (number == 0)
                return 1;

            int result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        /// <summary>
        /// Calculates the sum of the digits of an integer.
        /// </summary>
        /// <param name="number">The integer whose digits' sum is to be calculated.</param>
        /// <returns>The sum of the digits of the input number.</returns>
        public static int SumOfDigits(int number)
        {
            number = Math.Abs(number);
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        /// <summary>
        /// Calculates the power of a number to a specified exponent.
        /// </summary>
        /// <param name="number">The base number.</param>
        /// <param name="exponent">The exponent to raise the base number to.</param>
        /// <returns>The result of the base number raised to the exponent.</returns>
        public static double Power(double number, double exponent)
        {
            return Math.Pow(number, exponent);
        }

        /// <summary>
        /// Checks if a number is a perfect square.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>True if the number is a perfect square, otherwise false.</returns>
        public static bool IsPerfectSquare(int number)
        {
            int sqrt = (int)Math.Sqrt(number);
            return sqrt * sqrt == number;
        }

        /// <summary>
        /// Calculates the greatest common divisor (GCD) of two integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The greatest common divisor of the two input integers.</returns>
        public static int GreatestCommonDivisor(int a, int b)
        {
            if (b == 0)
                return a;

            return GreatestCommonDivisor(b, a % b);
        }

        /// <summary>
        /// Reverses the digits of an integer.
        /// </summary>
        /// <param name="number">The integer to reverse.</param>
        /// <returns>The integer with its digits reversed.</returns>
        public static int ReverseDigits(int number)
        {
            int reversedNumber = 0;
            while (number != 0)
            {
                reversedNumber = reversedNumber * 10 + number % 10;
                number /= 10;
            }
            return reversedNumber;
        }

        /// <summary>
        /// Checks if a number is a palindrome (reads the same forward and backward).
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>True if the number is a palindrome, otherwise false.</returns>
        public static bool IsPalindrome(int number)
        {
            return number == ReverseDigits(number);
        }
    }
}
