using Domain.Repository;
using Domain.Rule.Validator;
using Domain.Model.PizzaShop;
using System.Collections.Generic;

namespace Domain.Service {
    public class OrderService {
        public static OrderService Instance { get; set; }
        private static OrderRepository Repository { get; set; }

        static OrderService() {
            Instance = new OrderService();
            Repository = new OrderRepository();
        }

        public Order GetOrder(string guid) {
            return Repository.Get(guid);
        }

        public ICollection<Order> FetchOrders(int pageSize, int offset) {
            return Repository.Fetch(pageSize, offset);
        }

        public ICollection<Order> FindOrdersByAccount(string accountId) {
            return Repository.FindOrdersByAccount(accountId);
        }

        public Order PlaceOrder(Order order) {
            new OrderValidator(order).Validate();
            return Repository.Save(order);
        }

        public Order UpdateOrder(Order order) {
            new OrderValidator(order).Validate();
            return Repository.Save(order);
        }

        public void DeleteOrder(Order order) {
            Repository.Delete(order);
        }
    }
}
