using System;

namespace Infrastructure.Extension {
    public static class EnumFormattingExtension {
        public static string Format(this Enum value) {
            return $"{value.Numeric()} - {value}";
        }
    }
}
