using Infrastructure.Util;
using Infrastructure.Builder;
using Domain.Model.Geolocation;
using Domain.Model.PizzaShop;
using System;
using System.Data;
using System.Collections.Generic;
using Domain.Repository;
using Domain.Service;

namespace Domain.Builder {
    public class AccountBuilder : IBuilder<Account> {
        private Account Account { get; set; }

        public AccountBuilder() {
            Account = new Account();
        }

        public AccountBuilder(Account account) : this() {
            Account = account;
        }

        public AccountBuilder(DataRow row) : this() {
            Optional.Of(row).IfPresent(() => {
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
                        WithPostalCode(value as String);});

                Optional.Of(row["ComplementaryAddress"])
                    .IfPresent(value => {
                        WithComplementaryAddress(value as String); });

                Optional.Of(row["StreetName"])
                    .IfPresent(value => {
                        WithStreetName(value as String); });

                Optional.Of(row["StreetNumber"])
                    .IfPresent(value => {
                        WithStreetNumber(Convert.ToInt32(value)); });
            });
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
                .WithStreetNumber(Convert.ToInt32(address.HouseNumber))
                .WithStreetName(address.Street)
                .WithComplementaryAddress(address.Additional);
        }

        public AccountBuilder WithComplementaryAddress(string complementary) {
            Optional.Of(complementary)
                .IfPresent(() => {
                    Account.ComplementaryAddress = complementary; });
            return this;
        }

        public AccountBuilder WithPostalCode(string postalCode) {
            Optional.Of(postalCode)
                .IfPresent(() => {
                    Account.PostalCode = postalCode; });
            return this;
        }

        public AccountBuilder WithStreetName(string streetName) {
            Optional.Of(streetName)
                .IfPresent(() => {
                    Account.StreetName = streetName; });
            return this;
        }

        public AccountBuilder WithStreetNumber(int streetNumber) {
            Optional.Of(streetNumber)
                .IfPresent(() => {
                    Account.StreetNumber = streetNumber; });
            return this;
        }

        public AccountBuilder FetchOrders() {
            Optional.Of(Account.Id).IfPresent(() => {
                var orders = OrderService.Instance.FindOrdersByAccount(Account.Id);
                WithOrders(orders);
            });
            return this;
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
                    order.SetAccount(Account);
                });
            return this;
        }

        public Account Build() {
            return Account;
        }
    }
}
