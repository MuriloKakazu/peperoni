using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace Presentation.Util {
    public static class FindImage {
        public static BitmapImage ByName(string filename) {
            var path = $@"{AppDomain.CurrentDomain.BaseDirectory}assets\images\{filename}.png";

            return IsValid(path)
                ? new BitmapImage(new Uri(path))
                : default(BitmapImage);
        }

        private static bool IsValid(string path) {
            return File.Exists(path);
        }
    }
}
