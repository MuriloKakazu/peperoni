namespace Domain.Model.PizzaShop {
    using Infrastructure.Data;
    using Infrastructure.Rule;
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table("Beverage")]
    public partial class Beverage : AbstractEntity {
        [Required]
        [StringLength(36)]
        public string OrderId { get; private set; }

        [Required]
        [StringLength(36)]
        public string ProductId { get; private set; }

        public int Quantity { get; set; }

        public decimal UnitPrice {
            get {
                return (Product?.ListPrice).Value;
            }
            set {
                UnitPrice = value;
            }
        }

        public decimal TotalPrice {
            get {
                return UnitPrice * Quantity;
            } set {
                TotalPrice = value;
            }
         }

        [JsonIgnore]
        public Order Order { get; private set; }

        [JsonIgnore]
        public Product Product { get; private set; }

        public Beverage() {
            Order = new Order();
            Product = new Product();
        }

        public Beverage SetOrder(Order order) {
            OrderId = order.Id;
            Order = order;
            return this;
        }

        public Beverage SetOrder(string orderId) {
            OrderId = orderId;
            Order = null;
            return this;
        }

        public Beverage SetProduct(Product product) {
            ProductId = product.Id;
            Product = product;
            return this;
        }

        public Beverage SetProduct(string productId) {
            ProductId = productId;
            Product = null;
            return this;
        }

        protected void ValidateProduct(Product product) {
            new Validator<Product>(product)
                .Ensure(product.Family == "Drink", "A bebida do pedido deve ser uma bebida válida")
                .Run();
        }

        public bool IsSimilarTo(Beverage beverage) {
            return
                this.ProductId == beverage.ProductId;
        }

        public override string ToString() {
            return Product != null
                ? Product.Name
                : "Bebida";
        }
    }
}