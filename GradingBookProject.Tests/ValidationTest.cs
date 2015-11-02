using System;
using GradingBookProject.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GradingBookProject.Tests
{
    [TestClass]
    public class ValidationTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception),"Input is empty!")]
        public void CanValidateUsername()
        {
            string properInput = "UserName1";
            string emptyInput = "";
            string untrimedInput = "    UserName1  1";

            Validator validator = new Validator();

            var output1 = validator.ValidateUsername(properInput);
            var output2 = validator.ValidateUsername(untrimedInput);
            var output3 = validator.ValidateUsername(emptyInput);

            Assert.AreEqual(output1,"UserName1");
            Assert.AreEqual(output2, "UserName1  1");
        }
    }
}

