using System;
using System.Collections.Generic;

namespace Domain.Engine {
    public class RuleEngine<Type> {
        private ICollection<string> AccumulatedErrors;
        private List<Type> Items;

        public RuleEngine(List<Type> items) {
            AccumulatedErrors = new List<string>();
            Items = items;
        }

        public RuleEngine(Type item) {
            AccumulatedErrors = new List<string>();
            Items = new List<Type> { item };
        }

        public RuleEngine<Type> Apply(Rule<Type> rule) {
            foreach (var item in Items) {
                rule.Apply(item);
            }

            return this;
        }

        public RuleEngine<Type> Apply(Predicate<Type> predicate, string errorMessage) {
            foreach (var item in Items) {
                if (!predicate.IsValid(item)) {
                    AccumulatedErrors.Add(errorMessage);
                }
            }

            return this;
        }

        public RuleEngine<Type> Execute() {
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
