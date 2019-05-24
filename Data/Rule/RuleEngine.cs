using System;
using System.Collections.Generic;

namespace Infrastructure.Rule {
    public class RuleEngine<T> {
        private HashSet<string> AccumulatedErrors;
        private ICollection<T> Items;

        public RuleEngine(ICollection<T> items) {
            AccumulatedErrors = new HashSet<string>();
            Items = items;
        }

        public RuleEngine(T item) {
            AccumulatedErrors = new HashSet<string>();
            Items = new List<T> { item };
        }

        public RuleEngine<T> Apply(Action<T> action) {
            foreach (var item in Items) {
                action.Invoke(item);
            }

            return this;
        }

        public RuleEngine<T> Apply(Predicate<T> predicate, string errorMessage) {
            foreach (var item in Items) {
                if (!predicate.Invoke(item)) {
                    AccumulatedErrors.Add(errorMessage);
                }
            }

            return this;
        }

        public RuleEngine<T> Run() {
            if (AccumulatedErrors.Count > 0) {
                throw new RuleEngineException(GetErrors());
            }

            return this;
        }

        private string GetErrors() {
            return String.Join(", ", AccumulatedErrors);
        }

        public class RuleEngineException : Exception {
            public RuleEngineException(string message)
                : base(message) {
            }
        }
    }
}
