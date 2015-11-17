using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace GradingBookProject.Validation
{
    /// <summary>
    /// Class to validates various types of data.
    /// To add other data type create proper interface and let Validator to inherit from it
    /// </summary>
    public class Validator : IStringValidator, INumberValidator
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
            var encryptor = new DataEncryptor();
            var returnInput = encryptor.GetSha256String(input);

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

        public bool isValidMail(string input)
        {
            try
            {
                MailAddress m = new MailAddress(input); //if is no exception then return true

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public float ValidateNumber(string input)
        {
            float num = 0;
            if (float.TryParse(input, out num))
            {
                return num;
            }
            throw new Exception("Given input is not a number!");
        }

        public bool ValidateGrade(float n)
        {

            var possibleGrades = new List<double>() //temporary solution
            {
                2,
                3,
                3.5,
                4,
                4.5,
                5
            };
            return possibleGrades.Contains(n);
        }


        public bool isValidDate(string input)
        {
            try
            {
                DateTime.Parse(input);
                return true;
            }
            catch (Exception e) { return false; }
        }
    }
}