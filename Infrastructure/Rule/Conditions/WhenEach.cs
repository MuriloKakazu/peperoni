using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Rule.Conditions {
    public class WhenEach<T> : AbstractCondition<T> {
        protected new List<T> Target { get; set; }

        public WhenEach(Predicate<T> condition, List<T> target) :
            base(condition, default(T)) {
            Target = target;
        }

        public override Condition<T> Then(Action<T> action) {
            if (!Satisfied) {
                Target.Where(item => Condition(item)).ToList()
                    .ForEach(item => {
                        action.Invoke(item);
                        Satisfied = true; });
            }
            return this;
        }

        public override Condition<T> ElseWhen(Predicate<T> condition) {
            if (!Satisfied) {
                return new WhenEach<T>(condition, Target);
            }
            return this;
        }

        public override Condition<T> Else() {
            if (!Satisfied) {
                return new WhenEach<T>((redirect) => true, Target);
            }
            return this;
        }
    }
}
