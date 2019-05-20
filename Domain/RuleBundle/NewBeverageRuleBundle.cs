using Data.Model.PizzaShop;
using Domain.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RuleBundle {
    public class NewBeverageRuleBundle : RuleBundle<Pizza> {
        private List<Beverage> Beverages { get; set; }

        private NewBeverageRuleBundle() {
            Beverages = new List<Beverage>();
        }

        public NewBeverageRuleBundle(ICollection<Beverage> beverages) : this() {
            Beverages.AddRange(beverages);
        }

        public NewBeverageRuleBundle(Beverage beverage) : this() {
            Beverages.Add(beverage);
        }

        public RuleBundle<Pizza> Apply() {


            return this;
        }
    }
}
