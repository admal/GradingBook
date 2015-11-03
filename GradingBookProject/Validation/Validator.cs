using System;
using System.Security.Cryptography;
using System.Text;

namespace GradingBookProject.Validation
{
    /// <summary>
    /// Class to validates various types of data.
    /// To add other data type create proper interface and let Validator to inherit from it
    /// </summary>
    public class Validator : IStringValidator
    {
        public string ValidateUsername(string input)
        {
            if (!IsNotEmpty(input)) 
                throw new Exception("Input is empty!");
            input = input.Trim(); //delete all spaces
            return input;
        }

        public string ValidatePassword(string input)
        {
            if (!IsNotEmpty(input)) 
                throw new Exception("Input is empty!"); //throw exception if not proper

            var passwordLength = Properties.Settings.Default.PasswordLength;
            if (input.Length < passwordLength) 
                throw new Exception("Password must contain at least: " + passwordLength + "characters");

            //put here other password restrictions if needed

            //----------------

            //converting data into hashed password
            var sha256 = new SHA256CryptoServiceProvider();
            
            var data = Encoding.UTF8.GetBytes(input);
            var sha256data = sha256.ComputeHash(data);

            //var utf8Encoding = new UTF8Encoding();

            //var returnInput = utf8Encoding.GetString(sha1Data);
            var returnInput = Convert.ToBase64String(sha256data); // store it

            return returnInput;
        }

        public bool IsNotEmpty(string input)
        {
            if (input == null) 
                return false;

            return (input.Length != 0 && input != "");
        }

        public bool ValidatePasswordConfirmation(string input1, string input2)
        {
            if (input1 != input2)
            {
                throw new Exception("Password and confirmation must be equal!");
            }
            return true;
        }
    }
}