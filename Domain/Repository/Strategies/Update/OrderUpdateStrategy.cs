using Infrastructure.Data;
using Infrastructure.Builder;
using Infrastructure.Repository.Strategies;
using Domain.Model.PizzaShop;

namespace Domain.Repository.Strategies.Update {
    internal class OrderUpdateStrategy : AbstractUpdateStrategy<Order> {
        public OrderUpdateStrategy(OrderRepository repository) : 
            base(repository) {
        }

        public override Order Save(Order order) {
            base.Save(order);

            var command = new CommandBuilder()
                .WithParameters(Repository.GetParameters(order))
                .WithSql("UPDATE [Order] SET " +
                             "AccountId = @AccountId, " +
                             "Status = @Status, " +
                             "PaymentStatus = @PaymentStatus, " +
                             "PlaceDate = @PlaceDate, " +
                             "DeliveryDate = @DeliveryDate " +
                         "WHERE Id = @Id")
                .Build();

            Database.Execute(command);

            return Repository.Get(order.Id);
        }
    }
}