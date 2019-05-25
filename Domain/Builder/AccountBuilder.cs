using Infrastructure.Util;
using Infrastructure.Builder;
using Domain.Model.Geolocation;
using Domain.Model.PizzaShop;
using System;
using System.Data;
using System.Collections.Generic;
using Domain.Repository;

namespace Domain.Builder {
    public class AccountBuilder : IBuilder<Account> {
        private Account Account { get; set; }

        public AccountBuilder() {
            Account = new Account();
            Account.Orders = new List<Order>();
        }

        public AccountBuilder(Account account) : this() {
            Account = account;
        }

        public AccountBuilder(DataRow row) : this() {
            Optional.Of(row["Id"])
                .IfPresent(value => {
                    WithId(value as String); });

            Optional.Of(row["Name"])
                .IfPresent(value => {
                    WithName(value as String); });

            Optional.Of(row["Phone"])
                .IfPresent(value => {
                    WithPhone(value as String); });

            Optional.Of(row["PostalCode"])
                .IfPresent(value => {
                    WithPostalCode(value as String); });

            Optional.Of(row["StreetNumber"])
                .IfPresent(value => {
                    WithStreetNumber(Convert.ToInt32(value)); });
        }

        public AccountBuilder WithId(string id) {
            Optional.Of(id)
                .IfPresent(() => {
                    Account.Id = id; });
            return this;
        }

        public AccountBuilder WithName(string name) {
            Optional.Of(name)
                .IfPresent(() => {
                    Account.Name = name; });
            return this;
        }

        public AccountBuilder WithPhone(string phone) {
            Optional.Of(phone)
                .IfPresent(() => {
                    Account.Phone = phone; });
            return this;
        }

        public AccountBuilder WithAddress(Address address) {
            return
                 WithPostalCode(address.PostalCode)
                .WithStreetNumber(Convert.ToInt32(address.HouseNumber));
        }

        public AccountBuilder WithPostalCode(string postalCode) {
            Optional.Of(postalCode)
                .IfPresent(() => {
                    Account.PostalCode = postalCode; });
            return this;
        }

        public AccountBuilder WithStreetNumber(int streetNumber) {
            Optional.Of(streetNumber)
                .IfPresent(() => {
                    Account.StreetNumber = streetNumber; });
            return this;
        }

        public AccountBuilder FetchOrders() {
            var orders = new OrderRepository().FindOrdersByAccount(Account.Id);
            return WithOrders(orders);
        }

        public AccountBuilder WithOrders(ICollection<Order> orders) {
            foreach (var order in orders) {
                WithOrder(order);
            }
            return this;
        }

        public AccountBuilder WithOrder(Order order) {
            Optional<Order>.Of(order)
                .IfPresent(() => {
                    Account.Orders.Add(order);
                    order.Account = Account;
                });
            return this;
        }

        public Account Build() {
            return Account;
        }
    }
}
