using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Mapper {
    class OrderStatusMapper {
        static IDictionary<string, string> English = new Dictionary<string, string>() {
            {"Em andamento", "Ongoing"},
            {"Pronto", "Ready" },
            {"Entregue", "Delivered" },
            {"Cancelado", "Cancelled" }
        };

        static IDictionary<string, string> Portuguese = new Dictionary<string, string>() {
            {"Ongoing", "Em andamento"},
            {"Ready", "Pronto" },
            {"Delivered", "Entregue" },
            {"Cancelled", "Cancelado" }
        };

        public static string ToEnglish(string status) {
            if(English.ContainsKey(status ?? "")) {
                return English[status];
            }
            return status;
        }

        public static string ToPortuguese(string status) {
            if(Portuguese.ContainsKey(status ?? "")) {
                return Portuguese[status];
            }
            return status;
        }

        public static ICollection<string> GetEnglishValues() {
            return English.Values;
        }

        public static ICollection<string> GetPortugueseValues() {
            return Portuguese.Values;
        }
    }
}
