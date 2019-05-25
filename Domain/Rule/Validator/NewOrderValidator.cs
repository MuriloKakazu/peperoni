﻿using Infrastructure.Rule;
using Domain.Model.PizzaShop;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Rule.Validator {
    public class NewOrderValidator {
        private List<Order> Orders { get; set; }

        private NewOrderValidator() {
            Orders = new List<Order>();
        }

        public NewOrderValidator(ICollection<Order> orders) : this() {
            Orders.AddRange(orders);
        }

        public NewOrderValidator(Order order) : this() {
            Orders.Add(order);
        }

        public NewOrderValidator Validate() {
            new Validator<Order>(Orders)
                .Ensure(HasAccount, "O pedido deve estar associado a uma conta")
                .Ensure(HasItems, "O pedido precisa conter produtos")
                .Ensure(HasPrice, "O pedido precisa ter um preço válido")
                .Run();

            return this;
        }

        bool HasAccount(Order order) {
            return order.AccountId != null;
        }

        bool HasItems(Order order) {
            return order.Beverages.Any() || order.Pizzas.Any();
        }

        bool HasPrice(Order order) {
            return order.TotalPrice > 0;
        }
    }
}
