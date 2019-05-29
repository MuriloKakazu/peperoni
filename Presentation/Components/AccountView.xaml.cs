using Domain.Builder;
using Domain.Model.Geolocation;
using Domain.Model.PizzaShop;
using Domain.Service;
using Infrastructure.Exceptions;
using Infrastructure.Rule;
using Infrastructure.Util;
using Presentation.Controllers;
using Presentation.Pages;
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
        Account Account { get; set; }
        AccountBuilder Builder { get; set; }

        public AccountView(Account account) : this() {
            Account = account;
            Builder = new AccountBuilder(Account);
            LoadAccount(account);
        }

        public AccountView() {
            Account = new Account();
            Builder = new AccountBuilder(Account);
            Controller = new AccountController();
            InitializeComponent();
        }

        private void SearchPostalCode_Click(object sender, RoutedEventArgs eventArgs) {
            SearchAddress(PostalCode.Text);
        }

        private void Save_Click(object sender, RoutedEventArgs eventArgs) {
            try {
                Controller.Save(Builder.Build());
                ShowMessage("Conta salva com sucesso!");
                NavigationService.GetNavigationService(this).Navigate(new AccountSelection());
            } catch (ValidationException e) {
                ShowWarning($"Erro de validação da conta: {e.Message}");
            } catch (Exception e) {
                ShowError($"Erro inesperado do Serviço de Conta: {e.Message}");
            }
        }

        private void LoadAccount(Account account) {
            SearchAddress(account.PostalCode);

            Name.Text = account.Name;
            Phone.Text = account.Phone;
            PostalCode.Text = account.PostalCode;
            StreetName.Text = account.StreetName;
            StreetNumber.Text = account.StreetNumber.ToString();
            ComplementaryInfo.Text = account.ComplementaryAddress;

            if (account.Orders.Count > 0) {
                OrdersPanel.Visibility = Visibility.Visible;
                OrdersList.ItemsSource = account.Orders;
            } else {
                OrdersPanel.Visibility = Visibility.Collapsed;
                OrdersList.ItemsSource = null;
            }
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

        private void ShowMessage(string message) {
            MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void ShowError(string message) {
            MessageBox.Show(message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ShowWarning(string message) {
            MessageBox.Show(message, "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e) {
            Builder.WithName(Name.Text);
        }

        private void Phone_TextChanged(object sender, TextChangedEventArgs e) {
            Builder.WithPhone(Phone.Text);
        }

        private void PostalCode_TextChanged(object sender, TextChangedEventArgs e) {
            Builder.WithPostalCode(PostalCode.Text);
        }

        private void StreetName_TextChanged(object sender, TextChangedEventArgs e) {
            Builder.WithStreetName(StreetName.Text);
        }

        private void StreetNumber_TextChanged(object sender, TextChangedEventArgs e) {
            new Validator<object>(this)
                .Ensure(InputValidator.IsNumeric(StreetNumber.Text), "O número da rua deve ser um número válido!")
                .Run();
            Builder.WithStreetNumber(int.Parse(StreetNumber.Text));
        }

        private void ComplementaryInfo_TextChanged(object sender, TextChangedEventArgs e) {
            Builder.WithComplementaryAddress(ComplementaryInfo.Text);
        }
    }
}
