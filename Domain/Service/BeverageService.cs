using Domain.Model.PizzaShop;
using Domain.Repository;
using Domain.Rule.Validator;
using System.Collections.Generic;

namespace Domain.Service {
    public class BeverageService {
        public static BeverageService Instance { get; set; }
        private static BeverageRepository Repository { get; set; }

        static BeverageService() {
            Instance = new BeverageService();
            Repository = new BeverageRepository();
        }

        public Beverage GetBeverage(string guid) {
            return Repository.Get(guid);
        }

        public ICollection<Beverage> FetchBeverages(int pageSize, int offset) {
            return Repository.Fetch(pageSize, offset);
        }

        public ICollection<Beverage> FindBeveragesByOrder(string orderId) {
            return Repository.FindBeveragesByOrder(orderId);
        }

        public Beverage CreateBeverage(Beverage beverage) {
            new BeverageValidator(beverage).Validate();
            return Repository.Save(beverage);
        }

        public Beverage UpdateBeverage(Beverage beverage) {
            new BeverageValidator(beverage).Validate();
            return Repository.Save(beverage);
        }

        public void DeleteBeverage(Beverage beverage) {
            Repository.Delete(beverage);
        }
    }
}
