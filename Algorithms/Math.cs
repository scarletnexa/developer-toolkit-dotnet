using System;

namespace Developer_Toolkit.Algorithms
{
    /// <summary>
    /// A utility class that provides various mathematical algorithms and functions.
    /// </summary>
    public class Math
    {
        /// <summary>
        /// Calculates the factorial of a given number.
        /// </summary>
        /// <param name="n">The number for which to calculate the factorial.</param>
        /// <returns>The factorial of the given number.</returns>
        public static int Factorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        /// <summary>
        /// Calculates the Greatest Common Divisor (GCD) of two numbers using the Euclidean algorithm.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The GCD of the two input numbers.</returns>
        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        /// <summary>
        /// Calculates the Least Common Multiple (LCM) of two numbers using the GCD.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The LCM of the two input numbers.</returns>
        public static int LCM(int a, int b)
        {
            return (a / GCD(a, b)) * b;
        }

        /// <summary>
        /// Calculates the nth Fibonacci number.
        /// </summary>
        /// <param name="n">The position of the Fibonacci number to calculate (zero-based).</param>
        /// <returns>The nth Fibonacci number.</returns>
        public static int Fibonacci(int n)
        {
            if (n <= 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
