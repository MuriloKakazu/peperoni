using System;
using System.Text.RegularExpressions;

namespace Domain.Extension {
    public static class StringFormattingExtension {
        public static string Numeric(this string value) {
            return Regex.Replace(value, @"\D", String.Empty);
        }
    }
}
