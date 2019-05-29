using Domain.Model.PizzaShop;
using Domain.Service;
using Presentation.Components.Windows;
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

namespace Presentation.Pages {
    /// <summary>
    /// Interaction logic for OrderSearch.xaml
    /// </summary>
    public partial class OrderSearch : Page {
        OrderService service { get; set; }
        public OrderSearch() {
            service = new OrderService();
            InitializeComponent();
            LoadAvaiableFieldValues();
        }

        private void LoadAvaiableFieldValues() {
            ComboOrderStatus.ItemsSource = new List<string> {
                "Em andamento",
                "Pronto",
                "Entregue"
            };
            ComboPaymentStatus.ItemsSource = new List<string> {
                "Pagamento pendente",
                "Pago"
            };
        }

        private void RefreshOrderGrid(object sender, SelectionChangedEventArgs e) {
            List<Order> orders = new List<Order>();
            if(NotEmpty(ComboOrderStatus)) {
                orders = service.FindOrdersByStatus(ToEnglish(ComboOrderStatus.Text)).ToList();
            }
            if(NotEmpty((sender as ComboBox))) {
                orders = orders.Where(order =>
                    order.PaymentStatus == ToEnglish((sender as ComboBox).SelectedItem as string)
                ).ToList();
            }
            OrderListView.ItemsSource = orders;
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

        private bool NotEmpty(ComboBox combo) {
            return combo.SelectedIndex != -1;
        }

        private bool NotEmpty(DatePicker picker) {
            return picker.SelectedDate != null;
        }

        private void ComboOrderStatus_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            List<Order> orders = new List<Order>();
            if(NotEmpty((sender as ComboBox))) {
                orders = service.FindOrdersByStatus(ToEnglish((sender as ComboBox).SelectedItem as string)).ToList();
            }
            if(NotEmpty(ComboPaymentStatus)) {
                orders = orders.Where(order =>
                    order.PaymentStatus == ToEnglish(ComboPaymentStatus.Text)
                ).ToList();
            }
            OrderListView.ItemsSource = orders;
        }

        private void ShowOrderButton_Click(object sender, RoutedEventArgs e) {
            new OrderView((Order)OrderListView.SelectedItem).ShowDialog();
        }
    }
}
