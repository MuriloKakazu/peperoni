using Infrastructure.Data;
using Infrastructure.Builder;
using Infrastructure.Repository.Strategies;
using Domain.Model.PizzaShop;

namespace Domain.Repository.Strategies.Update {
    internal class AccountUpdateStrategy : AbstractUpdateStrategy<Account> {
        public AccountUpdateStrategy(AccountRepository repository) : 
            base(repository) {
        }

        public override Account Save(Account account) {
            base.Save(account);

            var command = new CommandBuilder()
                .WithParameters(Repository.GetParameters(account))
                .WithSql("UPDATE [Account] SET " +
                             "Name = @Name, " +
                             "Phone = @Phone, " +
                             "PostalCode = @PostalCode, " +
                             "StreetName = @StreetName, " +
                             "StreetNumber = @StreetNumber " +
                         "WHERE Id = @Id")
                .Build();

            Database.Execute(command);

            return Repository.Get(account.Id);
        }
    }
}