namespace Domain.Model.PizzaShop {
    using Infrastructure.Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table("Account")]
    public partial class Account : AbstractEntity {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        [Required]
        [StringLength(8)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(256)]
        public string StreetName { get; set; }

        [Required]
        public int StreetNumber { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }

        public Account() {
            Orders = new List<Order>();
        }

        public override string ToString() {
            return $"{Name}";
        }
    }
}