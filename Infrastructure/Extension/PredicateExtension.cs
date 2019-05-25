using System;

namespace Infrastructure.Extension {
    public static class PredicateExtension {
        public static Predicate<T> Negate<T>(this Predicate<T> predicate) {
            return (value) => !predicate(value);
        }
    }
}
