using Domain.Model.PizzaShop;
using Infrastructure.Rule;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Domain.Rule.Validator {
    public class AccountValidator : EntityValidator<Account> {

        public AccountValidator(ICollection<Account> accounts) : 
            base(accounts) {
        }

        public AccountValidator(Account account) : 
            base(account) {
        }

        public override EntityValidator<Account> Validate() {
            new Validator<Account>(Entities)
                .Ensure(HasValidName, "A conta deve ter um nome válido")
                .Ensure(HasValidStreetNumber, "A conta deve ter um número da rua de endereço válido")
                .Ensure(HasValidStreetName, "A conta deve ter uma rua de endereço válida")
                .Ensure(HasValidPhone, "A conta deve ter um telefone válido")
                .Ensure(HasValidPostalCode, "A conta deve ter um CEP válido")
                .Run();

            return this;
        }

        bool HasValidStreetNumber(Account account) {
            return account.StreetNumber > 0;
        }

        bool HasValidStreetName(Account account) {
            return new Regex(@"[A-Za-z]").IsMatch(account.StreetName);
        }

        bool HasValidName(Account account) {
            return new Regex(@"[A-Za-z]").IsMatch(account.Name);
        }

        bool HasValidPhone(Account account) {
            return new Regex(@"^\d{10,11}$").IsMatch(account.Phone);
        }

        bool HasValidPostalCode(Account account) {
            return new Regex(@"^\d{8}$").IsMatch(account.PostalCode);
        }
    }
}
