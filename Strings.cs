using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Toolkit
{
    /// <summary>
    /// A utility class that provides various string manipulation functions.
    /// </summary>
    public class Strings
    {
        /// <summary>
        /// Generates a random string of the specified length using characters from the given character set.
        /// </summary>
        /// <param name="length">The length of the random string to generate.</param>
        /// <returns>A random string of the specified length.</returns>
        public static string GetRandomString(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Keeps only the characters from the input string that are present in the allowed characters string.
        /// </summary>
        /// <param name="input">The input string to filter.</param>
        /// <param name="allowedCharacters">The string containing allowed characters.</param>
        /// <returns>The filtered string containing only allowed characters.</returns>
        public static string KeepOnly(string input, string allowedCharacters)
        {
            StringBuilder output = new StringBuilder();

            foreach (char c in input)
            {
                if (allowedCharacters.Contains(c))
                    output.Append(c);
            }

            return output.ToString();
        }

        /// <summary>
        /// Converts the input string to kebab case (words separated by hyphens).
        /// </summary>
        /// <param name="input">The input string to convert to kebab case.</param>
        /// <returns>The input string converted to kebab case.</returns>
        public static string KebabCase(string input)
        {
            StringBuilder output = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsUpper(c))
                {
                    output.Append("-");
                    output.Append(char.ToLower(c));
                }
                else
                {
                    output.Append(c);
                }
            }

            return output.ToString();
        }

        /// <summary>
        /// Converts the input string to Pascal case (words capitalized and concatenated).
        /// </summary>
        /// <param name="input">The input string to convert to Pascal case.</param>
        /// <returns>The input string converted to Pascal case.</returns>
        public static string PascalCase(string input)
        {
            StringBuilder output = new StringBuilder();

            bool capitalizeNext = true;
            foreach (char c in input)
            {
                if (c == '-' || c == '_')
                {
                    capitalizeNext = true;
                    continue;
                }

                if (capitalizeNext)
                {
                    output.Append(char.ToUpper(c));
                    capitalizeNext = false;
                }
                else
                {
                    output.Append(c);
                }
            }

            return output.ToString();
        }

        /// <summary>
        /// Converts the input string to snake case (words separated by underscores).
        /// </summary>
        /// <param name="input">The input string to convert to snake case.</param>
        /// <returns>The input string converted to snake case.</returns>
        public static string SnakeCase(string input)
        {
            StringBuilder output = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsUpper(c))
                {
                    output.Append("_");
                    output.Append(char.ToLower(c));
                }
                else
                {
                    output.Append(c);
                }
            }

            return output.ToString();
        }

        /// <summary>
        /// Converts the number of bytes to a human-readable string representation of size (e.g., KB, MB, GB).
        /// </summary>
        /// <param name="bytes">The number of bytes to convert.</param>
        /// <returns>A human-readable string representation of the size.</returns>
        public static string BytesToSize(int bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return String.Format("{0:0.##} {1}", len, sizes[order]);
        }

        /// <summary>
        /// Converts the input string to its Base64 representation.
        /// </summary>
        /// <param name="input">The input string to convert to Base64.</param>
        /// <returns>The Base64 representation of the input string.</returns>
        public static string toBase64(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Truncates the input string to the specified length, adding ellipsis (...) if truncated.
        /// </summary>
        /// <param name="input">The input string to truncate.</param>
        /// <param name="length">The maximum length of the truncated string.</param>
        /// <returns>The truncated string.</returns>
        public static string Truncate(string input, int length)
        {
            if (input.Length <= length)
                return input;

            return input.Substring(0, length) + "...";
        }

        /// <summary>
        /// Reverses the input string to create a palindrome.
        /// </summary>
        /// <param name="input">The input string to create a palindrome from.</param>
        /// <returns>The palindrome string.</returns>
        public static string Palindrome(string input)
        {
            StringBuilder output = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                output.Append(input[i]);
            }

            return output.ToString();
        }

        /// <summary>
        /// Capitalizes the first character of each word in the input string.
        /// </summary>
        /// <param name="input">The input string to capitalize.</param>
        /// <returns>The input string with the first character of each word capitalized.</returns>
        public static string Capitalize(string input)
        {
            StringBuilder output = new StringBuilder();

            bool capitalizeNext = true;
            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    capitalizeNext = true;
                    output.Append(c);
                    continue;
                }

                if (capitalizeNext)
                {
                    output.Append(char.ToUpper(c));
                    capitalizeNext = false;
                }
                else
                {
                    output.Append(c);
                }
            }

            return output.ToString();
        }
    }
}
