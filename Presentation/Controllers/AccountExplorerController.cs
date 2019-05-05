using Data.Context;
using Data.Model.PizzaShop;
using Domain.Repository;
using System;
using System.Collections.Generic;

namespace Presentation.Controllers {
    public class AccountExplorerController : AccountController {
        private AccountRepository repository;

        public AccountExplorerController() {
            repository = new AccountRepository();
        }

        public List<Account> FetchAccounts(int page) {
            return repository.GetAccounts(page, 25);
        }

        public List<Account> SearchAccountsByName(string name) {
            return repository.FindAccountsByName(name);
        }
    }
}
