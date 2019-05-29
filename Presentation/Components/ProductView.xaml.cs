using Domain.Builder;
using Domain.Model.PizzaShop;
using Infrastructure.Exceptions;
using Presentation.Controllers;
using Presentation.Mapper;
using Presentation.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation.Components {
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl {
        protected ProductExplorerController Controller { get; set; }
        protected Product Product { get; set; }
        protected ProductBuilder Builder { get; set; }

        public ProductView() {
            Controller = new ProductExplorerController();
            Product = new Product();
            Builder = new ProductBuilder(Product);
            InitializeComponent();
        }

        public ProductView(Product product) : this() {
            Product = product;
            Builder = new ProductBuilder(product);
        }

        private void ReloadView() {
            DataGrid.ItemsSource = Controller.FetchPage(0);
            Family.ItemsSource = FamilyMapper.GetPortugueseValues();
        }

        private void Component_Loaded(object sender, RoutedEventArgs e) {
            ReloadView();
        }

        private void LoadProduct(Product product) {
            Builder = new ProductBuilder(product);
            Product = product;
            Name.Text = product.Name ?? "";
            Family.Text = FamilyMapper.ToPortuguese(product.Family);
            Price.Text = product.ListPrice.ToString("C", CultureInfo.CurrentCulture);
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e) {
            Builder.WithName(Name.Text);
        }

        private void Family_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (Family.SelectedItem != null) {
                Builder.WithFamily(FamilyMapper.ToEnglish(Family.SelectedItem.ToString()));
            }
        }

        private void Price_TextChanged(object sender, TextChangedEventArgs eventArgs) {
            try {
                Builder.WithListPrice(InputValidator.EnsureDecimal(Price.Text));
            } catch (ValidationException e) {
                ShowError(e.Message);
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (DataGrid.SelectedItem is Product && (DataGrid.SelectedItem as Product).HasId()) {
                LoadProduct(DataGrid.SelectedItem as Product);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs eventArgs) {
            try {
                var product = Builder.Build();
                Controller.Save(product);
                ShowMessage($"Produto salvo com sucesso!");
                ReloadView();
            } catch (ValidationException e) {
                ShowError($"Erro de validação de produto: {e.Message}");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs eventArgs) {
            if (Product.HasId()) {
                try {
                    Controller.Delete(Product);
                    LoadProduct(new Product());
                    ShowMessage("Produto removido com sucesso!");
                    ReloadView();
                } catch (Exception e) {
                    ShowError($"Erro inesperado do serviço de produtos: {e.Message}");
                }
            }
        }

        private void ShowMessage(string message) {
            MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void ShowError(string message) {
            MessageBox.Show(message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ShowWarning(string message) {
            MessageBox.Show(message, "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
