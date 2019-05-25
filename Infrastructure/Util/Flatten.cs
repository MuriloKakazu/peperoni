using System;

namespace Infrastructure.Util {
    public static class Flatten {
        public static string Strings(params string[] ids) {
            return String.Join("', '", ids);
        }
    }
}
