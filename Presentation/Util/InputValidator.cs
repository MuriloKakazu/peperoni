using Infrastructure.Exceptions;
using Infrastructure.Util;
using System;
using System.Globalization;

namespace Presentation.Util
{
    public static class InputValidator {
        public static bool IsNumeric(string value) {
            return Regex.Pattern(@"^(\d)+").Matches(value);
        }

        public static bool IsOverZero(string value) {
            return IsNumeric(value) && Int32.Parse(value) > 0;
        }

        public static bool IsWord(string value) {
            return Regex.Pattern(@"\p{L}").Matches(value);
        }

        public static decimal EnsureDecimal(string value) {
            decimal result;

            if (!Decimal.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result)) {
                throw new ValidationException("O valor deve ser um número!");
            }

            return result;
        }
    }
}
