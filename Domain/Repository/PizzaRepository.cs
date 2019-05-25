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
    public class PizzaRepository : AbstractEntityRepository<Pizza> {
        protected override ISaveStrategy<Pizza> InsertStrategy { get; set; }
        protected override ISaveStrategy<Pizza> UpdateStrategy { get; set; }

        public PizzaRepository() : 
            base("Pizza") {

            InsertStrategy = new PizzaInsertStrategy(this);
            UpdateStrategy = new PizzaUpdateStrategy(this);
        }

        public ICollection<Pizza> FindPizzasByOrder(string orderId) {
            var parameter = new ParameterBuilder<string>()
                .WithName("OrderId").WithValue(orderId).Build();

            return Marshal(
                Database.Query($"SELECT * FROM [{Entity}] WHERE OrderId = @OrderId", parameter));
        }

        protected override Pizza Marshal(DataRow row) {
            return new PizzaBuilder(row)
                .FetchProducts()
                .Build();
        }

        public override ICollection<SqlParameter> GetParameters(Pizza pizza) {
            return new List<SqlParameter> {
                new ParameterBuilder<string>()
                    .WithName("Id").WithValue(pizza.Id).Build(),

                new ParameterBuilder<string>()
                    .WithName("OrderId").WithValue(pizza.OrderId).Build(),

                new ParameterBuilder<string>()
                    .WithName("FirstToppingId").WithValue(pizza.FirstToppingId).Build(),

                new ParameterBuilder<string>()
                    .WithName("SecondToppingId").WithValue(pizza.SecondToppingId).Build(),

                new ParameterBuilder<string>()
                    .WithName("BorderId").WithValue(pizza.BorderId).Build(),

                new ParameterBuilder<int>()
                    .WithName("Quantity").WithValue(pizza.Quantity).Build(),

                new ParameterBuilder<decimal>()
                    .WithName("UnitPrice").WithValue(pizza.UnitPrice).Build(),

                new ParameterBuilder<decimal>()
                    .WithName("TotalPrice").WithValue(pizza.TotalPrice).Build()
            };
        }
    }
}
