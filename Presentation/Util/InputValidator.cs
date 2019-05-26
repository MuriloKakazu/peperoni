using Infrastructure.Util;

namespace Presentation.Util
{
    public static class InputValidator {
        public static bool IsNumeric(string value) {
            return Regex.Pattern(@"^(\d)+").Matches(value);
        }

        public static bool IsWord(string value) {
            return Regex.Pattern(@"\p{L}").Matches(value);
        }
    }
}
