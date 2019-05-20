using Data.Model.PizzaShop;
using Infrastructure.Util;
using System;
using System.Data;

namespace Domain.Builder {
    public class ProductBuilder : IBuilder<Product> {
        private Product Product { get; set; }

        public ProductBuilder() { }

        public ProductBuilder(Product product) : this() {
            Product = product;
        }

        public ProductBuilder(DataRow row) : this() {
            Optional.Of(row["Id"])
                .IfPresent(value => {
                    WithId(value as String); });

            Optional.Of(row["Family"])
                .IfPresent(value => {
                    WithFamily(value as String); });

            Optional.Of(row["ListPrice"])
                .IfPresent(value => {
                    WithListPrice(Convert.ToDecimal(value)); });
        }

        public ProductBuilder WithId(string id) {
            Optional.Of(id)
                .IfPresent(() => {
                    Product.Id = id; });
            return this;
        }

        public ProductBuilder WithFamily(string family) {
            Optional.Of(family)
                .IfPresent(() => {
                    Product.Family = family; });
            return this;
        }

        public ProductBuilder WithListPrice(decimal listPrice) {
            Optional.Of(listPrice)
                .IfPresent(() => {
                    Product.ListPrice = listPrice; });
            return this;
        }

        public Product Build() {
            return Product;
        }
    }
}
