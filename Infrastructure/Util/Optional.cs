using System;
using System.Collections.Generic;

namespace Infrastructure.Util {
    public static class Optional {
        public static Optional<object> Of(object value) {
            return Optional<object>.Of(value);
        }
    }

    public class Optional<T> {
        public T Value { get; private set; }
        public bool IsPresent => Value != null;

        protected Optional(T value) {
            Value = value;
        }

        public static Optional<T> Of(T value) {
            return new Optional<T>(value);
        }

        public R IfPresent<R>(Func<T, R> action) {
            if (IsPresent) {
                return action.Invoke(Value);
            }
            return default(R);
        }

        public Optional<T> IfPresent(Action<T> action) {
            if (IsPresent) {
                action.Invoke(Value);
            }
            return this;
        }

        public Optional<T> IfPresent(Action action) {
            if (IsPresent) {
                action.Invoke();
            }
            return this;
        }

        public R IfNotPresent<R>(Func<T, R> action) {
            if (!IsPresent) {
                return action.Invoke(Value);
            }
            return default(R);
        }

        public Optional<T> IfNotPresent(Action<T> action) {
            if (!IsPresent) {
                action.Invoke(Value);
            }
            return this;
        }

        public Optional<T> IfNotPresent(Action action) {
            if (!IsPresent) {
                action.Invoke();
            }
            return this;
        }

        public class OptionalException : Exception {
            public OptionalException(string message)
                : base(message) {
            }
        }
    }
}
