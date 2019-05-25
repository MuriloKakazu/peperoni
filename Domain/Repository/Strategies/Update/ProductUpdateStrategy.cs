using Domain.Model.PizzaShop;
using Infrastructure.Builder;
using Infrastructure.Data;
using Infrastructure.Repository.Strategies;

namespace Domain.Repository.Strategies.Update {
    class ProductUpdateStrategy : AbstractUpdateStrategy<Product> {
        public ProductUpdateStrategy(ProductRepository repository) : 
            base(repository) {
        }

        public override Product Save(Product product) {
            base.Save(product);

            var command = new CommandBuilder()
                .WithParameters(Repository.GetParameters(product))
                 .WithSql("UPDATE [Product] SET " +
                             "Name = @Name, " +
                             "Family = @Family, " +
                             "ListPrice = @ListPrice " +
                         "WHERE Id = @Id")
                .Build();

            Database.Execute(command);

            return Repository.Get(product.Id);
        }
    }
}
