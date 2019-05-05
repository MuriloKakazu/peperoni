using System;
using System.Security.Cryptography;
using System.Text;

namespace Data.Encryption {
    public static class Decrypt {
        public static Decryptor<string> Base64(string cipher) {
            return new Base64Decryptor(cipher);
        }

        public interface Decryptor<Output> {
            Output WithAes(Aes aes);
        }

        private class Base64Decryptor : Decryptor<string> {
            private static UnicodeEncoding Encoding = new UnicodeEncoding();
            private byte[] Cipher { get; set; }

            public Base64Decryptor(string cipher) {
                Cipher = Convert.FromBase64String(cipher);
            }

            public string WithAes(Aes aes) {
                ICryptoTransform transform = aes.CreateDecryptor();
                byte[] decrypted = transform.TransformFinalBlock(Cipher, 0, Cipher.Length);
                return Encoding.GetString(decrypted);
            }
        }
    }
}
