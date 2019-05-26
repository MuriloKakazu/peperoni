using Domain.Model.PizzaShop;
using Infrastructure.Rule;
using System.Collections.Generic;

namespace Domain.Rule.Validator {
    public class PizzaValidator : EntityValidator<Pizza> {
        public PizzaValidator(ICollection<Pizza> pizzas) :
            base(pizzas) {
        }

        public PizzaValidator(Pizza pizza) :
            base(pizza) {
        }

        public override EntityValidator<Pizza> Validate() {
            new Validator<Pizza>(Entities)
                .Ensure(HasOrder, "A pizza deve estar associada a um pedido")
                .Ensure(HasToppings, "A pizza precisa de sabores")
                .Ensure(HasBorder, "A pizza precisa de uma borda")
                .Ensure(HasQuantity, "A quantidade da pizza deve ser definida")
                .Run();

            return this;
        }

        bool HasOrder(Pizza pizza) {
            return pizza.OrderId != null;
        }

        bool HasToppings(Pizza pizza) {
            return 
                pizza.FirstToppingId != null && 
                pizza.SecondToppingId != null;
        }

        bool HasBorder(Pizza pizza) {
            return pizza.BorderId != null;
        }

        bool HasQuantity(Pizza pizza) {
            return pizza.Quantity > 0;
        }
    }
}
