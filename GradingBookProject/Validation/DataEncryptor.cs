using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.Validation
{
    /// <summary>
    /// Encrypts data using implemented hashing algorithms
    /// </summary>
    public class DataEncryptor
    {
        /// <summary>
        /// Creates from given input encrypted string in sha256
        /// </summary>
        /// <param name="input">String to encrypt</param>
        /// <returns>Encrypted string</returns>
        public string GetSha256String(string input)
        {
            var sha256 = new SHA256CryptoServiceProvider();

            var data = Encoding.UTF8.GetBytes(input);
            var sha256data = sha256.ComputeHash(data);

            //var utf8Encoding = new UTF8Encoding();

            //var returnInput = utf8Encoding.GetString(sha1Data);
            var returnInput = Convert.ToBase64String(sha256data); // store it
            return returnInput;
        }
    }
}
