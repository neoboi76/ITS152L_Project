/**
 * Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * Secure Token Service class. Generates, validates, and verifies
 * generated tokens (for password resetting).
 **/

using System;
using System.Linq;
using System.Security.Cryptography;
using ItemDataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemDataLibrary.Security
{
    public static class SecureTokenService
    {
        private const int TokenLength = 6;
        private const int MaxGenerationAttempts = 10;

        public static string GenerateSecureToken()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] tokenData = new byte[4];
                rng.GetBytes(tokenData);
                int randomValue = Math.Abs(BitConverter.ToInt32(tokenData, 0));
                int token = (randomValue % 900000) + 100000;
                return token.ToString();
            }
        }

        public static string GenerateUniqueToken(DbContext context)
        {
            string token;
            int attempts = 0;

            do
            {
                token = GenerateSecureToken();
                attempts++;

                if (attempts >= MaxGenerationAttempts)
                {
                    throw new InvalidOperationException("Failed to generate unique token after maximum attempts.");
                }

                var exists = context.Set<PasswordResetToken>()
                    .Any(t => t.Token == token && !t.IsUsed && t.Expiry > DateTime.UtcNow);

                if (!exists)
                    break;

            } while (true);

            return token;
        }

        public static string GenerateEntropyToken()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                long timestamp = DateTime.UtcNow.Ticks;
                byte[] randomBytes = new byte[8];
                rng.GetBytes(randomBytes);
                byte[] combined = new byte[16];
                BitConverter.GetBytes(timestamp).CopyTo(combined, 0);
                randomBytes.CopyTo(combined, 8);
                using (var sha256 = SHA256.Create())
                {
                    byte[] hash = sha256.ComputeHash(combined);
                    long numericValue = Math.Abs(BitConverter.ToInt64(hash, 0));
                    int token = (int)((numericValue % 900000) + 100000);
                    return token.ToString();
                }
            }
        }

        public static bool IsValidTokenFormat(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return false;
            if (token.Length != TokenLength)
                return false;
            return token.All(char.IsDigit);
        }

        public static bool SecureTokenCompare(string token1, string token2)
        {
            if (token1 == null || token2 == null)
                return false;
            if (token1.Length != token2.Length)
                return false;
            int result = 0;
            for (int i = 0; i < token1.Length; i++)
                result |= token1[i] ^ token2[i];
            return result == 0;
        }
    }
}
