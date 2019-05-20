using Data.Model.PizzaShop;
using Domain.Repository;
using System;
using System.Collections.Generic;

namespace Presentation.Controllers {
    public class AccountController {
        protected AccountRepository Repository { get; set; }

        public AccountController() {
            Repository = new AccountRepository();
        }

        public Account GetAccount(string guid) {
            return Repository.Get(guid);
        }

        public Account SaveAccount(Account account) {
            return Repository.Save(account);
        }

        public void DeleteAccount(Account account) {
            Repository.Delete(account);
        }
    }
}
