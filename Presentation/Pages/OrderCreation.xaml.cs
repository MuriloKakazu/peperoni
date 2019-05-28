﻿using Domain.Builder;
using Domain.Model.PizzaShop;
using Presentation.Components.Windows;
using Presentation.Controllers;
using Presentation.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        OrderController controller { get; set; }
        ObservableCollection<Pizza> pizzas { get; set; }
        ObservableCollection<Beverage> beverages { get; set; }
        public OrderCreation(Account account) : this()
        {
            this.account = account;
            builder.WithAccount(account);
            InitializeComponent();
            AccountName.Content = account.Name;
            PizzaListView.ItemsSource = pizzas;
        }

        protected OrderCreation() {
            this.controller = new OrderController();
            this.builder = new OrderBuilder();
            this.pizzas = new ObservableCollection<Pizza>();
        }
        
        private void ShowPizzaCreationPopup(object sender, RoutedEventArgs e) {
            new PizzaCreationPopup(builder).ShowDialog();
            RefreshPizzaGrid();
        }

        private void RefreshPizzaGrid() {
            pizzas = new ObservableCollection<Pizza>();
            PizzaListView.ItemsSource = pizzas;
            builder.Build().GetPizzas().ToList().ForEach(pizza => {
                pizzas.Add(pizza);
            });
            RefreshTotalPrice();
        }

        private void ShowBeverageCreationPopup(object sender, RoutedEventArgs e) {
            new BeverageCreationPopup(builder).ShowDialog();
            RefreshBeveragesGrid();
            RefreshTotalPrice();
        }
        private void RefreshBeveragesGrid() {
            beverages = new ObservableCollection<Beverage>();
            BeveragesListView.ItemsSource = beverages;
            builder.Build().GetBeverages().ToList().ForEach(beverage => {
                beverages.Add(beverage);
            });
        }

        private void RefreshTotalPrice() {
            OrderTotalPrice.Content = $"{builder.Build().TotalPrice:C}";
        }

        private void FinishOrder(object sender, RoutedEventArgs e) {
            Order order = builder.Build();
            controller.Create(order);
            MessageUtils.ShowMessage("Pedido criado com sucesso!");
            NavigationService.Navigate(new Overview());
        }
    }
}
