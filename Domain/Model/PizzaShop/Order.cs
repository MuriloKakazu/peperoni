namespace Data.Model.PizzaShop {
    using Infrastructure.Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Order")]
    public partial class Order : AbstractEntity {
        public Order() {
            Account = new Account();
            Pizzas = new List<Pizza>();
            Beverages = new List<Beverage>();
        }

        [Required]
        [StringLength(36)]
        public string AccountId { get; set; }

        [StringLength(32)]
        public string Status { get; set; }

        [StringLength(32)]
        public string PaymentStatus { get; set; }

        public DateTime? PlaceDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalPrice { get; set; }

        [JsonIgnore]
        public Account Account { get; set; }

        [JsonIgnore]
        public ICollection<Pizza> Pizzas { get; set; }

        [JsonIgnore]
        public ICollection<Beverage> Beverages { get; set; }
    }
}
