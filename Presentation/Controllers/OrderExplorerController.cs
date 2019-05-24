using Domain.Model.PizzaShop;
using Domain.Repository;
using System;
using System.Collections.Generic;

namespace Presentation.Controllers {
    public class OrderExplorerController : OrderController {
        protected const int PAGE_SIZE = 20;

        public OrderExplorerController() : 
            base() {
        }

        public ICollection<Order> FetchOrders(int page) {
            return Repository.Fetch(PAGE_SIZE, page * PAGE_SIZE);
        }

        public ICollection<Order> SearchOrdersByAccount(Account account) {
            return Repository.FindOrdersByAccount(account.Id);
        }
    }
}
