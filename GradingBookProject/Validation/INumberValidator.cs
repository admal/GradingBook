namespace GradingBookProject.Validation
{
    public interface INumberValidator
    {
        /// <summary>
        /// Checks if given input is a number.
        /// </summary>
        /// <param name="input">String to check</param>
        /// <returns>Num</returns>
        float ValidateNumber(string input);
        /// <summary>
        /// Checks if given value is a grade
        /// </summary>
        /// <param name="n">Number to check</param>
        /// <returns>true - is grade</returns>
        bool ValidateGrade(float n);
    }
}