using Domain.Model.PizzaShop;
using Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Data;

namespace Domain.Builder {
    public class OrderBuilder : IBuilder<Order> {
        private Order Order { get; set; }

        public OrderBuilder() {
            Order = new Order();
        }

        public OrderBuilder(Order order) : this() {
            Order = order;
        }

        public OrderBuilder(DataRow row) : this() {
            Optional.Of(row["Id"])
                .IfPresent(value => {
                    WithId(value as String); });

            Optional.Of(row["AccountId"])
                .IfPresent(value => {
                    WithAccount(value as String); });

            Optional.Of(row["Status"])
                .IfPresent(value => {
                    WithStatus(value as String); });

            Optional.Of(row["PaymentStatus"])
                .IfPresent(value => {
                    WithPaymentStatus(value as String); });

            Optional.Of(row["PlaceDate"])
                .IfPresent(value => {
                    PlacedOn(value as DateTime?); });

            Optional.Of(row["DeliveryDate"])
                .IfPresent(value => {
                    DeliveredOn(value as DateTime?); });
        }

        public OrderBuilder WithId(string id) {
            Optional.Of(id)
                .IfPresent(() => {
                    Order.Id = id; });
            return this;
        }

        public OrderBuilder WithAccount(Account account) {
            Optional.Of(account)
                .IfPresent(() => {
                    Order.Account = account; });
            return this;
        }

        public OrderBuilder WithAccount(string accountId) {
            Optional.Of(accountId)
                .IfPresent(() => {
                    Order.AccountId = accountId; });
            return this;
        }

        public OrderBuilder WithStatus(string status) {
            Optional.Of(status)
                .IfPresent(() => {
                    Order.Status = status; });
            return this;
        }

        public OrderBuilder WithPaymentStatus(string status) {
            Optional.Of(status)
                .IfPresent(() => {
                    Order.PaymentStatus = status; });
            return this;
        }

        public OrderBuilder PlacedOn(DateTime? dateTime) {
            Optional.Of(dateTime)
                 .IfPresent(() => {
                     Order.PlaceDate = dateTime; });
            return this;
        }

        public OrderBuilder DeliveredOn(DateTime? dateTime) {
            Optional.Of(dateTime)
               .IfPresent(() => {
                   Order.DeliveryDate = dateTime; });
            return this;
        }

        public OrderBuilder WithPizza(Pizza pizza) {
            Optional.Of(pizza)
                .IfPresent(() => {
                    Order.Pizzas.Add(pizza); });
            return this;
        }

        public OrderBuilder WithPizzas(ICollection<Pizza> pizzas) {
            foreach (var pizza in pizzas) {
                WithPizza(pizza);
            }
            return this;
        }

        public OrderBuilder WithBeverage(Beverage beverage) {
            Optional.Of(beverage)
                .IfPresent(() => {
                    Order.Beverages.Add(beverage); });
            return this;
        }

        public OrderBuilder WithBeverages(ICollection<Beverage> beverages) {
            foreach (var beverage in beverages) {
                WithBeverage(beverage);
            }
            return this;
        }

        public Order Build() {
            return Order;
        }
    }
}
