using Domain.Model.PizzaShop;
using Infrastructure.Builder;
using Infrastructure.Data;
using Infrastructure.Repository.Strategies;

namespace Domain.Repository.Strategies.Update {
    public class BeverageUpdateStrategy : AbstractUpdateStrategy<Beverage> {
        public BeverageUpdateStrategy(BeverageRepository repository) : 
            base(repository) {
        }

        public override Beverage Save(Beverage beverage) {
            base.Save(beverage);

            var command = new CommandBuilder()
                .WithParameters(Repository.GetParameters(beverage))
                 .WithSql("UPDATE [Beverage] SET " +
                             "OrderId = @OrderId, " +
                             "ProductId = @ProductId " +
                             "Quantity = @Quantity " +
                             "UnitPrice = @UnitPrice " +
                             "TotalPrice = @TotalPrice " +
                         "WHERE Id = @Id")
                .Build();

            Database.Execute(command);

            return Repository.Get(beverage.Id);
        }
    }
}
