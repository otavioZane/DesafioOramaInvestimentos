using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using OramaInvestimentos.Entities;
using OramaInvestimentos.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace OramaInvestimentos.Utils {
    public class Salt : ISalt {
        private readonly Keys _keys;

        public Salt(Keys keys) {
            _keys = keys;
        }

       
        public byte[] GetSalt() {
            var random = new RNGCryptoServiceProvider();
            int max_length = 32;
            byte[] salt = new byte[max_length];
            random.GetNonZeroBytes(salt);
            return Encryption(salt);
        }

        public byte[] GetHash(string value, byte[] salt) {
            var data = new {
                password = value,
                salt = Decryption(salt),
                prf = KeyDerivationPrf.HMACSHA256,
                iterationCount = 100000,
                numBytesRequested = 256 / 8
            };
            string hashed = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: value,
                    salt: Decryption(salt),
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8
                )
            );
            return Encryption(Encoding.ASCII.GetBytes(hashed));
        }

        public bool CheckHash(string password, byte[] hashedPassword, byte[] salt) {
            byte[] decryptedValue = Decryption(hashedPassword);
            byte[] saltedValue = Decryption(GetHash(password, salt));

            return decryptedValue.SequenceEqual(saltedValue);
        }

        private byte[] Decryption(byte[] data) {
            try {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider()) {
                    RSA.FromXmlString(_keys.RsaPrivate);
                    decryptedData = RSA.Decrypt(data, false);
                }
                return decryptedData;
            }
            catch (CryptographicException e) {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public byte[] Encryption(byte[] data) {
            try {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider()) {
                    RSA.FromXmlString(_keys.RsaPublic);
                    encryptedData = RSA.Encrypt(data, false);
                }
                return encryptedData;
            }
            catch (CryptographicException e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
