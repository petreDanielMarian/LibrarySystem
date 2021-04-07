using System.Linq;

namespace Library.ExtensionMethods
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if a string has only digits
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool HasOnlyNumbers(this string str)
        {
            return str.All(char.IsDigit);
        }
    }
}