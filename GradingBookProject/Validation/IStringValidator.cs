namespace GradingBookProject.Validation
{
    public interface IStringValidator
    {
        /// <summary>
        /// Validates (turns it into plain text) and checks input string
        /// </summary>
        /// <param name="input">String to check and validate</param>
        /// <returns>plain text</returns>
        string ValidateUsername(string input);

        /// <summary>
        /// Validates (turns it into plain text) and checks input string
        /// </summary>
        /// <param name="input">String to check and validate</param>
        /// <returns>plain text, encrypted via hash (sha1) function</returns>
        string ValidatePassword(string input);
        /// <summary>
        /// Checks if given input is not either null either empty string
        /// </summary>
        /// <param name="input">String to check</param>
        /// <returns>true - if proper</returns>
        bool IsNotEmpty(string input);
    }
}