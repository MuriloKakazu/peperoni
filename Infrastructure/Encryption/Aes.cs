using System;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Encryption {
    [Serializable]
    public class Aes {
        private RijndaelManaged Rijndael = new RijndaelManaged();
        private static UnicodeEncoding Encoding = new UnicodeEncoding();

        public short ChunkSize { get; set; }
        public string Key { get; set; }
        public string IV { get; set; }

        private void SetupRijndael() {
            Rijndael.Mode = CipherMode.CBC;
            Rijndael.Padding = PaddingMode.PKCS7;
            Rijndael.KeySize = ChunkSize;
            Rijndael.BlockSize = ChunkSize;
            Rijndael.Key = Convert.FromBase64String(Key);
            Rijndael.IV = Convert.FromBase64String(IV);
        }

        public ICryptoTransform CreateEncryptor() {
            SetupRijndael();
            return Rijndael.CreateEncryptor();
        }

        public ICryptoTransform CreateDecryptor() {
            SetupRijndael();
            return Rijndael.CreateDecryptor();
        }
    }
}
