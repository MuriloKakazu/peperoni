using Domain.Model.Geolocation;
using Domain.Model.PizzaShop;
using Domain.Service;
using Infrastructure.Exceptions;
using Infrastructure.Rule;
using Infrastructure.Util;
using Presentation.Controllers;
using Presentation.Util;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation.Components {
    /// <summary>
    /// Interaction logic for AccountView.xaml
    /// </summary>
    public partial class AccountView : UserControl {
        static AccountController Controller { get; set; }

        public AccountView(Account account) : this() {
            LoadAccount(account);
        }

        public AccountView() {
            Controller = new AccountController();
            InitializeComponent();
        }

        private void SearchPostalCode_Click(object sender, RoutedEventArgs eventArgs) {
            SearchAddress(PostalCode.Text);
        }

        private void Save_Click(object sender, RoutedEventArgs eventArgs) {
            try {
                ValidateInputs();
                Controller.Save(MountAccount());
                ShowMessage("Conta salva com sucesso!");
                NavigationService.GetNavigationService(this).GoBack();
            } catch (ValidationException e) {
                ShowWarning($"Erro de validação da conta: {e.Message}");
            } catch (Exception e) {
                ShowError($"Erro inesperado do Serviço de Conta: {e.Message}");
            }
        }

        private Account MountAccount() {
            return new Account() {
                Name = Name.Text,
                Phone = Phone.Text,
                PostalCode = PostalCode.Text,
                StreetName = StreetName.Text,
                StreetNumber = Convert.ToInt32(StreetNumber.Text)
            };
        }

        private void LoadAccount(Account account) {
            SearchAddress(account.PostalCode);

            Name.Text = account.Name;
            Phone.Text = account.Phone;
            PostalCode.Text = account.PostalCode;
            StreetName.Text = account.StreetName;
            StreetNumber.Text = account.StreetNumber.ToString();
        }

        private void SearchAddress(string postalCode) {
            try {
                var address = Controller.SearchAddress(postalCode);
                SetAddress(address);
            } catch (Exception e) {
                ShowError($"Erro inesperado do Serviço de Endereço: {e.Message}");
            }
        }

        private void SetAddress(Address address) {
            Country.Content = address.Country;
            State.Content = address.FederativeUnit;
            City.Content = address.City;
            Neighborhood.Content = address.Neighborhood;
            StreetName.Text = address.Street;
        }

        private void ValidateInputs() {
            new Validator<object>(this)
                .Ensure(InputValidator.IsNumeric(StreetNumber.Text), "O número da rua deve ser um número válido!")
                .Run();
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
