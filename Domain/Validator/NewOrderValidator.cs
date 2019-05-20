using Data.Model.PizzaShop;
using System.Collections.Generic;

namespace Domain.Engine.Validator {
    public class NewOrderValidator {
        private List<Order> Orders { get; set; }

        private NewOrderValidator() {
            Orders = new List<Order>();
        }

        public NewOrderValidator(IEnumerable<Order> orders) : this() {
            Orders.AddRange(orders);
        }

        public NewOrderValidator(Order order) : this() {
            Orders.Add(order);
        }

        public NewOrderValidator Validate() {
            new RuleEngine<Order>(Orders)
                .Apply(new HasAccount(), "Order must have an account")
                .Execute();

            return this;
        }

        private class HasAccount : Predicate<Order> {
            public bool IsValid(Order order) {
                return
                    order.AccountId != null;
            }
        }
    }
}
