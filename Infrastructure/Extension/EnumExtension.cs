using System;

namespace Infrastructure.Extension {
    public static class EnumExtension {
        public static int Numeric(this Enum value) {
            return Convert.ToInt32(value);
        }
    }
}
