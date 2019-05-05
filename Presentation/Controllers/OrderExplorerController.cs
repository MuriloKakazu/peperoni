using Data.Context;
using Data.Model.PizzaShop;
using Domain.Repository;
using System;
using System.Collections.Generic;

namespace Presentation.Controllers {
    public class OrderExplorerController : OrderController {
        private OrderRepository repository;

        public OrderExplorerController() {
            repository = new OrderRepository();
        }

        public List<Order> FetchOrders(int page) {
            return repository.GetOrders(page, 25);
        }

        public List<Order> SearchOrdersByAccount(Account account) {
            return repository.FindOrdersByAccount(account);
        }
    }
}
