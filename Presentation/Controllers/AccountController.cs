using Domain.Model.Geolocation;
using Domain.Model.PizzaShop;
using Domain.Service;
using Infrastructure.Data;
using System.Collections.Generic;

namespace Presentation.Controllers {
    public class AccountController {
        protected AccountService Service { get; set; }
        protected AddressService AddressService { get; set; }

        public AccountController() {
            Service = new AccountService();
            AddressService = new AddressService();
        }

        public Address SearchAddress(string postalCode) {
            return AddressService.GetAddressFromPostalCode(postalCode);
        }

        public Account Retrieve(string guid) {
            return Service.GetAccount(guid);
        }

        public ICollection<Account> Filter(ICollection<Filter> filters) {
            return Service.FindByFilters(filters);
        }

        public Account Save(Account account) {
            return Service.SaveAccount(account);
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
