using Infrastructure.Data;
using Infrastructure.Builder;
using Infrastructure.Repository.Strategies;
using Domain.Model.PizzaShop;

namespace Domain.Repository.Strategies.Insert {
    public class OrderInsertStrategy : AbstractInsertStrategy<Order> {
        public OrderInsertStrategy(OrderRepository repository) : 
            base(repository) {
        }

        public override Order Save(Order order) {
            base.Save(order);

            var command = new CommandBuilder()
                .WithParameters(Repository.GetParameters(order))
                .WithSql("INSERT INTO [Order] (Id, AccountId, Status, PaymentStatus, PlaceDate, DeliveryDate) " +
                         "VALUES (@Id, @AccountId, @Status, @PaymentStatus, @PlaceDate, @DeliveryDate)")
                .Build();

            Database.Execute(command);

            return Repository.Get(order.Id);
        }
    }
}
