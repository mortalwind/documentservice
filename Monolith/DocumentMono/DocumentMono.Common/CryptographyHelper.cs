using System.Security.Cryptography;
using System.Text;

namespace DocumentMono.Common
{
    /*
     * Sample article is here / Örnek makale burada:
     * https://docs.microsoft.com/tr-tr/dotnet/api/system.security.cryptography.aes?view=net-6.0
     */

    /// <summary>
    /// Cryptograph helper for Crossplatform 
    /// <para>Crossplatforma uygun şifreleme algoritmaları</para>
    /// </summary>
    public static class CryptographyHelper
    {
        private static readonly string key = "d_7tYnm*1t";
        private static readonly byte[] IV = new byte[16];


        /// <summary>
        /// Gets chipper password
        /// <para>Şifrelenmiş parolayı getirir</para>
        /// </summary>
        /// <param name="password">Şifrelenecek parola</param>
        /// <returns></returns>
        public static string GetChipperPassword(string password)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            var chipperBytes = EncryptStringToBytes_Aes(password, keyBytes, IV);
            return Convert.ToBase64String(chipperBytes);
        }



        /// <summary>
        /// Encryption method with AES cryptograph algoritm
        /// <para>AES şifreleme algoritması ile şifreleme</para>
        /// </summary>
        /// <param name="plainText">Text to encryption / Şifrelenecek veri </param>
        /// <param name="Key">Key / Şifreleme anahtarı</param>
        /// <param name="IV">Vector / Şifreleme vektörü</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("Şifrelenecek veri yok");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Şifreleme anahtarı yok");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Şifreleme vektörü yok");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        /// <summary>
        /// Decription method with AES cryptograph algoritm
        /// <para>AES şifreleme algoritması ile şifre çözme</para>
        /// </summary>
        /// <param name="cipherText">Encrypted text to decription / Çözülecek Şifreli içerik </param>
        /// <param name="Key">Key / Şifreleme anahtarı</param>
        /// <param name="IV">Vector / Şifreleme vektörü</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("Şifreli içerik yok.");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Şifreleme anahtarı yok");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Şifreleme vektörü yok");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}

