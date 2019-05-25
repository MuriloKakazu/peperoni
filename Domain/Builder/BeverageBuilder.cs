using Infrastructure.Util;
using Infrastructure.Builder;
using Domain.Model.PizzaShop;
using System;
using System.Data;

namespace Domain.Builder {
    public class BeverageBuilder : IBuilder<Beverage> {
        private Beverage Beverage { get; set; }

        public BeverageBuilder() {
            Beverage.Order = new Order();
        }

        public BeverageBuilder(Beverage beverage) : this() {
            Beverage = beverage;
        }

        public BeverageBuilder(DataRow row) : this() {
            Optional.Of(row["Id"])
                .IfPresent(value => {
                    WithId(value as String); });

            Optional.Of(row["OrderId"])
                .IfPresent(value => {
                    WithOrder(value as String); });

            Optional.Of(row["ProductId"])
                .IfPresent(value => {
                    WithProduct(value as String); });

            Optional.Of(row["Quantity"])
                .IfPresent(value => {
                    WithQuantity(Convert.ToInt32(value)); });
        }

        public BeverageBuilder WithId(string id) {
            Optional.Of(id)
                .IfPresent(() => {
                    Beverage.Id = id; });
            return this;
        }

        public BeverageBuilder WithQuantity(int quantity) {
            Optional.Of(quantity)
                .IfPresent(() => {
                    Beverage.Quantity = quantity; });
            return this;
        }

        public BeverageBuilder WithOrder(string orderId) {
            Optional.Of(orderId)
                .IfPresent(() => {
                    Beverage.OrderId = orderId; });
            return this;
        }

        public BeverageBuilder WithOrder(Order order) {
            Optional.Of(order)
                .IfPresent(() => {
                    Beverage.Order = order; });
            return this;
        }

        public BeverageBuilder WithProduct(string productId) {
            Optional.Of(productId)
                .IfPresent(() => {
                    Beverage.ProductId = productId; });
            return this;
        }

        public BeverageBuilder WithProduct(Product product) {
            Optional.Of(product)
                .IfPresent(() => {
                    Beverage.Product = product; });
            return this;
        }

        public Beverage Build() {
            return Beverage;
        }
    }
}
