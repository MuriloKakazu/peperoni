using Data.Context;
using Data.Model.PizzaShop;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Domain.Repository {
    public class AccountRepository {
        public List<Account> GetAccounts(int page, int limit) {
            using (var context = new PeperoniContext()) {
                return context
                    .Accounts
                    .OrderBy(account => account.Id)
                    .Skip(limit * page)
                    .Take(limit)
                    .ToList();
            }
        }

        public List<Account> FindAccountsByName(string name) {
            using (var context = new PeperoniContext()) {
                return context
                    .Accounts
                    .Where(account => 
                        account.Name.ToLower().Contains(name.ToLower()))
                    .ToList();
            }
        }

        public Account GetAccountById(string id) {
            using (var context = new PeperoniContext()) {
                return context
                    .Accounts
                    .Where(
                        account => account.Id == id)
                    .FirstOrDefault();
            }
        }

        public void SaveAccount(Account account) {
            using (var context = new PeperoniContext()) {
                context.Entry(account).State = String.IsNullOrWhiteSpace(account.Id)
                    ? EntityState.Added
                    : EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void DeleteAccount(Account account) {
            using (var context = new PeperoniContext()) {
                context.Entry(account).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
