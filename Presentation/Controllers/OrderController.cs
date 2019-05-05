using Data.Context;
using Data.Model.PizzaShop;
using Domain.Repository;
using System;

namespace Presentation.Controllers {
    public class OrderController {
        private OrderRepository repository;

        public OrderController() {
            repository = new OrderRepository();
        }

        public Order FetchOrder(string guid) {
            return repository.GetOrderById(guid);
        }

        public void SaveOrder(Order order) {
            repository.SaveOrder(order);
        }

        public void DeleteOrder(Order order) {
            repository.DeleteOrder(order);
        }
    }
}
