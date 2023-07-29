using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Toolkit
{
    /// <summary>
    /// A utility class that provides local system-related information, such as local IP address, host name, and user details.
    /// </summary>
    public class Local
    {
        /// <summary>
        /// Retrieves the local IP address of the system.
        /// </summary>
        /// <returns>The local IP address as a string, or null if not found.</returns>
        public static string GetLocalIPAddress()
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            var ip = host.AddressList.FirstOrDefault(ipAddress => ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            return ip?.ToString();
        }

        /// <summary>
        /// Retrieves the local host name of the system.
        /// </summary>
        /// <returns>The local host name as a string.</returns>
        public static string GetLocalHostName()
        {
            return System.Net.Dns.GetHostName();
        }

        /// <summary>
        /// Retrieves various user details of the current environment.
        /// </summary>
        /// <returns>An array of strings containing user domain, user name, machine name, OS version, and environment version.</returns>
        public static string[] GetUserDetails()
        {
            string domain = Environment.UserDomainName;
            string user = Environment.UserName;
            string machine = Environment.MachineName;
            string OS = Environment.OSVersion.ToString();
            string version = Environment.Version.ToString();

            string[] data = { domain, user, machine, OS, version };
            return data;
        }
    }
}
