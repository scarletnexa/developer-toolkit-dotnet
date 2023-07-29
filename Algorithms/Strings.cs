using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Toolkit.Algorithms
{
    /// <summary>
    /// A utility class that provides string-related algorithms.
    /// </summary>
    public class Strings
    {
        /// <summary>
        /// Computes the Levenshtein distance between two strings.
        /// </summary>
        /// <param name="str1">The first string.</param>
        /// <param name="str2">The second string.</param>
        /// <returns>The Levenshtein distance between the two input strings.</returns>
        public static int LevenshteinDistance(string str1, string str2)
        {
            int[,] track = new int[str2.Length + 1, str1.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
            {
                track[0, i] = i;
            }

            for (int j = 0; j <= str2.Length; j++)
            {
                track[j, 0] = j;
            }

            for (int j = 1; j <= str2.Length; j++)
            {
                for (int i = 1; i <= str1.Length; i++)
                {
                    int indicator = (str1[i - 1] == str2[j - 1]) ? 0 : 1;
                    track[j, i] = System.Math.Min(
                        track[j, i - 1] + 1,
                        System.Math.Min(track[j - 1, i] + 1, track[j - 1, i - 1] + indicator)
                    );
                }
            }

            return track[str2.Length, str1.Length];
        }

        /// <summary>
        /// Checks if two strings are anagrams of each other.
        /// </summary>
        /// <param name="str1">The first string.</param>
        /// <param name="str2">The second string.</param>
        /// <returns>True if the two strings are anagrams; otherwise, false.</returns>
        public static bool AreAnagrams(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            // Count characters in str1
            foreach (char c in str1)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }

            // Decrement count for characters in str2
            foreach (char c in str2)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]--;
                else
                    return false; // If a character is not present in str1, then they are not anagrams
            }

            // Check if all counts are zero
            foreach (int count in charCount.Values)
            {
                if (count != 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if two strings are palindromes of each other.
        /// </summary>
        /// <param name="str1">The first string.</param>
        /// <param name="str2">The second string.</param>
        /// <returns>True if the two strings are palindromes; otherwise, false.</returns>
        public static bool ArePalindromes(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            // Count characters in str1
            foreach (char c in str1)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }

            // Decrement count for characters in str2
            foreach (char c in str2)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]--;
                else
                    return false; // If a character is not present in str1, then they are not palindromes
            }

            // Check if all counts are zero
            foreach (int count in charCount.Values)
            {
                if (count != 0)
                    return false;
            }

            return true;
        }
    }
}
