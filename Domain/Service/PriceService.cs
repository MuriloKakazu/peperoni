using Domain.Model.PizzaShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service {
    public class PriceService {
        public static PriceService Instance { get; set; }

        static PriceService() {
            Instance = new PriceService();
        }

        public decimal GetTotalPrice(Pizza pizza) {
            return pizza.Quantity * pizza.UnitPrice;
        }

        public decimal GetTotalPrice(Beverage beverage) {
            return beverage.Quantity * beverage.UnitPrice;
        }

        public decimal GetTotalPrice(Order order) {
            return
                order.Pizzas.Sum(p => p.TotalPrice) + 
                order.Beverages.Sum(b => b.TotalPrice);
        }

        public decimal GetUnitPrice(Pizza pizza) {
            var borderPrice = pizza.Border.ListPrice;
            var toppingPrice = new[] { pizza.FirstTopping, pizza.SecondTopping }.Max(t => t.ListPrice);

            return borderPrice + toppingPrice;
        }

        public decimal GetUnitPrice(Beverage beverage) {
            return beverage.Product.ListPrice;
        }
    }
}
