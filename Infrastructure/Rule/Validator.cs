using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Rule {
    public class Validator<T> {
        protected List<T> Items { get; set; }
        protected HashSet<string> AccumulatedErrors;

        protected Validator() {
            AccumulatedErrors = new HashSet<string>();
        }

        public Validator(ICollection<T> items) : this() {
            Items = items.ToList();
        }

        public Validator(T item) :
            this(new List<T> { item }) {
        }

        public Validator<T> Ensure(bool condition, string errorMessage) {
            return Ensure((redirect) => condition, errorMessage);
        }

        public Validator<T> Ensure(Predicate<T> condition, string errorMessage) {
            void accumulate() { AccumulatedErrors.Add(errorMessage); }

            On<T>.Values(Items)
                .WhenEachNot(condition)
                .Then(accumulate);

            return this;
        }

        protected string GetErrors() {
            return String.Join(", ", AccumulatedErrors);
        }

        public Validator<T> Run() {
            if (AccumulatedErrors.Count > 0) {
                throw new RuleValidatorException(GetErrors());
            }

            return this;
        }

        public class RuleValidatorException : Exception {
            public RuleValidatorException(string message)
                : base(message) {
            }
        }
    }
}
