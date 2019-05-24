using Domain.Repository;
using Domain.Rule.Validator;
using Domain.Model.PizzaShop;
using System;
using System.Linq;

namespace Domain.Service {
    public class OrderService {
        public static OrderService Instance { get; set; }
        public static PriceService PriceService { get; set; }
        private OrderRepository Repository { get; set; }

        static OrderService() {
            Instance = new OrderService();
            PriceService = PriceService.Instance;
        }

        public OrderService PlaceOrder(Order orderToPlace) {

            new NewOrderValidator(orderToPlace).Validate();

            Repository.Save(orderToPlace);

            return this;
        }
    }
}
