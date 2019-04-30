namespace Model {
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

        public virtual Product Border { get; set; }

        public virtual Product FirstTopping { get; set; }

        public virtual Product SecondTopping { get; set; }
    }
}