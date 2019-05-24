using Domain.Model.PizzaShop;
using Domain.Repository;
using System;
using System.Collections.Generic;

namespace Presentation.Controllers {
    public class AccountExplorerController : AccountController {
        protected const int PAGE_SIZE = 20;

        public AccountExplorerController() : 
            base() {
        }

        public ICollection<Account> FetchPage(int page) {
            return Repository.Fetch(PAGE_SIZE, page * PAGE_SIZE);
        }

        public ICollection<Account> SearchAccountsByName(string name) {
            return Repository.FindAccountsByName(name);
        }
    }
}
