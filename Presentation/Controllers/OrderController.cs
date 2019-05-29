using Domain.Model.PizzaShop;
using Domain.Service;
using Infrastructure.Data;
using System.Collections.Generic;

namespace Presentation.Controllers {
    public class OrderController {
        protected OrderService Service { get; set; }

        public OrderController() {
            Service = new OrderService();
        }

        public Order Retrieve(string guid) {
            return Service.GetOrder(guid);
        }

        public ICollection<Order> Filter(ICollection<Filter> filters) {
            return Service.FindByFilters(filters);
        }

        public Order Create(Order order) {
            return Service.PlaceOrder(order);
        }

        public Order Update(Order order) {
            return Service.UpdateOrder(order);
        }

        public void Delete(Order order) {
            Service.DeleteOrder(order);
        }
    }
}
