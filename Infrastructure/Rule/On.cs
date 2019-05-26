using Infrastructure.Extension;
using Infrastructure.Rule.Conditions;
using System;
using System.Collections.Generic;

namespace Infrastructure.Rule {
    public static class On {
        public static OnSingle<object> Value(object value) {
            return On<object>.Value(value);
        }

        public static OnCollection<object> Values(List<object> items) {
            return new OnCollection<object>(items);
        }
    }

    public static class On<T> {

        public static OnSingle<T> Value(T item) {
            return new OnSingle<T>(item);
        }

        public static OnCollection<T> Values(List<T> items) {
            return new OnCollection<T>(items);
        }
    }

    public class OnSingle<T> {
        private T Item { get; set; }

        internal OnSingle(T item) {
            Item = item;
        }

        public When<T> When(bool condition) {
            return When((redirect) => condition);
        }

        public When<T> When(Predicate<T> condition) {
            return new When<T>(condition, Item);
        }

        public When<T> WhenNot(bool condition) {
            return WhenNot((redirect) => condition);
        }

        public When<T> WhenNot(Predicate<T> condition) {
            return new When<T>(condition.Negate(), Item);
        }
    }

    public class OnCollection<T> {
        private List<T> Items { get; set; }

        internal OnCollection(List<T> items) {
            Items = items;
        }

        public WhenEach<T> WhenEach(bool condition) {
            return WhenEach((redirect) => condition);
        }

        public WhenEach<T> WhenEach(Predicate<T> condition) {
            return new WhenEach<T>(condition, Items);
        }

        public WhenEach<T> WhenEachNot(bool condition) {
            return WhenEachNot((redirect) => condition);
        }

        public WhenEach<T> WhenEachNot(Predicate<T> condition) {
            return new WhenEach<T>(condition.Negate(), Items);
        }
    }
}
