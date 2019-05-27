namespace Domain.Model.PizzaShop {
    using Infrastructure.Data;
    using Infrastructure.Rule;
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Serializable]
    [Table("Pizza")]
    public partial class Pizza : AbstractEntity {
        [Required]
        [StringLength(36)]
        public string OrderId { get; private set; }

        [Required]
        [StringLength(36)]
        public string FirstToppingId { get; private set; }

        [Required]
        [StringLength(36)]
        public string SecondToppingId { get; private set; }

        [Required]
        [StringLength(36)]
        public string BorderId { get; private set; }

        public int Quantity { get; set; }

        public decimal UnitPrice {
            get {
                return GetUnitPrice();
            }
            set {
                UnitPrice = value;
            }
        }

        public decimal TotalPrice {
            get {
                return UnitPrice * Quantity;
            }
            set {
                TotalPrice = value;
            }
        }

        [JsonIgnore]
        public Order Order { get; private set; }

        [JsonIgnore]
        public Product Border { get; private set; }

        [JsonIgnore]
        public Product FirstTopping { get; private set; }

        [JsonIgnore]
        public Product SecondTopping { get; private set; }

        public Pizza() {
            Order = new Order();
            FirstTopping = new Product();
            SecondTopping = new Product();
            Border = new Product();
        }

        public Pizza SetOrder(Order order) {
            OrderId = order.Id;
            Order = order;
            return this;
        }

        public Pizza SetOrder(string orderId) {
            OrderId = orderId;
            Order = null;
            return this;
        }

        public Pizza SetFirstTopping(Product topping) {
            ValidateTopping(topping);
            FirstToppingId = topping.Id;
            FirstTopping = topping;
            return this;
        }

        public Pizza SetSecondTopping(Product topping) {
            ValidateTopping(topping);
            SecondToppingId = topping.Id;
            SecondTopping = topping;
            return this;
        }

        public Pizza SetBorder(Product border) {
            ValidateBorder(border);
            BorderId = border.Id;
            Border = border;
            return this;
        }

        public Pizza SetFirstTopping(string firstToppingId) {
            FirstToppingId = firstToppingId;
            FirstTopping = null;
            return this;
        }

        public Pizza SetSecondTopping(string secondToppingId) {
            SecondToppingId = secondToppingId;
            SecondTopping = null;
            return this;
        }

        public Pizza SetBorder(string borderId) {
            BorderId = borderId;
            Border = null;
            return this;
        }

        protected decimal GetUnitPrice() {
            var borderPrice = GetBorderPrice();
            var toppingPrice = GetToppingPrice();

            return borderPrice + toppingPrice;
        }

        protected decimal GetBorderPrice() {
            return (Border?.ListPrice).Value;
        }

        protected decimal GetToppingPrice() {
            return new[] { FirstTopping, SecondTopping }.Max(t => (t?.ListPrice).Value);
        }

        protected void ValidateTopping(Product topping) {
            new Validator<Product>(topping)
                .Ensure(topping.Family == "Topping", "O sabor da pizza deve ser um sabor válido")
                .Run();
        }

        protected void ValidateBorder(Product border) {
            new Validator<Product>(border)
                .Ensure(border.Family == "Border", "A borda da pizza deve ser uma borda válida")
                .Run();
        }

        public bool IsSimilarTo(Pizza pizza) {
            return
                this.FirstToppingId == pizza.FirstToppingId &&
                this.SecondToppingId == pizza.SecondToppingId &&
                this.BorderId == pizza.BorderId;
        }

        public override string ToString() {
            return $"Sabor: {FormatTopping()} Borda: {FormatBorder()}";
        }

        private string FormatTopping() {
            if (FirstToppingId == SecondToppingId) {
                return $"{FirstTopping?.Name}";
            }
            return $"{FirstTopping?.Name}, {SecondTopping?.Name}";
        }

        private string FormatBorder() {
            return $"{Border?.Name}";
        }
    }
}