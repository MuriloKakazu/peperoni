using Data.Model.PizzaShop;
using Infrastructure.Util;
using System;
using System.Data;

namespace Domain.Builder {
    public class PizzaBuilder : IBuilder<Pizza> {
        private Pizza Pizza { get; set; }

        public PizzaBuilder() {
            Pizza = new Pizza();
            Pizza.Border = new Product();
            Pizza.FirstTopping = new Product();
            Pizza.SecondTopping = new Product();
        }

        public PizzaBuilder(Pizza pizza) : this() {
            Pizza = pizza;
        }

        public PizzaBuilder(DataRow row) : this() {
            Optional.Of(row["Id"])
                .IfPresent(value => {
                    WithId(value as String); });

            Optional.Of(row["OrderId"])
                .IfPresent(value => {
                    WithOrder(value as String); });

            Optional.Of(row["Quantity"])
                .IfPresent(value => {
                    WithQuantity(Convert.ToInt32(value)); });

            Optional.Of(row["UnitPrice"])
                .IfPresent(value => {
                    WithUnitPrice(Convert.ToDecimal(value)); });

            Optional.Of(row["TotalPrice"])
                .IfPresent(value => {
                    WithTotalPrice(Convert.ToDecimal(value)); });

            Optional.Of(row["FirstToppingId"])
                .IfPresent(value => {
                    WithFirstTopping(value as String); });

            Optional.Of(row["SecondToppingId"])
                .IfPresent(value => {
                    WithSecondTopping(value as String); });

            Optional.Of(row["BorderId"])
                .IfPresent(value => {
                    WithBorder(value as String); });
        }

        public PizzaBuilder WithId(string id) {
            Optional.Of(id)
                .IfPresent(() => {
                    Pizza.Id = id; });
            return this;
        }

        public PizzaBuilder WithQuantity(int quantity) {
            Optional.Of(quantity)
                .IfPresent(() => {
                    Pizza.Quantity = quantity; });
            return this;
        }

        public PizzaBuilder WithUnitPrice(decimal unitPrice) {
            Optional.Of(unitPrice)
                .IfPresent(() => {
                    Pizza.UnitPrice = unitPrice; });
            return this;
        }

        public PizzaBuilder WithTotalPrice(decimal totalPrice) {
            Optional.Of(totalPrice)
                .IfPresent(() => {
                    Pizza.TotalPrice = totalPrice; });
            return this;
        }

        public PizzaBuilder WithOrder(string orderId) {
            Optional.Of(orderId)
                .IfPresent(() => {
                    Pizza.OrderId = orderId; });
            return this;
        }

        public PizzaBuilder WithOrder(Order order) {
            Optional.Of(order)
                .IfPresent(() => {
                    Pizza.Order = order; });
            return this;
        }

        public PizzaBuilder WithFirstTopping(string toppingId) {
            Optional.Of(toppingId)
                .IfPresent(() => {
                    Pizza.FirstToppingId = toppingId; });
            return this;
        }

        public PizzaBuilder WithFirstTopping(Product topping) {
            Optional.Of(topping)
                .IfPresent(() => {
                    Pizza.FirstTopping = topping; });
            return this;
        }

        public PizzaBuilder WithSecondTopping(string toppingId) {
            Optional.Of(toppingId)
                .IfPresent(() => {
                    Pizza.SecondToppingId = toppingId; });
            return this;
        }

        public PizzaBuilder WithSecondTopping(Product topping) {
            Optional.Of(topping)
                .IfPresent(() => {
                    Pizza.SecondTopping = topping; });
            return this;
        }

        public PizzaBuilder WithBorder(string borderId) {
            Optional.Of(borderId)
                .IfPresent(() => {
                    Pizza.BorderId = borderId; });
            return this;
        }

        public PizzaBuilder WithBorder(Product border) {
            Optional.Of(border)
                .IfPresent(() => {
                    Pizza.Border = border; });
            return this;
        }

        public Pizza Build() {
            return Pizza;
        }
    }
}
