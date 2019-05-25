using Domain.Builder;
using Domain.Model.PizzaShop;
using Domain.Repository.Strategies.Insert;
using Domain.Repository.Strategies.Update;
using Infrastructure.Builder;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Repository.Strategies;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository {
    public class BeverageRepository : AbstractEntityRepository<Beverage> {
        public BeverageRepository() : 
            base("Beverage") {
        }

        public ICollection<Beverage> FindBeveragesByOrder(string orderId) {
            var parameter = new ParameterBuilder<string>()
                .WithName("OrderId").WithValue(orderId).Build();

            return Marshal(
                Database.Query($"SELECT * FROM [{Entity}] WHERE OrderId = @OrderId", parameter));
        }

        public override Beverage Save(Beverage beverage) {
            ISaveStrategy<Beverage> strategy;

            if (String.IsNullOrWhiteSpace(beverage.Id)) {
                strategy = new BeverageInsertStrategy(this);
            } else {
                strategy = new BeverageUpdateStrategy(this);
            }

            return strategy.Save(beverage);
        }

        protected override Beverage Marshal(DataRow row) {
            return new BeverageBuilder(row)
                .FetchProduct()
                .Build();
        }

        public override ICollection<SqlParameter> GetParameters(Beverage beverage) {
            return new List<SqlParameter> {
                new ParameterBuilder<string>()
                    .WithName("Id").WithValue(beverage.Id).Build(),

                new ParameterBuilder<string>()
                    .WithName("OrderId").WithValue(beverage.OrderId).Build(),

                new ParameterBuilder<string>()
                    .WithName("ProductId").WithValue(beverage.ProductId).Build(),

                new ParameterBuilder<int>()
                    .WithName("Quantity").WithValue(beverage.Quantity).Build(),

                new ParameterBuilder<decimal>()
                    .WithName("UnitPrice").WithValue(beverage.UnitPrice).Build(),

                new ParameterBuilder<decimal>()
                    .WithName("TotalPrice").WithValue(beverage.TotalPrice).Build()
            };
        }
    }
}
