using Domain.Model.PizzaShop;
using Infrastructure.Builder;
using Infrastructure.Data;
using Infrastructure.Repository.Strategies;

namespace Domain.Repository.Strategies.Insert {
    class BeverageInsertStrategy : AbstractInsertStrategy<Beverage> {
        public BeverageInsertStrategy(BeverageRepository repository) :
            base(repository) { 
        }

        public override Beverage Save(Beverage beverage) {
            base.Save(beverage);

            var command = new CommandBuilder()
                .WithParameters(Repository.GetParameters(beverage))
                .WithSql("INSERT INTO [Beverage] (Id, OrderId, ProductId, Quantity, UnitPrice, TotalPrice) " +
                         "VALUES (@Id, @OrderId, @ProductId, @Quantity, @UnitPrice, @TotalPrice)")
                .Build();

            Database.Execute(command);

            return Repository.Get(beverage.Id);
        }
    }
}
