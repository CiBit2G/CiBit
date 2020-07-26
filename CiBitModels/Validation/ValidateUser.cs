using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace CiBitUtil.Validation
{
    public class ValidateUser
    {
        private byte[] salt;
        private static Random random = new Random();

        public string Hash(string toHash)
        {
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(toHash, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }

        public bool Verify(string savedHash, string key )
        {
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(key, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false; // OR -> throw new UnauthorizedAccessException();
            return true;
        }

        public string CreateCibitId()
        {
            var Regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9_-]{5,19}$");
            string first, last, id;

            do
            {
                first = RandomStringNoNumbers();
                last = RandomString((int)((random.NextDouble() * 15) + 6));
                id =  first + last;
            } while (!Regex.Match(id).Success);

            return id;
        }

        private static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private static string RandomStringNoNumbers()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 1)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string CreateCoinId(string cibitId)
        {
            return Hash(cibitId);
        }

        public bool VerifyCoinId(string coinId, string cibitId)
        {
            return Verify(coinId, cibitId);
        }
    }
}
