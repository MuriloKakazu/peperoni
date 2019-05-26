using Domain.Model.PizzaShop;
using Domain.Service;

namespace Presentation.Controllers {
    public class AccountController {
        protected AccountService Service { get; set; }

        public AccountController() {
            Service = new AccountService();
        }

        public Account Retrieve(string guid) {
            return Service.GetAccount(guid);
        }

        public Account Create(Account account) {
            return Service.CreateAccount(account);
        }

        public Account Update(Account account) {
            return Service.UpdateAccount(account);
        }

        public void Delete(Account account) {
            Service.DeleteAccount(account);
        }
    }
}
