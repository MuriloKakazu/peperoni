namespace Data.Model.PizzaShop {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pizza")]
    public partial class Pizza {
        [StringLength(36)]
        public string Id { get; set; }

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
        public decimal? TotalPrice { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }

        [JsonIgnore]
        public virtual Product Border { get; set; }

        [JsonIgnore]
        public virtual Product FirstTopping { get; set; }

        [JsonIgnore]
        public virtual Product SecondTopping { get; set; }
    }
}