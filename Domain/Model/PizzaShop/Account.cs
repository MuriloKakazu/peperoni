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
        public Account() {
            Orders = new List<Order>();
        }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(9)]
        public string Phone { get; set; }

        [Required]
        [StringLength(8)]
        public string PostalCode { get; set; }

        public int StreetNumber { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
    }
}