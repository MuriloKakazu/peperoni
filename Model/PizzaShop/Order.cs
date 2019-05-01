namespace Model.PizzaShop {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order {
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

        public virtual Account Account { get; set; }
    }
}