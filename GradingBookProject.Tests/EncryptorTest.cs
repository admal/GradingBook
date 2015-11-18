using System;
using GradingBookProject.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            string properOutput = "ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f";

            Assert.AreEqual( properOutput, output);  
        }
    }
}
