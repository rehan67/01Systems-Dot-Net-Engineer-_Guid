using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _01Systems_Dot_Net_Engineer_Test.GUID
{
    public static class CustomGUID
    {
        public static string GenerateGuid()
        {
            byte[] randomBytes = new byte[16]; // 16 bytes = 128 bits
            using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomBytes);
            }

            // Convert bytes to hexadecimal string
            StringBuilder hex = new StringBuilder(32);
            foreach (byte b in randomBytes)
            {
                // Convert each byte to 2 hex characters
                hex.Append(b.ToString("x2")); 
            }

            // Format the GUID in the standard 8-4-4-4-12 format
            return $"{hex.ToString(0, 8)}" +
                $"-{hex.ToString(8, 4)}-" +
                $"{hex.ToString(12, 4)}-" +
                $"{hex.ToString(16, 4)}-" +
                $"{hex.ToString(20, 12)}";
        }
    }
}
