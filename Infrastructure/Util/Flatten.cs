using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Util {
    public static class Flatten {
        public static string Strings(params string[] ids) {
            return String.Join("', '", ids);
        }

        public static string Filters(ICollection<Filter> filters) {
            return String.Join(" AND ", filters);
        }
    }
}
