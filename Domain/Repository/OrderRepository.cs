using Data.Context;
using Data.Model.PizzaShop;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository {
    public class OrderRepository {
        public List<Order> GetOrders(int page, int limit) {
            using (var context = new PeperoniContext()) {
                return context
                    .Orders
                    .OrderBy(order => order.Id)
                    .Skip(limit * page)
                    .Take(limit)
                    .ToList();
            }
        }

        public List<Order> FindOrdersByAccount(Account account) {
            using (var context = new PeperoniContext()) {
                return context
                    .Orders
                    .Where(order =>
                        order.AccountId == account.Id)
                    .ToList();
            }
        }

        public Order GetOrderById(string id) {
            using (var context = new PeperoniContext()) {
                return context
                    .Orders
                    .Where(
                        order => order.Id == id)
                    .FirstOrDefault();
            }
        }

        public void SaveOrder(Order order) {
            using (var context = new PeperoniContext()) {
                context.Entry(order).State = String.IsNullOrWhiteSpace(order.Id)
                    ? EntityState.Added
                    : EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void DeleteOrder(Order order) {
            using (var context = new PeperoniContext()) {
                context.Entry(order).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
