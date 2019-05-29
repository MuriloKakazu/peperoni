using System.Collections.Generic;

namespace Presentation.Mapper {
    public static class FamilyMapper {
        static IDictionary<string, string> English = new Dictionary<string, string>() {
            { "Sabor", "Topping" },
            { "Borda", "Border" },
            { "Bebida", "Drink" }
        };

        static IDictionary<string, string> Portuguese = new Dictionary<string, string>() {
            { "Topping", "Sabor" },
            { "Border", "Borda"},
            { "Drink", "Bebida"}
        };

        public static string ToEnglish(string family) {
            if (English.ContainsKey(family ?? "")) {
                return English[family];
            }
            return family;
        }

        public static string ToPortuguese(string family) {
            if (Portuguese.ContainsKey(family ?? "")) {
                return Portuguese[family];
            }
            return family;
        }

        public static ICollection<string> GetEnglishValues() {
            return English.Values;
        }

        public static ICollection<string> GetPortugueseValues() {
            return Portuguese.Values;
        }
    }
}
