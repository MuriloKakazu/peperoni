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

namespace Presentation.Pages {
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Page {
        public About() {
            InitializeComponent();
            LoadAssets();
        }

        void LoadAssets() {
            AboutAppImage.Source = FindImage.ByName("about-app");
            AboutMuyukaImage.Source = FindImage.ByName("about-muyuka");
            AboutMupapiImage.Source = FindImage.ByName("about-mupapi");
        }
    }
}
