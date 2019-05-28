using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Presentation.Util {
    public static class MessageUtils {
        public static  void ShowMessage(string message) {
            MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.None);
        }

        public static void ShowError(string message) {
            MessageBox.Show(message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowWarning(string message) {
            MessageBox.Show(message, "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
