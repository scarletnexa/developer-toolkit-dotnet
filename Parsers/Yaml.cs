using System;
using System.Collections.Generic;
using System.IO;

namespace Developer_Toolkit.Parsers
{
    /// <summary>
    /// A utility class that provides methods for parsing values from YAML files.
    /// </summary>
    public class Yaml
    {
        /// <summary>
        /// Gets the value of a specified key from a YAML file.
        /// </summary>
        /// <param name="filePath">The path to the YAML file.</param>
        /// <param name="title">The title of the block to search for the key.</param>
        /// <param name="key">The key to retrieve the value for.</param>
        /// <returns>The value corresponding to the specified key within the given block.</returns>
        public static string GetValue(string filePath, string title, string key)
        {
            string value = "";

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                bool isInTitleBlock = false;
                bool isInKeyBlock = false;

                foreach (string line in lines)
                {
                    // Trim any leading and trailing spaces
                    string trimmedLine = line.Trim();

                    if (trimmedLine.StartsWith(title + ":"))
                    {
                        isInTitleBlock = true;
                        continue;
                    }

                    if (isInTitleBlock)
                    {
                        if (trimmedLine == "")
                        {
                            isInTitleBlock = false;
                        }
                        else
                        {
                            // Check if the line contains the key
                            int colonIndex = trimmedLine.IndexOf(':');
                            if (colonIndex >= 0)
                            {
                                string currentKey = trimmedLine.Substring(0, colonIndex).Trim();
                                string currentValue = trimmedLine.Substring(colonIndex + 1).Trim();

                                if (currentKey == key)
                                {
                                    value = currentValue;
                                    isInKeyBlock = true;
                                }
                                else
                                {
                                    isInKeyBlock = false;
                                }
                            }
                        }
                    }

                    if (isInKeyBlock)
                    {
                        // If the line starts with a whitespace, it is a continuation of the value
                        if (trimmedLine.StartsWith(" "))
                        {
                            value += "\n" + trimmedLine.Trim();
                        }
                        else
                        {
                            // If not, we've reached the end of the key block
                            isInKeyBlock = false;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here, if needed.
                Console.WriteLine("Error reading or parsing YAML: " + ex.Message);
            }

            return value;
        }
    }
}
