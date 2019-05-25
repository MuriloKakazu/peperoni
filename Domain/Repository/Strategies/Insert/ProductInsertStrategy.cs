using Domain.Model.PizzaShop;
using Infrastructure.Builder;
using Infrastructure.Data;
using Infrastructure.Repository.Strategies;

namespace Domain.Repository.Strategies.Insert {
    class ProductInsertStrategy : AbstractInsertStrategy<Product> {
        public ProductInsertStrategy(ProductRepository repository) : 
            base(repository) {
        }

        public override Product Save(Product product) {
            base.Save(product);

            var command = new CommandBuilder()
                .WithParameters(Repository.GetParameters(product))
                .WithSql("INSERT INTO [Product] (Id, Name, Family, ListPrice) " +
                         "VALUES (@Id, @Name, @Family, @ListPrice)")
                .Build();

            Database.Execute(command);

            return Repository.Get(product.Id);
        }
    }
}
