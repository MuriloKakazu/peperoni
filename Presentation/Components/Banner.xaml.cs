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

namespace Presentation.Components {
    /// <summary>
    /// Interaction logic for Banner.xaml
    /// </summary>
    public partial class Banner : UserControl {
        public Banner() {
            InitializeComponent();
            LoadAssets();
        }

        private void LoadAssets() {
            BannerImage.Source = FindImage.ByName("banner");
        }
    }
}
