using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
    using System;
    using System.Security.Cryptography;

    public class PasswordHasherAndSalter
    {
        private const int SaltSize = 16; // Size of the salt in bytes
        private const int HashSize = 32; // Size of the hash in bytes
        private const int Iterations = 10000; // Number of iterations for the hashing algorithm

        /// <summary>
        /// Generates a cryptographic random salt.
        /// </summary>
        /// <returns>Byte array containing the generated salt.</returns>
        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        /// <summary>
        /// Hashes a password using PBKDF2 with a generated salt.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>A Base64 encoded string containing the salt and hash.</returns>
        public static string HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt = GenerateSalt();

            // Hash the password using PBKDF2
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);

                // Combine salt and hash
                byte[] hashBytes = new byte[SaltSize + HashSize];
                Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

                // Return Base64 encoded salt+hash
                return Convert.ToBase64String(hashBytes);
            }
        }

        /// <summary>
        /// Verifies a password against a stored hashed password.
        /// </summary>
        /// <param name="password">The password to verify.</param>
        /// <param name="hashedPassword">The stored hashed password (Base64 encoded).</param>
        /// <returns>True if the password matches, otherwise false.</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Decode the Base64 encoded string
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            // Extract the salt
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Hash the input password with the extracted salt
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);

                // Compare the stored hash with the newly generated hash
                for (int i = 0; i < HashSize; i++)
                {
                    if (hashBytes[i + SaltSize] != hash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

}
