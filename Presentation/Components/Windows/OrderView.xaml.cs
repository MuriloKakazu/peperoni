using Domain.Model.PizzaShop;
using Domain.Service;
using Presentation.Controllers;
using Presentation.Mapper;
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

namespace Presentation.Components.Windows {
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : Window { 
        Order order { get; set; }
        OrderController controller { get; set; }
        public OrderView(Order order) : this() {
            this.order = order;
            order.SetAccount(new AccountService().GetAccount(order.AccountId));
            InitializeComponent();
            LoadAvaiableFieldValues();

            if(OrderIsCancelled(order)) {
                DisableCombosAndButtons();
            }
            PizzaListView.ItemsSource = order.GetPizzas();
            BeverageListView.ItemsSource = order.GetBeverages();
            TotalPriceLabel.Content = order.GetTotalPrice();
            OrderStatusCombo.SelectedItem = OrderStatusMapper.ToPortuguese(order.Status);
            PaymentStatusCombo.SelectedItem = PaymentStatusMapper.ToPortuguese(order.PaymentStatus);
        }

        public OrderView() {
            controller = new OrderController();
        }

        private void LoadAvaiableFieldValues() {
            OrderStatusCombo.ItemsSource = new List<string> {
                "Em andamento",
                "Pronto",
                "Entregue"
            };
            PaymentStatusCombo.ItemsSource = new List<string> {
                "Pagamento pendente",
                "Pago"
            };
        }

        private bool OrderIsCancelled(Order order) {
            return order.Status == "Cancelado";
        }

        private void DisableCombosAndButtons() {
            OrderStatusCombo.IsEnabled = false;
            PaymentStatusCombo.IsEnabled = false;
            SaveButton.IsEnabled = false;
        }

        private void Save(object sender, RoutedEventArgs e) {
            if(OrderStatusChangedTo("Delivered")) {
                order.DeliveryDate = DateTime.Now;
            }
            order.Status = OrderStatusMapper.ToEnglish(OrderStatusCombo.Text);
            order.PaymentStatus = PaymentStatusMapper.ToEnglish(PaymentStatusCombo.Text);

            this.controller.Update(order);
            this.Close();
        }

        private bool OrderStatusChangedTo(string targetStatus) {
            string newStatus = OrderStatusMapper.ToEnglish(OrderStatusCombo.Text);
            return order.Status != newStatus   &&
                   newStatus    == targetStatus;
        }
    }
}
