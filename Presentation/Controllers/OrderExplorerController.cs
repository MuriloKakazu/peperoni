using Domain.Model.PizzaShop;
using System.Collections.Generic;

namespace Presentation.Controllers {
    public class OrderExplorerController : OrderController {
        protected const int PAGE_SIZE = 20;

        public OrderExplorerController() : 
            base() {
        }

        public ICollection<Order> FetchPage(int page) {
            return Service.FetchOrders(PAGE_SIZE, page * PAGE_SIZE);
        }

        public ICollection<Order> SearchByAccount(Account account) {
            return Service.FindOrdersByAccount(account.Id);
        }
    }
}
