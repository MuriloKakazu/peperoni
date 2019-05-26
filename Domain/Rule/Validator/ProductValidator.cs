using Domain.Model.PizzaShop;
using Infrastructure.Rule;
using Infrastructure.Util;
using System.Collections.Generic;

namespace Domain.Rule.Validator {
    public class ProductValidator :EntityValidator<Product> {
        public ProductValidator(ICollection<Product> products) :
           base(products) {
        }

        public ProductValidator(Product product) :
            base(product) {
        }

        public override EntityValidator<Product> Validate() {
            new Validator<Product>(Entities)
                .Ensure(HasName, "O produto deve ter um nome")
                .Ensure(HasFamily, "O produto deve pertencer a uma família de produtos")
                .Ensure(HasPrice, "O produto deve ter um preço válido")
                .Run();

            return this;
        }

        bool HasName(Product product) {
            return Regex.Pattern(@"[A-Za-z]").Matches(product.Name);
        }

        bool HasFamily(Product product) {
            return Regex.Pattern(@"[A-Za-z]").Matches(product.Family);
        }

        bool HasPrice(Product product) {
            return product.ListPrice > 0;
        }
    }
}
