namespace Data.Model.PizzaShop {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Diagnostics.CodeAnalysis;

    [Table("Order")]
    public partial class Order {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order() {
            Beverages = new HashSet<Beverage>();
            Pizzas = new HashSet<Pizza>();
        }

        [StringLength(36)]
        public string Id { get; set; }

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
        public virtual Account Account { get; set; }

        [JsonIgnore]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Beverage> Beverages { get; set; }

        [JsonIgnore]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
