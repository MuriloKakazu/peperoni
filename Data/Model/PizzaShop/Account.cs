namespace Data.Model.PizzaShop {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Diagnostics.CodeAnalysis;

    [Table("Account")]
    public partial class Account {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account() {
            Orders = new HashSet<Order>();
        }

        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(9)]
        public string Phone { get; set; }

        public int StreetNumber { get; set; }

        [Required]
        [StringLength(8)]
        public string PostalCode { get; set; }

        [JsonIgnore]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}