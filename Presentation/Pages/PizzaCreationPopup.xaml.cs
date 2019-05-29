using Domain.Builder;
using Domain.Model.PizzaShop;
using Infrastructure.Exceptions;
using Infrastructure.Rule;
using Presentation.Controllers;
using Presentation.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        OrderBuilder orderBuilder { get; set; }
        PizzaController controller { get; set; }
        PizzaBuilder builder { get; set; }
        ObservableCollection<Pizza> pizzas { get; set; }
        public PizzaCreationPopup(OrderBuilder order) : this() {
            this.orderBuilder = order;
            InitializeComponent();

            PizzaListView.ItemsSource = pizzas;
            txtQuantity.Text = "1";
            cbFirstTopping.ItemsSource = cbSecondTopping.ItemsSource = controller.GetAvailableToppings();
            cbBorder.ItemsSource = controller.GetAvailableBorders();
            cbBorder.DisplayMemberPath = cbFirstTopping.DisplayMemberPath = cbSecondTopping.DisplayMemberPath = "Name";
        }

        protected PizzaCreationPopup() {
            this.controller = new PizzaController();
            this.builder = new PizzaBuilder();
            this.pizzas = new ObservableCollection<Pizza>();
        }

        private void RefreshPizzaPrice() {
            Pizza pizza = builder.Build();
            if(String.IsNullOrEmpty(pizza.BorderId) || String.IsNullOrEmpty(pizza.FirstToppingId)) {
                PizzaPrice.Content = "-";
            } else {
                PizzaPrice.Content = $"{pizza.TotalPrice:C}";
            }
        }

        private void UpdateBorder(object sender, SelectionChangedEventArgs e) {
            builder.WithBorder((Product)cbBorder.SelectedItem);
            RefreshPizzaPrice();
        }

        private void UpdateSecondTopping(object sender, SelectionChangedEventArgs e) {
            builder.WithSecondTopping((Product)cbSecondTopping.SelectedItem);
            RefreshPizzaPrice();
        }

        private void updateFirstTopping(object sender, SelectionChangedEventArgs e) {
            builder.WithFirstTopping((Product)cbFirstTopping.SelectedItem);
            RefreshPizzaPrice();
        }

        private void UpdateQuantity(object sender, TextChangedEventArgs e) {
            if(!String.IsNullOrEmpty(txtQuantity.Text)) {
                try {
                    new Validator<object>(this)
                        .Ensure(InputValidator.IsOverZero(txtQuantity.Text), "A quantidade deve ser um número válido maior que zero!")
                        .Run();

                    builder.WithQuantity(Int32.Parse(txtQuantity.Text));
                    RefreshPizzaPrice();
                } catch(ValidationException exc) {
                    MessageUtils.ShowError(exc.Message);
                    txtQuantity.Text = "1";
                }
            }
        }

        private void validateQuantity(object sender, RoutedEventArgs e) {
            try {
                new Validator<object>(this)
                    .Ensure(InputValidator.IsOverZero(txtQuantity.Text), "A quantidade deve ser um número válido maoior que zero!")
                    .Run();
            } catch(ValidationException exc) {
                MessageUtils.ShowError(exc.Message);
                txtQuantity.Text = "1";
                builder.WithQuantity(Int32.Parse(txtQuantity.Text));
                RefreshPizzaPrice();
            }
        }

        private void AddPizza(object sender, RoutedEventArgs e) {
            Pizza pizza = builder.Build();
            if(AlreadyAddedSimilar(pizza)) {
                MessageUtils.ShowError($"A pizza {pizza} já foi adicionada ao pedido");
            } else {
                if(pizza.SecondToppingId == null) {
                    builder.WithSecondTopping(pizza.FirstTopping);
                }
                pizzas.Add(pizza);
                builder = new PizzaBuilder().WithQuantity(Int32.Parse(txtQuantity.Text));
                ResetForm();
            }
        }

        private bool AlreadyAddedSimilar(Pizza addedPizza) {
            return pizzas.ToList().Any(p => 
                p.IsSimilarTo(addedPizza)
            );
        }

        private void ResetForm() {
            ClearInputs();
        }

        private void ClearInputs() {
            cbBorder.SelectedIndex = -1;
            cbFirstTopping.SelectedIndex = -1;
            cbSecondTopping.SelectedIndex = -1;
            txtQuantity.Text = "1";
        }

        private void CommitAndClose(object sender, RoutedEventArgs e) {
            orderBuilder.WithPizzas(pizzas);
            this.Close();
        }

        private void Close(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
