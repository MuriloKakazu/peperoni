using Domain.Model.PizzaShop;
using Domain.Repository;
using Domain.Rule.Validator;
using System.Collections.Generic;

namespace Domain.Service {
    public class PizzaService {
        public static PizzaService Instance { get; set; }
        private static PizzaRepository Repository { get; set; }

        static PizzaService() {
            Instance = new PizzaService();
            Repository = new PizzaRepository();
        }

        public Pizza GetPizza(string guid) {
            return Repository.Get(guid);
        }

        public ICollection<Pizza> FetchPizzas(int pageSize, int offset) {
            return Repository.Fetch(pageSize, offset);
        }

        public ICollection<Pizza> FindPizzasByOrder(string orderId) {
            return Repository.FindPizzasByOrder(orderId);
        }

        public Pizza CreatePizza(Pizza pizza) {
            new PizzaValidator(pizza).Validate();
            return Repository.Save(pizza);
        }

        public Pizza UpdatePizza(Pizza pizza) {
            new PizzaValidator(pizza).Validate();
            return Repository.Save(pizza);
        }

        public void DeletePizza(Pizza pizza) {
            Repository.Delete(pizza);
        }
    }
}
