using Domain.Model.PizzaShop;
using Infrastructure.Builder;
using Infrastructure.Data;
using Infrastructure.Repository.Strategies;

namespace Domain.Repository.Strategies.Update {
    public class PizzaUpdateStrategy : AbstractUpdateStrategy<Pizza> {
        public PizzaUpdateStrategy(PizzaRepository repository) : 
            base(repository) {
        }

        public override Pizza Save(Pizza pizza) {
            base.Save(pizza);

            var command = new CommandBuilder()
                .WithParameters(Repository.GetParameters(pizza))
                .WithSql("UPDATE [Pizza] SET " +
                             "OrderId = @OrderId, " +
                             "FirstToppingId = @FirstToppingId, " +
                             "SecondToppingId = @SecondToppingId, " +
                             "BorderId = @BorderId " +
                             "Quantity = @Quantity " +
                             "UnitPrice = @UnitPrice " +
                             "TotalPrice = @TotalPrice " +
                         "WHERE Id = @Id")
                .Build();

            Database.Execute(command);

            return Repository.Get(pizza.Id);
        }
    }
}
