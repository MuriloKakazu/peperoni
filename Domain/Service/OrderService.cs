using Data.Model.PizzaShop;
using Domain.Builder;
using Domain.Engine;
using Domain.Engine.Validator;
using Domain.Repository;
using Domain.RuleBundle;
using System;

namespace Domain.Service {
    public class OrderService {
        private OrderRepository Repository { get; set; }

        public OrderService PlaceOrder(Order order) {
            new NewOrderValidator(order).Validate();
            new NewOrderRuleBundle(order).Apply();

            Repository.Save(order);

            return this;
        }


    }
}
