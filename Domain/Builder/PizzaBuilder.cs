﻿using Infrastructure.Util;
using Infrastructure.Builder;
using Domain.Model.PizzaShop;
using System;
using System.Data;
using Domain.Repository;
using Domain.Service;

namespace Domain.Builder {
    public class PizzaBuilder : IBuilder<Pizza> {
        private Pizza Pizza { get; set; }

        public PizzaBuilder() {
            Pizza = new Pizza();
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

        public PizzaBuilder WithOrder(string orderId) {
            Optional.Of(orderId)
                .IfPresent(() => {
                    Pizza.SetOrder(orderId); });
            return this;
        }

        public PizzaBuilder WithOrder(Order order) {
            Optional.Of(order)
                .IfPresent(() => {
                    Pizza.SetOrder(order); });
            return this;
        }

        public PizzaBuilder FetchProducts() {
            var service = ProductService.Instance;

            Optional.Of(Pizza.FirstToppingId).IfPresent(() => {
                WithFirstTopping(service.GetProduct(Pizza.FirstToppingId));
            });

            Optional.Of(Pizza.SecondToppingId).IfPresent(() => {
                WithSecondTopping(service.GetProduct(Pizza.SecondToppingId));
            });

            Optional.Of(Pizza.BorderId).IfPresent(() => {
                WithBorder(service.GetProduct(Pizza.BorderId));
            });

            return this;
        }

        public PizzaBuilder WithFirstTopping(string toppingId) {
            Optional.Of(toppingId)
                .IfPresent(() => {
                    Pizza.SetFirstTopping(toppingId); });
            return this;
        }

        public PizzaBuilder WithFirstTopping(Product topping) {
            Optional.Of(topping)
                .IfPresent(() => {
                    Pizza.SetFirstTopping(topping); });
            return this;
        }

        public PizzaBuilder WithSecondTopping(string toppingId) {
            Optional.Of(toppingId)
                .IfPresent(() => {
                    Pizza.SetSecondTopping(toppingId); });
            return this;
        }

        public PizzaBuilder WithSecondTopping(Product topping) {
            Optional.Of(topping)
                .IfPresent(() => {
                    Pizza.SetSecondTopping(topping); });
            return this;
        }

        public PizzaBuilder WithBorder(string borderId) {
            Optional.Of(borderId)
                .IfPresent(() => {
                    Pizza.SetBorder(borderId); });
            return this;
        }

        public PizzaBuilder WithBorder(Product border) {
            Optional.Of(border)
                .IfPresent(() => {
                    Pizza.SetBorder(border); });
            return this;
        }

        public Pizza Build() {
            return Pizza;
        }
    }
}
