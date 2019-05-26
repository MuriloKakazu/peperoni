using Domain.Model.PizzaShop;
using Infrastructure.Rule;
using System.Collections.Generic;

namespace Domain.Rule.Validator {
    class BeverageValidator : EntityValidator<Beverage> {
        public BeverageValidator(ICollection<Beverage> beverages) :
           base(beverages) {
        }

        public BeverageValidator(Beverage beverage) :
            base(beverage) {
        }

        public override EntityValidator<Beverage> Validate() {
            new Validator<Beverage>(Entities)
                .Ensure(HasOrder, "A bebida deve estar associada a um pedido")
                .Ensure(HasProduct, "A bebida precisa estar associada a um produto")
                .Ensure(HasQuantity, "O pedido precisa ter um preço válido")
                .Run();

            return this;
        }

        bool HasOrder(Beverage beverage) {
            return beverage.OrderId != null;
        }

        bool HasProduct(Beverage beverage) {
            return beverage.ProductId != null;
        }

        bool HasQuantity(Beverage beverage) {
            return beverage.Quantity > 0;
        }
    }
}
