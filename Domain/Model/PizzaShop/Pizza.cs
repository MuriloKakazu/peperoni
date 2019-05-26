namespace Domain.Model.PizzaShop {
    using Infrastructure.Data;
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Serializable]
    [Table("Pizza")]
    public partial class Pizza : AbstractEntity {
        [Required]
        [StringLength(36)]
        public string OrderId { get; set; }

        [Required]
        [StringLength(36)]
        public string FirstToppingId { get; set; }

        [Required]
        [StringLength(36)]
        public string SecondToppingId { get; set; }

        [Required]
        [StringLength(36)]
        public string BorderId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice {
            get {
                return GetUnitPrice();
            }
            set {
                UnitPrice = value;
            }
        }

        public decimal TotalPrice {
            get {
                return UnitPrice * Quantity;
            }
            set {
                TotalPrice = value;
            }
        }

        [JsonIgnore]
        public Order Order { get; set; }

        [JsonIgnore]
        public Product Border { get; set; }

        [JsonIgnore]
        public Product FirstTopping { get; set; }

        [JsonIgnore]
        public Product SecondTopping { get; set; }

        protected decimal GetUnitPrice() {
            var borderPrice = GetBorderPrice();
            var toppingPrice = GetToppingPrice();

            return borderPrice + toppingPrice;
        }

        protected decimal GetBorderPrice() {
            return (Border?.ListPrice).Value;
        }

        protected decimal GetToppingPrice() {
            return new[] { FirstTopping, SecondTopping }.Max(t => (t?.ListPrice).Value);
        }
    }
}