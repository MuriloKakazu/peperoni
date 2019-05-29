using Domain.Model.PizzaShop;
using Domain.Service;
using System.Linq;

namespace Presentation.Controllers {
    public class OrderController {
        protected OrderService OrderService { get; set; }
        protected PizzaService PizzaService { get; set; }
        protected BeverageService BeverageService { get; set; }

        public OrderController() {
            OrderService    = new OrderService();
            PizzaService    = new PizzaService();
            BeverageService = new BeverageService();
        }

        public Order Retrieve(string guid) {
            return OrderService.GetOrder(guid);
        }

        public Order Create(Order order) {
            return OrderService.PlaceOrder(order);
        }

        public Order Update(Order order) {
            return OrderService.UpdateOrder(order);
        }

        public void Delete(Order order) {
            OrderService.DeleteOrder(order);
        }

        public void DeepCreate(Order order) {
            Create(order);
            order.GetPizzas().ToList().ForEach(pizza => {
                pizza.SetOrder(order);
                PizzaService.CreatePizza(pizza);
            });
            order.GetBeverages().ToList().ForEach(beverage => {
                beverage.SetOrder(order);
                BeverageService.CreateBeverage(beverage);
            });
        }
    }
}
