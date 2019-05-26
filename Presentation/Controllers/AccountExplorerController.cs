using Domain.Model.PizzaShop;
using System.Collections.Generic;

namespace Presentation.Controllers {
    public class AccountExplorerController : AccountController {
        protected const int PAGE_SIZE = 20;

        public AccountExplorerController() : 
            base() {
        }

        public ICollection<Account> FetchPage(int page) {
            return Service.FetchAccounts(PAGE_SIZE, page * PAGE_SIZE);
        }

        public ICollection<Account> SearchByName(string name) {
            return Service.FindAccountsByName(name);
        }
    }
}
