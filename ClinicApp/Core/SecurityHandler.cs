using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Core
{
    public class SecurityHandler
    {
        public static string CreateHash(string password)
        {
            SHA1Managed sha1 = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(password);
            byte[] hash = sha1.ComputeHash(data);

            string hashString = Encoding.UTF8.GetString(hash);

            return hashString;
        }
    }
}
