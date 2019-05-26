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
using Domain.Repository;
using Domain.Model.PizzaShop;

namespace Presentation.Pages {
    /// <summary>
    /// Interaction logic for AccountCreation.xaml
    /// </summary>
    public partial class AccountSelection : Page {
        public AccountSelection() {
            InitializeComponent();
            generateOrder.IsEnabled = false;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e) {
            if(accountNameInput.Text.Length >= 3) {
                accountListView.ItemsSource = new AccountRepository().FindAccountsByName(accountNameInput.Text);
            }
        }

        private void accountListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            generateOrder.IsEnabled = accountListView.SelectedIndex != -1;
        }

        private void generateOrder_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new OrderCreation((Account)accountListView.SelectedItem));
        }
    }
}
