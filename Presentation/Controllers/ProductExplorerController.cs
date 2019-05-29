using Domain.Model.PizzaShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers {
    public class ProductExplorerController : ProductController{
        protected const int PAGE_SIZE = 100;

        public ProductExplorerController() :
            base() {
        }

        public ICollection<Product> FetchPage(int page) {
            return Service.FetchProducts(PAGE_SIZE, page * PAGE_SIZE);
        }
    }
}
