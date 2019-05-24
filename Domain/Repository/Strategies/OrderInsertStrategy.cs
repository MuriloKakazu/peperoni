using Domain.Model.PizzaShop;
using Infrastructure.Builder;
using Infrastructure.Data;

namespace Domain.Repository.Strategies {
    public class OrderInsertStrategy : AbstractInsertStrategy<Order> {
        public OrderInsertStrategy(OrderRepository repository) : 
            base(repository) {
        }

        public override Order Save(Order order) {
            base.Save(order);

            var command = new CommandBuilder()
                .WithParameters(Repository.GetParameters(order))
                .WithSql("INSERT INTO [Order] (Id, AccountId, Status, PaymentStatus, PlaceDate, DeliveryDate, TotalPrice) " +
                         "VALUES (@Id, @AccountId, @Status, @PaymentStatus, @PlaceDate, @DeliveryDate, @TotalPrice)")
                .Build();

            Database.Execute(command);

            return Repository.Get(order.Id);
        }
    }
}
