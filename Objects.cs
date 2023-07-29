using System;
using System.Collections.Generic;
using System.Linq;

namespace Developer_Toolkit
{
    /// <summary>
    /// A utility class that provides operations related to objects and data transformation.
    /// </summary>
    public class Objects
    {
        /// <summary>
        /// Validates an object against a schema of property names.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <param name="schema">An array of property names representing the schema.</param>
        /// <returns>True if the object properties match the schema; otherwise, false.</returns>
        public static bool ValidateAgainstSchema(object obj, string[] schema)
        {
            if (obj == null || schema == null || schema.Length == 0)
            {
                return false;
            }

            var properties = obj.GetType().GetProperties();
            if (properties.Length != schema.Length)
            {
                return false;
            }

            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].Name != schema[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Parses a query string and returns the values as a list.
        /// </summary>
        /// <param name="queryString">The query string to parse.</param>
        /// <returns>A list of query string values.</returns>
        public static List<string> ParseQueryString(string queryString)
        {
            if (string.IsNullOrEmpty(queryString))
            {
                return new List<string>();
            }

            return queryString
                .Split('&')
                .Select(q => q.Split('='))
                .Where(arr => arr.Length == 2)
                .Select(arr => arr[1])
                .ToList();
        }

       
        /// <summary>
        /// Removes duplicate elements from a string array.
        /// </summary>
        /// <param name="input">The input string array.</param>
        /// <returns>A new string array without duplicate elements.</returns>
        public static string[] RemoveDuplicates(string[] input)
        {
            return input.Distinct().ToArray();
        }
    }
}
