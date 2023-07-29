using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

namespace Developer_Toolkit
{
    /// <summary>
    /// A utility class that provides web-related functions, such as fetching web pages, email validation, password strength checking, internet connectivity, and IP address retrieval.
    /// </summary>
    public class Web
    {
        /// <summary>
        /// Retrieves the content of a web page from the specified URL.
        /// </summary>
        /// <param name="url">The URL of the web page to fetch.</param>
        /// <returns>The content of the web page as a string.</returns>
        public static string GetWebPage(string url)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            return wc.DownloadString(url);
        }

        /// <summary>
        /// Checks if the given email address is valid based on a regular expression pattern.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if the email address is valid; otherwise, false.</returns>
        public static bool isValidEmail(string email)
        {
            Regex r = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return r.IsMatch(email);
        }

        /// <summary>
        /// Represents the result of a password strength validation.
        /// </summary>
        public class PasswordValidationResult
        {
            /// <summary>
            /// Gets or sets a value indicating whether the password is considered valid.
            /// </summary>
            public bool Valid { get; set; }

            /// <summary>
            /// Gets or sets a message describing the validation result.
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// Gets or sets an array of suggestions to improve the password strength.
            /// </summary>
            public string[] Suggestions { get; set; }
        }

        /// <summary>
        /// Checks if a password meets the criteria for being considered strong.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="minLength">The minimum length required for the password (default is 8 characters).</param>
        /// <returns>A PasswordValidationResult object containing the validation result and suggestions, if any.</returns>
        public static PasswordValidationResult IsStrongPassword(string password, int minLength = 8)
        {
            // Password strength criteria
            bool hasUppercase = Regex.IsMatch(password, "[A-Z]");
            bool hasLowercase = Regex.IsMatch(password, "[a-z]");
            bool hasDigit = Regex.IsMatch(password, @"\d");
            bool hasSpecialChar = Regex.IsMatch(password, @"[^A-Za-z0-9]"); // Non-alphanumeric characters

            var criteria = new[]
            {
                new { Condition = hasUppercase, Message = "Include at least one uppercase letter (A-Z)." },
                new { Condition = hasLowercase, Message = "Include at least one lowercase letter (a-z)." },
                new { Condition = hasDigit, Message = "Include at least one digit (0-9)." },
                new { Condition = hasSpecialChar, Message = "Include at least one special character (e.g., !@#$%)."}
            };

            var suggestions = criteria
                .Where(criterion => !criterion.Condition)
                .Select(criterion => criterion.Message)
                .ToArray();

            if (password.Length < minLength)
            {
                return new PasswordValidationResult
                {
                    Valid = false,
                    Message = $"Password must be at least {minLength} characters long.",
                    Suggestions = suggestions
                };
            }

            if (suggestions.Length > 0)
            {
                return new PasswordValidationResult
                {
                    Valid = false,
                    Message = "Password must meet the following criteria:",
                    Suggestions = suggestions
                };
            }

            return new PasswordValidationResult
            {
                Valid = true,
                Message = "Password is strong.",
                Suggestions = new string[0]
            };
        }


        /// <summary>
        /// Checks if the system has an active internet connection.
        /// </summary>
        /// <returns>True if the system is connected to the internet; otherwise, false.</returns>
        public static bool HasInternet()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus = ping.Send("google.com");
            return pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success;
        }

        /// <summary>
        /// Retrieves the public IP address of the system by querying a well-known DNS server.
        /// </summary>
        /// <returns>The public IP address of the system as a string, or an error message if the retrieval fails.</returns>
        public static string GetIPAddress()
        {
            try
            {
                // Use a well-known DNS server that responds with the client's IP address
                string dnsServer = "resolver1.opendns.com";
                IPAddress[] addresses = Dns.GetHostAddresses(dnsServer);

                if (addresses.Length > 0)
                {
                    // Create a socket to perform DNS query directly
                    using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                    {
                        socket.Connect(addresses[0], 53); // 53 is the DNS port
                        socket.Send(new byte[] { 0x08, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 });

                        byte[] response = new byte[512];
                        int bytesReceived = socket.Receive(response);

                        if (bytesReceived > 12) // Minimum DNS response size is 12 bytes
                        {
                            IPAddress ipAddress = new IPAddress(response, 20); // The IP address starts at offset 20 in the response
                            return ipAddress.ToString();
                        }
                    }
                }

                // Failed to get the IP address
                return "Unknown";
            }
            catch (System.Exception ex)
            {
                // Handle any exception that might occur during the process
                return "Error: " + ex.Message;
            }
        }

        /// <summary>
        /// Pings a website and returns the ping time in milliseconds.
        /// </summary>
        /// <returns>The ping time in milliseconds, or an error message if the ping fails.</returns>
        public static string WebsitePing(string url, bool bShowMS = false)
        {
            try
            {
                Uri uri = new Uri(url);
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send(uri.Host);

                    if (reply.Status == IPStatus.Success)
                    {
                        return $"{reply.RoundtripTime}{(bShowMS ? " ms" : "")}";
                    }
                    else
                    {
                        return $"Ping to {url} failed. Error message: {reply.Status.ToString()}";
                    }
                }
            }
            catch (UriFormatException)
            {
                return $"Invalid URL format: {url}";
            }
            catch (PingException ex)
            {
                return $"An error occurred while pinging {url}. Error message: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An unexpected error occurred while pinging {url}. Error message: {ex.Message}";
            }
        }
    }
}
