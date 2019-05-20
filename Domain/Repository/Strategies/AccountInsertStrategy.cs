using Data.Model.PizzaShop;
using Infrastructure.Builder;
using Infrastructure.Data;

namespace Domain.Repository.Strategies {
    public class AccountInsertStrategy : AbstractInsertStrategy<Account> {
        public AccountInsertStrategy(AccountRepository repository) : 
            base(repository) {
        }

        public override Account Save(Account account) {
            base.Save(account);

            var command = new CommandBuilder()
                .WithParameters(Repository.GetParameters(account))
                .WithSql("INSERT INTO [Account] (Id, Name, Phone, PostalCode, StreetNumber) " +
                         "VALUES (@Id, @Name, @Phone, @PostalCode, @StreetNumber)")
                .Build();

            Database.Execute(command);

            return Repository.Get(account.Id);
        }
    }
}
