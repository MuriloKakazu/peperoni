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

namespace Presentation.Components.Windows {
    /// <summary>
    /// Interaction logic for BeverageCreationPopup.xaml
    /// </summary>
    /// OrderBuilder orderBuilder { get; set; }
    public partial class BeverageCreationPopup : Window {
        OrderBuilder orderBuilder { get; set; }
        BeverageController controller { get; set; }
        BeverageBuilder builder { get; set; }
        ObservableCollection<Beverage> beverages { get; set; }

        public BeverageCreationPopup(OrderBuilder orderBuilder) : this() {
            this.orderBuilder = orderBuilder;
            InitializeComponent();

            BeverageListView.ItemsSource = beverages;
            txtQuantity.Text = "1";
            cbProduct.ItemsSource = controller.GetAvailableDrinks();
            cbProduct.DisplayMemberPath = "Name";
        }

        public BeverageCreationPopup() {
            this.controller = new BeverageController();
            this.builder = new BeverageBuilder();
            this.beverages = new ObservableCollection<Beverage>();
        }

        private void RefreshBeveragePrice() {
            Beverage beverage = builder.Build();
            if(String.IsNullOrEmpty(beverage.ProductId) || beverage.Quantity == 0) {
                BeveragePrice.Content = "-";
            } else {
                BeveragePrice.Content = $"{beverage.TotalPrice:C}";
            }
        }

        private void UpdateProduct(object sender, SelectionChangedEventArgs e) {
            builder.WithProduct((Product)cbProduct.SelectedItem);
            RefreshBeveragePrice();
        }

        private void UpdateQuantity(object sender, TextChangedEventArgs e) {
            if(!String.IsNullOrEmpty(txtQuantity.Text)) {
                try {
                    new Validator<object>(this)
                        .Ensure(InputValidator.IsOverZero(txtQuantity.Text), "A quantidade deve ser um número válido maior que zero!")
                        .Run();

                    builder.WithQuantity(Int32.Parse(txtQuantity.Text));
                    RefreshBeveragePrice();
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
                RefreshBeveragePrice();
            }
        }

        private void AddBeverage(object sender, RoutedEventArgs e) {
            if(FieldsAreValid()) {
                Beverage beverage = builder.Build();
                if(AlreadyAddedSimilar(beverage)) {
                    MessageUtils.ShowError($"O acompanhamento {beverage} já foi adicionado ao pedido");
                } else {
                    beverages.Add(builder.Build());
                    builder = new BeverageBuilder().WithQuantity(Int32.Parse(txtQuantity.Text));
                    ResetForm();
                }
            }
        }

        private bool FieldsAreValid() {
            if(cbProduct.SelectedIndex == -1 || String.IsNullOrEmpty(txtQuantity.Text)) {
                MessageUtils.ShowWarning("Preencha todos os campos para adicionar um acompanhamento");
                return false;
            }
            return true;
        }

        private bool AlreadyAddedSimilar(Beverage addedBeverage) {
            return beverages.ToList().Any(p =>
                p.IsSimilarTo(addedBeverage)
            );
        }

        private void ResetForm() {
            ClearInputs();
        }

        private void ClearInputs() {
            cbProduct.SelectedIndex = -1;
            txtQuantity.Text = "1";
        }
        private void CommitAndClose(object sender, RoutedEventArgs e) {
            orderBuilder.WithBeverages(beverages);
            this.Close();
        }

        private void Close(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
