using Data.Model.PizzaShop;
using Domain.Builder;
using Domain.Repository.Strategies;
using Infrastructure.Builder;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository {
    public class OrderRepository : AbstractRepository<Order> {
        public OrderRepository() : 
            base("Order") {
        }

        public ICollection<Order> FindOrdersByAccount(string accountId) {
            var parameter = new ParameterBuilder<string>()
                .WithName("AccountId").WithValue(accountId).Build();

            return Marshal(
                Database.Query($"SELECT * FROM [{Entity}] WHERE AccountId = @AccountId", parameter));
        }

        public override Order Save(Order order) {
            ISaveStrategy<Order> strategy;

            if (String.IsNullOrWhiteSpace(order.Id)) {
                strategy = new OrderInsertStrategy(this);
            } else {
                strategy = new OrderUpdateStrategy(this);
            }

            return strategy.Save(order);
        }

        protected override Order Marshal(DataRow row) {
            return new OrderBuilder(row).Build();
        }

        public override ICollection<SqlParameter> GetParameters(Order order) {
            return new List<SqlParameter> {
                new ParameterBuilder<string>()
                    .WithName("Id").WithValue(order.Id).Build(),

                new ParameterBuilder<string>()
                    .WithName("AccountId").WithValue(order.AccountId).Build(),

                new ParameterBuilder<string>()
                    .WithName("Status").WithValue(order.Status).Build(),

                new ParameterBuilder<string>()
                    .WithName("PaymentStatus").WithValue(order.PaymentStatus).Build(),

                new ParameterBuilder<DateTime?>()
                    .WithName("PlaceDate").WithValue(order.PlaceDate).Build(),

                new ParameterBuilder<DateTime?>()
                    .WithName("DeliveryDate").WithValue(order.DeliveryDate).Build(),

                new ParameterBuilder<decimal?>()
                    .WithName("TotalPrice").WithValue(order.TotalPrice).Build()
            };
        }
    }
}
