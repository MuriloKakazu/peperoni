using Infrastructure.Data;
using Infrastructure.Builder;
using Infrastructure.Repository.Strategies;
using Domain.Model.PizzaShop;

namespace Domain.Repository.Strategies.Insert {
    public class AccountInsertStrategy : AbstractInsertStrategy<Account> {
        public AccountInsertStrategy(AccountRepository repository) : 
            base(repository) {
        }

        public override Account Save(Account account) {
            base.Save(account);

            var command = new CommandBuilder()
                .WithParameters(Repository.GetParameters(account))
                .WithSql("INSERT INTO [Account] (Id, Name, Phone, PostalCode, StreetName, StreetNumber, ComplementaryAddress) " +
                         "VALUES (@Id, @Name, @Phone, @PostalCode, @StreetName, @StreetNumber, @ComplementaryAddress)")
                .Build();

            Database.Execute(command);

            return Repository.Get(account.Id);
        }
    }
}
