using System;

namespace Infrastructure.Rule.Conditions {
    public interface Condition<T> {
        Condition<T> Then(Action action);
        Condition<T> Then(Action<T> action);
        Condition<T> ElseWhen(Predicate<T> condition);
        Condition<T> Else();
        T Result();
    }
}
