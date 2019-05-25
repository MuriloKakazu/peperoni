using Domain.Model.PizzaShop;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers {
    public class PizzaController {
        protected PizzaRepository PizzaRepository { get; set; }
        protected ProductRepository ProductRepository { get; set; }

        public PizzaController() {
            PizzaRepository = new PizzaRepository();
            ProductRepository = new ProductRepository();
        }

        public ICollection<Product> GetAvailableBorders() {
            return ProductRepository.FindByFamily("Border");
        }

        public ICollection<Product> GetAvailableToppings() {
            return ProductRepository.FindByFamily("Topping");
        }

        public Pizza GetPizza(string guid) {
            return PizzaRepository.Get(guid);
        }

        public Pizza SavePizza(Pizza pizza) {
            return PizzaRepository.Save(pizza);
        }

        public void DeletePizza(Pizza pizza) {
            PizzaRepository.Delete(pizza);
        }
    }
}
