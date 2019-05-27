namespace Domain.Model.PizzaShop {
    using Infrastructure.Data;
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table("Product")]
    public partial class Product : AbstractEntity {
        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(32)]
        public string Family { get; set; }

        [Column(TypeName = "money")]
        public decimal ListPrice { get; set; }

        public override string ToString() {
            return $"{Name}";
        }
    }
}