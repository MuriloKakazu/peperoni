using Domain.Builder;
using Domain.Model.PizzaShop;
using Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentation.Pages {
    /// <summary>
    /// Interaction logic for PizzaCreationPopup.xaml
    /// </summary>
    public partial class PizzaCreationPopup : Window {
        OrderBuilder order { get; set; }
        PizzaController controller { get; set; }
        PizzaBuilder builder { get; set; }
        public PizzaCreationPopup(OrderBuilder order) : this() {
            this.order = order;
            InitializeComponent();

            cbFirstTopping.ItemsSource = cbSecondTopping.ItemsSource = controller.GetAvailableToppings();
            cbBorder.ItemsSource = controller.GetAvailableBorders();
            cbBorder.DisplayMemberPath = cbFirstTopping.DisplayMemberPath = cbSecondTopping.DisplayMemberPath = "Name";
        }

        protected PizzaCreationPopup() {
            this.controller = new PizzaController();
            this.builder = new PizzaBuilder();
        }

        private void refreshPizzaPrice() {
            Pizza pizza = builder.Build();
            if(String.IsNullOrEmpty(pizza.BorderId) || String.IsNullOrEmpty(pizza.FirstToppingId)) {
                PizzaPrice.Content = "-";
            } else {
                PizzaPrice.Content = $"R$ {pizza.TotalPrice:C}";
            }
        }

        private void cbBorder_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            builder.WithBorder((Product)cbBorder.SelectedItem);
            refreshPizzaPrice();
        }

        private void cbSecondTopping_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            builder.WithSecondTopping((Product)cbSecondTopping.SelectedItem);
            refreshPizzaPrice();
        }

        private void cbFirstTopping_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            builder.WithFirstTopping((Product)cbFirstTopping.SelectedItem);
            refreshPizzaPrice();
        }
    }
}
