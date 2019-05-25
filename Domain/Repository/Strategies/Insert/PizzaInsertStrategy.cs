using Domain.Model.PizzaShop;
using Infrastructure.Builder;
using Infrastructure.Data;
using Infrastructure.Repository.Strategies;

namespace Domain.Repository.Strategies.Insert {
    class PizzaInsertStrategy : AbstractInsertStrategy<Pizza> {
        public PizzaInsertStrategy(PizzaRepository repository) :
            base(repository) {
        }

        public override Pizza Save(Pizza pizza) {
            base.Save(pizza);

            var command = new CommandBuilder()
                .WithParameters(Repository.GetParameters(pizza))
                .WithSql("INSERT INTO [Pizza] (Id, OrderId, FirstToppingId, SecondToppingId, BorderId, Quantity, UnitPrice, TotalPrice) " +
                         "VALUES (@Id, @OrderId, @FirstToppingId, @SecondToppingId, @BorderId, @Quantity, @UnitPrice, @TotalPrice)")
                .Build();

            Database.Execute(command);

            return Repository.Get(pizza.Id);
        }
    }
}
