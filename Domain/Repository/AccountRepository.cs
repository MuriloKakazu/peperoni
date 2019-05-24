using Domain.Model.PizzaShop;
using Domain.Builder;
using Domain.Repository.Strategies;
using Infrastructure.Builder;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Domain.Repository {
    public class AccountRepository : AbstractRepository<Account> {
        public AccountRepository() :
            base("Account") {
        }

        public ICollection<Account> FindAccountsByName(string name) {
            var parameter = new ParameterBuilder<string>()
                .WithName("Name").WithValue(name).Build();

            return Marshal(
                Database.Query($"SELECT * FROM [{Entity}] WHERE Name LIKE '%@Name%'", parameter));
        }

        protected override Account Marshal(DataRow row) {
            return new AccountBuilder(row).Build();
        }

        public override Account Save(Account account) {
            ISaveStrategy<Account> strategy;

            if (String.IsNullOrWhiteSpace(account.Id)) {
                strategy = new AccountInsertStrategy(this);
            } else {
                strategy = new AccountUpdateStrategy(this);
            }

            return strategy.Save(account);
        }

        public override ICollection<SqlParameter> GetParameters(Account account) {
            return new List<SqlParameter> {
                new ParameterBuilder<string>()
                    .WithName("Id").WithValue(account.Id).Build(),

                new ParameterBuilder<string>()
                    .WithName("Name").WithValue(account.Name).Build(),

                new ParameterBuilder<string>()
                    .WithName("Phone").WithValue(account.Phone).Build(),

                new ParameterBuilder<string>()
                    .WithName("PostalCode").WithValue(account.PostalCode).Build(),

                new ParameterBuilder<int>()
                    .WithName("StreetNumber").WithValue(account.StreetNumber).Build()
            };
        }
    }
}
