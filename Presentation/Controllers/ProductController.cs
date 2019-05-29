using Domain.Model.PizzaShop;
using Domain.Service;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers {
    public class ProductController {
        protected ProductService Service { get; set; }

        public ProductController() {
            Service = new ProductService();
        }

        public Product Retrieve(string guid) {
            return Service.GetProduct(guid);
        }

        public ICollection<Product> Filter(ICollection<Filter> filters) {
            return Service.FindByFilters(filters);
        }

        public Product Save(Product product) {
            return Service.SaveProduct(product);
        }

        public Product Create(Product product) {
            return Service.CreateProduct(product);
        }

        public Product Update(Product product) {
            return Service.UpdateProduct(product);
        }

        public void Delete(Product product) {
            Service.DeleteProduct(product);
        }
    }
}
