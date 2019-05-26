using Infrastructure.Encryption;
using Infrastructure.Repository;
using Domain.Service;
using Newtonsoft.Json;
using Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
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
using Infrastructure.Data;
using Domain.Builder;
using Domain.Model.PizzaShop;
using Domain.Repository;
using Domain.Rule.Validator;

namespace Presentation {
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Window {
        public Client() {
            InitializeComponent();

            /* Account controller example */
            var accountController = new AccountController();

            var account = accountController.GetAccount("1a4095c1-d9f2-4546-873e-3993d86371c6");
            Console.WriteLine($"Fetched account: {JsonConvert.SerializeObject(account, Formatting.Indented)}");

            account.Name = "Mr. Winter";
            account = accountController.SaveAccount(account);

            /* Order controller example */
            var orderController = new OrderExplorerController();

            var newOrder = new OrderBuilder()
                .WithAccount(account.Id)
                .WithStatus("Enqueued")
                .WithPaymentStatus("Unpaid")
                .PlacedOn(DateTime.Today)
                .DeliveredOn(null)
                .Build();

            orderController.SaveOrder(newOrder);

            var accountOrders = orderController.SearchOrdersByAccount(account);
            Console.WriteLine($"Fetched orders: {JsonConvert.SerializeObject(accountOrders, Formatting.Indented)}");

            var anOrder = accountOrders.First();
            anOrder.Status = "Enqueued";

            orderController.SaveOrder(anOrder);
            Console.WriteLine($"Saved order: {JsonConvert.SerializeObject(anOrder, Formatting.Indented)}");

            /* Account Explorer controller example */
            var accountExplorer = new AccountExplorerController();
            var foundAccounts = accountExplorer.SearchByName("Mr");
            Console.WriteLine($"Found accounts: {JsonConvert.SerializeObject(foundAccounts, Formatting.Indented)}");
        }
    }
}

