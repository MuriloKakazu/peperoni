using System;

namespace Infrastructure.Rule.Conditions {
    public abstract class AbstractCondition<T> : Condition<T> {
        protected Predicate<T> Condition { get; set; }
        protected T Target { get; set; }
        protected bool Satisfied { get; set; }

        public AbstractCondition(Predicate<T> condition, T target) {
            Condition = condition;
            Target = target;
        }

        public abstract Condition<T> Then(Action<T> action);
        public abstract Condition<T> ElseWhen(Predicate<T> condition);
        public abstract Condition<T> Else();

        public Condition<T> Then(Action action) {
            return Then((redirect) => { action.Invoke(); });
        }

        public T Result() {
            return Target;
        }
    }
}
