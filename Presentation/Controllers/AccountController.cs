using Data.Context;
using Data.Model.PizzaShop;
using Domain.Repository;
using System;

namespace Presentation.Controllers {
    public class AccountController {
        private AccountRepository repository;

        public AccountController() {
            repository = new AccountRepository();
        }

        public Account FetchAccount(string guid) {
            return repository.GetAccountById(guid);
        }

        public void SaveAccount(Account account) {
            repository.SaveAccount(account);
        }

        public void DeleteAccount(Account account) {
            repository.DeleteAccount(account);
        }
    }
}
