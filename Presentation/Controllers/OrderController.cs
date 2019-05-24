using Domain.Model.PizzaShop;
using Domain.Repository;
using System;

namespace Presentation.Controllers {
    public class OrderController {
        protected OrderRepository Repository { get; set; }

        public OrderController() {
            Repository = new OrderRepository();
        }

        public Order FetchOrder(string guid) {
            return Repository.Get(guid);
        }

        public void SaveOrder(Order order) {
            Repository.Save(order);
        }

        public void DeleteOrder(Order order) {
            Repository.Delete(order);
        }
    }
}
