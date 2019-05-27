using Domain.Builder;
using Domain.Model.PizzaShop;
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

namespace Presentation.Pages
{
    /// <summary>
    /// Interação lógica para OrderCreation.xam
    /// </summary>
    public partial class OrderCreation : Page
    {
        Account account { get; set; }
        OrderBuilder builder { get; set; }
        public OrderCreation(Account account) : this()
        {
            this.account = account;
            builder.WithAccount(account);
            InitializeComponent();
            AccountName.Content = account.Name;
        }

        protected OrderCreation() {
            this.builder = new OrderBuilder();
        }

        private void showPizzaCreationPopup(object sender, RoutedEventArgs e) {
            new PizzaCreationPopup(builder).ShowDialog();
        }
    }
}
