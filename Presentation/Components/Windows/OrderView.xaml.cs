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

namespace Presentation.Components.Windows {
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : Window { 
        Order order { get; set; }
        OrderController controller { get; set; }
        public OrderView(Order order) : this() {
            this.order = order;

            InitializeComponent();

            if(OrderIsCancelled(order)) {
                DisableCombosAndButtons();
            }
            PizzaListView.ItemsSource = order.GetPizzas();
            BeverageListView.ItemsSource = order.GetBeverages();
            TotalPriceLabel.Content = order.GetTotalPrice();
        }

        public OrderView() {
            controller = new OrderController();
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
            order.Status = ToEnglish(OrderStatusCombo.Text);
            order.PaymentStatus = ToEnglish(PaymentStatusCombo.Text);

            this.controller.Update(order);
        }

        private bool OrderStatusChangedTo(string targetStatus) {
            string newStatus = ToEnglish(OrderStatusCombo.Text);
            return order.Status != newStatus   &&
                   newStatus    == targetStatus;
        }

        private string ToEnglish(string text) {
            return new Dictionary<string, string> {
                {"Em andamento", "Ongoing"},
                {"Pronto", "Ready" },
                {"Entregue", "Delivered" },
                {"Cancelado", "Cancelled" },
                {"Pago", "Paid" },
                {"Pagamento pendente", "Unpaid" }
            }[text];
        }
    }
}
