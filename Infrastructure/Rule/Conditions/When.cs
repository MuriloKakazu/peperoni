using System;

namespace Infrastructure.Rule.Conditions {
    public class When<T> : AbstractCondition<T> {
        public When(Predicate<T> condition, T target) :
            base(condition, target) {
        }

        public override Condition<T> Then(Action<T> action) {
            if (Condition(Target) && !Satisfied) {
                action.Invoke(Target);
                Satisfied = true;
            }
            return this;
        }

        public Condition<T> Then(Func<T, T> action) {
            if (Condition(Target) && !Satisfied) {
                Target = action.Invoke(Target);
                Satisfied = true;
            }
            return this;
        }

        public override Condition<T> ElseWhen(Predicate<T> condition) {
            if (!Satisfied) {
                return new When<T>(condition, Target);
            }
            return this;
        }

        public override Condition<T> Else() {
            if (!Satisfied) {
                return new When<T>((redirect) => true, Target);
            }
            return this;
        }
    }
}
