using Domain.Model.PizzaShop;
using Domain.Repository;
using Domain.Rule.Validator;
using System.Collections.Generic;

namespace Domain.Service {
    public class ProductService {
        public static ProductService Instance { get; set; }
        private static ProductRepository Repository { get; set; }

        static ProductService() {
            Instance = new ProductService();
            Repository = new ProductRepository();
        }

        public Product GetProduct(string guid) {
            return Repository.Get(guid);
        }

        public ICollection<Product> FetchProducts(int pageSize, int offset) {
            return Repository.Fetch(pageSize, offset);
        }

        public ICollection<Product> FindProductsByFamily(string family) {
            return Repository.FindByFamily(family);
        }

        public ICollection<Product> FindAvailableBorders() {
            return FindProductsByFamily("Border");
        }

        public ICollection<Product> FindAvailableToppings() {
            return FindProductsByFamily("Topping");
        }

        public ICollection<Product> FindAvailableDrinks() {
            return FindProductsByFamily("Drink");
        }

        public Product CreateProduct(Product product) {
            new ProductValidator(product).Validate();
            return Repository.Save(product);
        }

        public Product UpdateProduct(Product product) {
            new ProductValidator(product).Validate();
            return Repository.Save(product);
        }

        public void DeleteProduct(Product product) {
            Repository.Delete(product);
        }
    }
}
