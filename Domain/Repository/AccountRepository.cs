using Infrastructure.Builder;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Repository.Strategies;
using Domain.Builder;
using Domain.Model.PizzaShop;
using Domain.Repository.Strategies.Insert;
using Domain.Repository.Strategies.Update;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Domain.Repository {
    public class AccountRepository : AbstractEntityRepository<Account> {
        protected override ISaveStrategy<Account> InsertStrategy { get; set; }
        protected override ISaveStrategy<Account> UpdateStrategy { get; set; }

        public AccountRepository() :
            base("Account") {

            InsertStrategy = new AccountInsertStrategy(this);
            UpdateStrategy = new AccountUpdateStrategy(this);
        }

        public ICollection<Account> FindAccountsByName(string name) {
            var parameter = new ParameterBuilder<string>()
                .WithName("Name").WithValue('%' + name + '%').Build();

            return Marshal(
                Database.Query($"SELECT * FROM [{Entity}] WHERE Name LIKE @Name", parameter));
        }

        protected override Account Marshal(DataRow row) {
            return new AccountBuilder(row)
                .FetchOrders()
                .Build();
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

                new ParameterBuilder<string>()
                    .WithName("StreetName").WithValue(account.StreetName).Build(),

                new ParameterBuilder<int>()
                    .WithName("StreetNumber").WithValue(account.StreetNumber).Build()
            };
        }
    }
}
