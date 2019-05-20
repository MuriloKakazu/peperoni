namespace Data.Model.PizzaShop {
    using Infrastructure.Data;
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table("Beverage")]
    public partial class Beverage : AbstractEntity {
        [Required]
        [StringLength(36)]
        public string OrderId { get; set; }

        [Required]
        [StringLength(36)]
        public string ProductId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }
    }
}