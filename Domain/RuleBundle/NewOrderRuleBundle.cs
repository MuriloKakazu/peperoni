using Data.Model.PizzaShop;
using Domain.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RuleBundle {
    public class NewOrderRuleBundle : RuleBundle<Order> {
        private List<Order> Orders { get; set; }

        private NewOrderRuleBundle() {
            Orders = new List<Order>();
        }

        public NewOrderRuleBundle(ICollection<Order> orders) : this() {
            Orders.AddRange(orders);
        }

        public NewOrderRuleBundle(Order order) : this() {
            Orders.Add(order);
        }

        public RuleBundle<Order> Apply() {
            new RuleEngine<Order>(Orders)
                .Apply(new TotalPriceRule())
                .Execute();

            return this;
        }

        private class TotalPriceRule : Rule<Order> {
            public Rule<Order> Apply(Order order) {

                order.TotalPrice = 
                    order.Pizzas.Sum(pizza => pizza.TotalPrice) + 
                    order.Beverages.Sum(beverage => beverage.TotalPrice);

                return this;
            }
        }
    }
}
