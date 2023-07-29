using System;
using System.IO;

namespace Developer_Toolkit.Parsers
{
    /// <summary>
    /// A utility class that provides methods for parsing values from INI files.
    /// </summary>
    public class Ini
    {
        /// <summary>
        /// Gets the value of a specified key from an INI file section.
        /// </summary>
        /// <param name="filePath">The path to the INI file.</param>
        /// <param name="section">The section in the INI file to search for the key.</param>
        /// <param name="key">The key to retrieve the value for.</param>
        /// <returns>The value corresponding to the specified key within the given section.</returns>
        public static string GetValue(string filePath, string section, string key)
        {
            string[] lines = File.ReadAllLines(filePath);

            string value = "";

            bool foundSection = false;
            foreach (string line in lines)
            {
                if (line.Trim().StartsWith(";") || line.Trim().StartsWith("#"))
                    continue;

                if (line.Trim().StartsWith("[") && line.Trim().EndsWith("]") && line.Contains(section))
                {
                    foundSection = true;
                    continue;
                }

                if (foundSection && line.Contains(key))
                {
                    string[] parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        value = parts[1].Trim();
                        break;
                    }
                }
            }

            return value;
        }
    }
}
