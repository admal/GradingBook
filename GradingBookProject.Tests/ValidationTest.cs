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
            var output3 = validator.ValidateUsername(emptyInput); //throws exception

            Assert.AreEqual(output1,"UserName1");
            Assert.AreEqual(output2, "UserName1  1");
            
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CanValidatePassword()
        {
            IStringValidator validator = new Validator();

            var pass1 = "properpassword";
            var pass2 = "no";

            var output1 = validator.ValidatePassword(pass1);
            var output2 = validator.ValidatePassword(pass2); //throws exception if bad

            var good = validator.ValidatePasswordConfirmation(pass1, pass1);
            var bad = validator.ValidatePasswordConfirmation(pass1, pass2); //throws exception if bad

            Assert.AreEqual(true,good);
            Assert.AreEqual("f60d0f815030db12c14495d0e8545b271a82f19de213623a42e9ee29e65b42a9",output1);
        }
        [TestMethod]
        public void CanValidateEmail()
        {
            var email1 = "example@example.com";
            var email2 = "example";
            var email3 = "example@example";

            IStringValidator validator = new Validator();

            var out1 = validator.isValidMail(email1);
            var out2 = validator.isValidMail(email2);
            var out3 = validator.isValidMail(email3);

            Assert.AreEqual(true, out1);
            Assert.AreEqual(false, out2);
            Assert.AreEqual(true, out3);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CanValidateNumber( )
        {
            INumberValidator validator = new Validator();
            var n1 = "2.5";
            var n2 = "4";
            var n3 = "15,5";
            string n4 = "test";

            var out1 = validator.ValidateNumber(n1);
            var out2 = validator.ValidateNumber(n2);
            var out3 = validator.ValidateNumber(n3);
            var out4 = validator.ValidateNumber(n4); //throws exception

            Assert.AreEqual(2.5,out1);
            Assert.AreEqual(4, out2);
            Assert.AreEqual(15.5, out3);
            
        }
        [TestMethod]
        public void CanValidateGrade()
        {
            INumberValidator validator = new Validator();
            double g1 = 3;
            double g2 = 4.5;
            double g3 = 1;
            double g4 = 2.5;

            var out1 = validator.ValidateGrade((float)g1);
            var out2 = validator.ValidateGrade((float)g2);
            var out3 = validator.ValidateGrade((float)g3);
            var out4 = validator.ValidateGrade((float)g4);

            Assert.AreEqual(true, out1);
            Assert.AreEqual(true, out2);
            Assert.AreEqual(false, out3);
            Assert.AreEqual(false, out4);
        }
        [TestMethod]
        public void CanValidateDate( )
        {
            var date1 = new DateTime();
            var date2 = "12333";
            var date3 = new DateTime().ToShortDateString();

            IStringValidator validator = new Validator();
            var out1 = validator.isValidDate(date1.ToString());
            var out2 = validator.isValidDate(date2);
            var out3 = validator.isValidDate(date3.ToString());

            Assert.AreEqual(true, out1);
            Assert.AreEqual(false, out2);
            Assert.AreEqual(true, out3);
        }
    }
}

