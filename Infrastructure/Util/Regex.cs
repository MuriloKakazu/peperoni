using SystemRegex = System.Text.RegularExpressions.Regex;

namespace Infrastructure.Util {
    public class Regex {
        private string Expression { get; set; }

        public static Regex Pattern(string pattern) {
            return new Regex(pattern);
        }

        private Regex(string pattern) {
            Expression = pattern;
        }

        public bool Matches(string value) {
            return Optional.Of(value)
                .IfPresent((result) => 
                    new SystemRegex(Expression)
                        .IsMatch(value));
        }
    }
}
