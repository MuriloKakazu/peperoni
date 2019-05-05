namespace Data.Model.PizzaShop {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Diagnostics.CodeAnalysis;

    [Table("Product")]
    public partial class Product {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product() {
            Beverages = new HashSet<Beverage>();
            AsBorder = new HashSet<Pizza>();
            AsFirstTopping = new HashSet<Pizza>();
            AsSecondTopping = new HashSet<Pizza>();
        }

        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(32)]
        public string Family { get; set; }

        [Column(TypeName = "money")]
        public decimal ListPrice { get; set; }

        [JsonIgnore]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Beverage> Beverages { get; set; }

        [JsonIgnore]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pizza> AsBorder { get; set; }

        [JsonIgnore]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pizza> AsFirstTopping { get; set; }

        [JsonIgnore]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pizza> AsSecondTopping { get; set; }
    }
}