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
            var sha1 = new SHA1CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(input);
            var sha1Data = sha1.ComputeHash(data);

            var asciiEnc = new ASCIIEncoding();

            var returnInput = asciiEnc.GetString(sha1Data);

            return returnInput;
        }

        public bool IsNotEmpty(string input)
        {
            if (input == null) 
                return false;

            return (input.Length != 0 && input != "");
        }
    }
}