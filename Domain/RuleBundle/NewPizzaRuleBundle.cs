using Data.Model.PizzaShop;
using Domain.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RuleBundle {
    public class NewPizzaRuleBundle : RuleBundle<Pizza> {
        private List<Pizza> Pizzas { get; set; }

        private NewPizzaRuleBundle() {
            Pizzas = new List<Pizza>();
        }

        public NewPizzaRuleBundle(IEnumerable<Pizza> pizzas) : this() {
            Pizzas.AddRange(pizzas);
        }

        public NewPizzaRuleBundle(Pizza pizza) : this() {
            Pizzas.Add(pizza);
        }

        public RuleBundle<Pizza> Apply() {
            new RuleEngine<Pizza>(Pizzas)
                .Apply(new UnitPriceRule())
                .Apply(new TotalPriceRule())
                .Execute();

            return this;
        }

        private class UnitPriceRule : Rule<Pizza> {
            public Rule<Pizza> Apply(Pizza pizza) {
                
                pizza.UnitPrice = PriceFrom(pizza);

                return this;
            }

            private decimal PriceFrom(Pizza pizza) {
                var border = pizza.Border;
                var quantity = pizza.Quantity;

                var mostExpensiveTopping = GetMostExpensiveToppingFrom(pizza);

                var toppingPrice = PriceFrom(mostExpensiveTopping);
                var borderPrice = PriceFrom(border);

                return FullPrice(toppingPrice, borderPrice, quantity);
            }

            private decimal PriceFrom(Product product) {
                return product.ListPrice;
            }

            private Product GetMostExpensiveToppingFrom(Pizza pizza) {
                var firstTopping = pizza.FirstTopping;
                var secondTopping = pizza.SecondTopping;

                return firstTopping.ListPrice > secondTopping.ListPrice
                    ? firstTopping
                    : secondTopping;
            }

            private decimal FullPrice(decimal toppingPrice, decimal borderPrice, int quantity) {
                return (toppingPrice + borderPrice) * quantity;
            }
        }

        private class TotalPriceRule : Rule<Pizza> {
            public Rule<Pizza> Apply(Pizza pizza) {

                pizza.TotalPrice = pizza.UnitPrice * pizza.Quantity;

                return this;
            }
        }
    }
}
