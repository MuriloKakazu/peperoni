using Data.Context;
using Data.Encryption;
using Data.Repository;
using Domain.Service;
using Newtonsoft.Json;
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

namespace Presentation {
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Window {
        public Client() {
            InitializeComponent();

            using (var context = new PizzaShopContext()) {
                var accounts = context.Accounts.Where(a => a.Name != null).ToList();
            }
        }
    }
}
