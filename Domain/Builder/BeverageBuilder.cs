using Infrastructure.Util;
using Infrastructure.Builder;
using Domain.Model.PizzaShop;
using System;
using System.Data;
using Domain.Repository;
using Domain.Service;

namespace Domain.Builder {
    public class BeverageBuilder : IBuilder<Beverage> {
        private Beverage Beverage { get; set; }

        public BeverageBuilder() {
            Beverage = new Beverage();
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
                    Beverage.SetOrder(orderId); });
            return this;
        }

        public BeverageBuilder WithOrder(Order order) {
            Optional.Of(order)
                .IfPresent(() => {
                    Beverage.SetOrder(order); });
            return this;
        }

        public BeverageBuilder FetchProduct() {
            Optional.Of(Beverage.ProductId).IfPresent(() => {
                var product = ProductService.Instance.GetProduct(Beverage.ProductId);
                WithProduct(product);
            });
            return this;
        }

        public BeverageBuilder WithProduct(string productId) {
            Optional.Of(productId)
                .IfPresent(() => {
                    Beverage.SetProduct(productId); });
            return this;
        }

        public BeverageBuilder WithProduct(Product product) {
            Optional.Of(product)
                .IfPresent(() => {
                    Beverage.SetProduct(product); });
            return this;
        }

        public Beverage Build() {
            return Beverage;
        }
    }
}
