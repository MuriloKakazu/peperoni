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
    public class ProductRepository : AbstractEntityRepository<Product> {
        protected override ISaveStrategy<Product> InsertStrategy { get; set; }
        protected override ISaveStrategy<Product> UpdateStrategy { get; set; }

        public ProductRepository() : 
            base("Product") {

            InsertStrategy = new ProductInsertStrategy(this);
            UpdateStrategy = new ProductUpdateStrategy(this);
        }

        public ICollection<Product> FindByFamily(string family) {
            var parameter = new ParameterBuilder<string>()
                .WithName("Family").WithValue(family).Build();

            return Marshal(
                Database.Query($"SELECT * FROM [{Entity}] WHERE Family = @Family", parameter));
        }

        protected override Product Marshal(DataRow row) {
            return new ProductBuilder(row).Build();
        }

        public override ICollection<SqlParameter> GetParameters(Product product) {
            return new List<SqlParameter> {
                new ParameterBuilder<string>()
                    .WithName("Id").WithValue(product.Id).Build(),

                new ParameterBuilder<string>()
                    .WithName("Name").WithValue(product.Name).Build(),

                new ParameterBuilder<string>()
                    .WithName("Family").WithValue(product.Family).Build(),

                new ParameterBuilder<decimal>()
                    .WithName("ListPrice").WithValue(product.ListPrice).Build()
            };
        }
    }
}
