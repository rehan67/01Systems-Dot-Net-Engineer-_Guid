# 01Systems-Dot Net Engineer Test


Application build in .NET 6

CustomGUID Class

The CustomGUID class provides a method to generate a globally unique identifier (GUID) without using the built-in GUID classes or methods in C#. This can be useful in scenarios where you need a custom implementation for generating unique identifiers.

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


    Explanation

    Class Definition:
        The class is defined as public static, meaning it cannot be instantiated and its members are accessible without creating an instance.

    GenerateGuid Method:
        This method generates a GUID and returns it as a string.

    Byte Array Initialization:
        byte[] randomBytes = new byte[16]; initializes a byte array of 16 bytes (128 bits), which is the standard size for a GUID.

    Random Number Generation:
        using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create()) creates an instance of RandomNumberGenerator.
        randomNumberGenerator.GetBytes(randomBytes); fills the byte array with cryptographically strong random values.

    Hexadecimal Conversion:
        StringBuilder hex = new StringBuilder(32); initializes a StringBuilder with a capacity of 32 characters.
        The foreach loop converts each byte in the array to a two-character hexadecimal string and appends it to the StringBuilder.

    GUID Formatting:
        The final GUID string is formatted in the standard 8-4-4-4-12 format using string interpolation:

        return $"{hex.ToString(0, 8)}" +
               $"-{hex.ToString(8, 4)}-" +
               $"{hex.ToString(12, 4)}-" +
               $"{hex.ToString(16, 4)}-" +
               $"{hex.ToString(20, 12)}";

        This ensures the GUID is in the format xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.

Usage

To generate a GUID using this class, simply call the GenerateGuid method:

string newGuid = CustomGUID.GenerateGuid();
Console.WriteLine(newGuid);

This will output a new, unique GUID each time it is called.

Feel free to adjust the explanation to better fit your project’s style and requirements!
