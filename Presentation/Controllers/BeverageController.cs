using Domain.Model.PizzaShop;
using Domain.Service;
using System.Collections.Generic;

namespace Presentation.Controllers {
    class BeverageController {
        protected BeverageService BeverageService { get; set; }
        protected ProductService ProductService { get; set; }

        public BeverageController() {
            BeverageService = new BeverageService();
            ProductService = new ProductService();
        }

        public ICollection<Product> GetAvailableDrinks() {
            return ProductService.FindAvailableDrinks();
        }

        public Beverage Retrieve(string guid) {
            return BeverageService.GetBeverage(guid);
        }

        public Beverage Create(Beverage beverage) {
            return BeverageService.CreateBeverage(beverage);
        }

        public Beverage Update(Beverage beverage) {
            return BeverageService.UpdateBeverage(beverage);
        }

        public void Delete(Beverage beverage) {
            BeverageService.DeleteBeverage(beverage);
        }
    }
}
