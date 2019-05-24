namespace Domain.Model.PizzaShop {
    using Infrastructure.Data;
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }

        [JsonIgnore]
        public Product Border { get; set; }

        [JsonIgnore]
        public Product FirstTopping { get; set; }

        [JsonIgnore]
        public Product SecondTopping { get; set; }
    }
}