using Presentation.Components;
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

namespace Presentation.Pages
{
    /// <summary>
    /// Interação lógica para Home.xam
    /// </summary>
    public partial class Home : Page
    {
        Dictionary<string, Page> menuEventDictionary = new Dictionary<string, Page> {
            { "OrderCreation", new AccountSelection() },
            { "OrderSearch", new OrderSearch() }

        };
        public Home() {
            InitializeComponent();
            ShowBanner();
            LoadAssets();
        }

        private void ShowBanner() {
            myFrame.NavigationService.Navigate(new Banner());
        }

        void LoadAssets() {
            ApplicationImage.Source = FindImage.ByName("home-app");
            SidebarHeader.Background = new ImageBrush(FindImage.ByName("sidebar-header-background"));
        }

        private void ToggleMenuSection(object sender, MouseButtonEventArgs e) {
            var section = (StackPanel) GetParent(sender);
            var childLabels = getChildLabels(section);

            foreach(var label in childLabels) {
                toggleVisibility(label);
            }
        }

        private object GetParent(object obj) => (obj as FrameworkElement).Parent;

        private List<Label> getChildLabels(StackPanel panel) {
            var childLabels = new List<Label>();

            foreach (var child in panel.Children) {
                if (child is Label) {
                    childLabels.Add(child as Label);
                }
            }

            return childLabels;
        }

        private void toggleVisibility(Label label) {
            label.Visibility = label.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }

        private void previousPage(object sender, RoutedEventArgs e) {
            if(myFrame.NavigationService.CanGoBack) {
                myFrame.NavigationService.GoBack();
            }
        }

        private void AboutSection_Clicked(object sender, MouseButtonEventArgs e) {
            myFrame.Content = new About();
        }

        private void NewAccount_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            myFrame.NavigationService.Navigate(new AccountView());
        }

        private void SearchAccount_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            myFrame.NavigationService.Navigate(new AccountSelection());
        }

        private void OrderCreation_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            myFrame.NavigationService.Navigate(new AccountSelection());
        }

        private void OrderSearch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            myFrame.NavigationService.Navigate(new OrderSearch());
        }

        private void ExploreProducts_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            myFrame.NavigationService.Navigate(new ProductView());
        }
    }
}
