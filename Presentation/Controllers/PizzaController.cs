using Domain.Model.PizzaShop;
using Domain.Service;
using Infrastructure.Data;
using System.Collections.Generic;

namespace Presentation.Controllers {
    public class PizzaController {
        protected PizzaService PizzaService { get; set; }
        protected ProductService ProductService { get; set; }

        public PizzaController() {
            PizzaService = new PizzaService();
            ProductService = new ProductService();
        }

        public ICollection<Product> GetAvailableBorders() {
            return ProductService.FindAvailableBorders();
        }

        public ICollection<Product> GetAvailableToppings() {
            return ProductService.FindAvailableToppings();
        }

        public Pizza Retrieve(string guid) {
            return PizzaService.GetPizza(guid);
        }

        public ICollection<Pizza> Filter(ICollection<Filter> filters) {
            return PizzaService.FindByFilters(filters);
        }

        public Pizza Create(Pizza pizza) {
            return PizzaService.CreatePizza(pizza);
        }

        public Pizza Update(Pizza pizza) {
            return PizzaService.UpdatePizza(pizza);
        }

        public void Delete(Pizza pizza) {
            PizzaService.DeletePizza(pizza);
        }
    }
}
