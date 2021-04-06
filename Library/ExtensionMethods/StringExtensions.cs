using System.Linq;

namespace Library.ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool HasOnlyNumbers(this string str)
        {
            return str.All(char.IsDigit);
        }
    }
}