using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Util {
    public static class Pluck {

        public static Plucker<T> Field<T>(string property) {
            return new Plucker<T>(property);
        }

        public class Plucker<T> {
            public string Property { get; set; }

            public Plucker(string property) {
                Property = property;
            }

            public ICollection<T> From<U>(ICollection<U> collection) {
                ICollection<T> plucked = new List<T>();

                collection.ToList().ForEach(item => {
                    var type = item.GetType();
                    var property = type.GetProperty(Property);
                    var value = property.GetValue(item);
                    plucked.Add((T) value);
                });

                return plucked;
            }
        }
    }
}
