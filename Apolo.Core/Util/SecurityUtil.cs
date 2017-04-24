using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Apolo.Core.Util
{
    public static class SecurityUtil
    {
        public static string GenerateSaltedHash(string plainText, string salt)
        {
            var plainTextSaltBytes = System.Text.Encoding.UTF8.GetBytes(plainText + salt);
            HashAlgorithm algorithm = new SHA256Managed();
            return Convert.ToBase64String(algorithm.ComputeHash(plainTextSaltBytes));
        }
    }
}
