using Domain.Model.PizzaShop;
using Domain.Service;

namespace Presentation.Controllers {
    public class OrderController {
        protected OrderService Service { get; set; }

        public OrderController() {
            Service = new OrderService();
        }

        public Order Retrieve(string guid) {
            return Service.GetOrder(guid);
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
