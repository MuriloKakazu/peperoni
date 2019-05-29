using System.Data.SqlClient;

namespace Infrastructure.Data {
    public class Filter {
        public string Key { get; set; }
        public object Value { get; set; }
        public SqlParameter Parameter { get; set; }

        public override string ToString() {
            return $"{Key} = @{Key}";
        }
    }
}
