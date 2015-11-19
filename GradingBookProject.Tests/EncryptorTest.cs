using System;
using GradingBookProject.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Text;

namespace GradingBookProject.Tests
{
    [TestClass]
    public class EncryptorTest
    {
        [TestMethod]
        public void CanEncryptSha256Test()
        {
            var encryptor = new DataEncryptor();
            string input = "password123";
            string output = encryptor.GetSha256String(input);

            var sha256 = new SHA256CryptoServiceProvider();

            var data = Encoding.UTF8.GetBytes(input);
            var sha256data = sha256.ComputeHash(data);

            var properOutput = Convert.ToBase64String(sha256data);


            Assert.AreEqual( properOutput, output);  
        }
    }
}
