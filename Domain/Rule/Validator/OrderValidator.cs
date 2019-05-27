using Infrastructure.Rule;
using Domain.Model.PizzaShop;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Rule.Validator {
    public class OrderValidator : EntityValidator<Order> {
        public OrderValidator(ICollection<Order> orders) : 
            base(orders) {
        }

        public OrderValidator(Order order) : 
            base(order) {
        }

        public override EntityValidator<Order> Validate() {
            new Validator<Order>(Entities)
                .Ensure(HasAccount, "O pedido deve estar associado a uma conta")
                .Ensure(HasItems, "O pedido precisa conter produtos")
                .Ensure(HasPrice, "O pedido precisa ter um preço válido")
                .Run();

            return this;
        }

        bool HasAccount(Order order) {
            return order.AccountId != null;
        }

        bool HasItems(Order order) {
            return order.GetBeverages().Any() || order.GetPizzas().Any();
        }

        bool HasPrice(Order order) {
            return order.TotalPrice > 0;
        }
    }
}
