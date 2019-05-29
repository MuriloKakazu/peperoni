namespace Domain.Model.PizzaShop {
    using Infrastructure.Data;
    using Infrastructure.Rule;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("Order")]
    public partial class Order : AbstractEntity {
        [Required]
        [StringLength(36)]
        public string AccountId { get; private set; }

        [StringLength(32)]
        public string Status { get; set; }

        [StringLength(32)]
        public string PaymentStatus { get; set; }

        public DateTime? PlaceDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice {
            get {
                return GetTotalPrice();
            }
            set {
                TotalPrice = value;
            }
        }

        [JsonIgnore]
        public Account Account { get; private set; }

        [JsonIgnore]
        private ICollection<Pizza> Pizzas { get; set; }

        [JsonIgnore]
        private ICollection<Beverage> Beverages { get; set; }

        public Order() {
            Account = new Account();
            Pizzas = new List<Pizza>();
            Beverages = new List<Beverage>();
        }

        public Order SetAccount(Account account) {
            AccountId = account.Id;
            Account = account;
            return this;
        }

        public Order SetAccount(string accountId) {
            AccountId = accountId;
            Account = null;
            return this;
        }

        public IReadOnlyCollection<Pizza> GetPizzas() {
            return new ReadOnlyCollection<Pizza>(Pizzas.ToList());
        }

        public IReadOnlyCollection<Beverage> GetBeverages() {
            return new ReadOnlyCollection<Beverage>(Beverages.ToList());
        }

        public decimal GetTotalPrice() {
            return Pizzas.Sum(p => p.TotalPrice) +
                Beverages.Sum(b => b.TotalPrice);
        }

        public Order AddPizza(Pizza pizza) {
            ValidateNewPizza(pizza);
            Pizzas.Add(pizza);
            return this;
        }

        public Order AddBeverage(Beverage beverage) {
            ValidateNewBeverage(beverage);
            Beverages.Add(beverage);
            return this;
        }

        public Order ClearPizzas() {
            this.Pizzas = new List<Pizza>();
            return this;
        }

        public Order ClearBeverages() {
            this.Beverages = new List<Beverage>();
            return this;
        }

        private void ValidateNewPizza(Pizza pizza) {
            Pizzas.ToList().ForEach(p => {
                new Validator<Pizza>(pizza)
                    .Ensure(!pizza.IsSimilarTo(p), $"A pizza \"{pizza}\" já existe nesse pedido!")
                    .Run();
            });
        }

        private void ValidateNewBeverage(Beverage beverage) {
            Beverages.ToList().ForEach(b => {
                new Validator<Beverage>(beverage)
                    .Ensure(!beverage.IsSimilarTo(b), $"O produto \"{beverage}\" já existe nesse pedido!")
                    .Run();
            });
        }
    }
}
