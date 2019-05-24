using Domain.Model.PizzaShop;
using Infrastructure.Builder;
using Infrastructure.Data;

namespace Domain.Repository.Strategies {
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
                             "StreetNumber = @StreetNumber " +
                         "WHERE Id = @Id")
                .Build();

            Database.Execute(command);

            return Repository.Get(account.Id);
        }
    }
}