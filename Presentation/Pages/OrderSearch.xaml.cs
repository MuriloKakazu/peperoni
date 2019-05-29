using Domain.Model.PizzaShop;
using Domain.Service;
using Infrastructure.Builder;
using Infrastructure.Data;
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
        String selectedStatus { get; set; }
        String selectedPaymentStatus { get; set; }
        DateTime selectedCreatedDate { get; set; }
        public OrderSearch() {
            service = new OrderService();
            InitializeComponent();
            LoadAvaiableFieldValues();
        }

        private void LoadAvaiableFieldValues() {
            ComboOrderStatus.ItemsSource = new List<string> {
                "",
                "Em andamento",
                "Pronto",
                "Entregue"
            };
            ComboPaymentStatus.ItemsSource = new List<string> {
                "",
                "Pagamento pendente",
                "Pago"
            };
        }

        private void RefreshOrderGrid() {
            List<Order> orders = new List<Order>();
            List<Filter> filters = new List<Filter>(); 

            if(NotEmpty(ComboOrderStatus)) {
                filters.Add(
                    new FilterBuilder().WithKey("Status")
                                       .WithValue(ToEnglish(selectedStatus))
                                       .Build()
                );
            }
            if(NotEmpty(ComboPaymentStatus)) {
                filters.Add(
                    new FilterBuilder().WithKey("PaymentStatus")
                                       .WithValue(ToEnglish(selectedPaymentStatus))
                                       .Build()
                );
            }
            if((NotEmpty(CreatedDatePicker))) {
                filters.Add(
                    new FilterBuilder().WithKey("PlaceDate")
                                       .WithValue(CreatedDatePicker.SelectedDate)
                                       .Build()
                );
            }
            OrderListView.ItemsSource = service.FindByFilters(filters);
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
            return combo.SelectedIndex > 0;
        }

        private bool NotEmpty(DatePicker picker) {
            return picker.SelectedDate != null;
        }

        private void ComboOrderStatus_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            selectedStatus = (sender as ComboBox).SelectedItem as string;
            RefreshOrderGrid();
        }

        private void ShowOrderButton_Click(object sender, RoutedEventArgs e) {
            new OrderView((Order)OrderListView.SelectedItem).ShowDialog();
            RefreshOrderGrid();
        }

        private void ComboPaymentStatus_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            selectedPaymentStatus = (sender as ComboBox).SelectedItem as string;
            RefreshOrderGrid();
        }

        private void CreatedDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            if(CreatedDatePicker.SelectedDate != null) {
                selectedCreatedDate = (DateTime)(CreatedDatePicker.SelectedDate);
            }
            
            RefreshOrderGrid();
        }
    }
}
