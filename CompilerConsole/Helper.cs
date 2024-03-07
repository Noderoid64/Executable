using System;
using System.Globalization;

namespace CompilerConsole
{
    public static class Helper
    {
        public static byte[] ConvertHexStringTo4ByteArray(string hex)
        {
            if (hex == null)
                throw new ArgumentNullException(nameof(hex));
            if (hex.StartsWith("0x"))
                hex = hex.Substring(2); // Remove the '0x' prefix if it exists
            if (hex.Length != 8)
                throw new ArgumentException("The hexadecimal string must be exactly 8 characters long (excluding '0x').", nameof(hex));

            byte[] bytes = new byte[4]; // Create a byte array to hold the converted value

            for (int i = 0; i < bytes.Length; i++)
            {
                // Convert each two-character group to a byte and add to array
                string byteValue = hex.Substring(i * 2, 2);
                bytes[i] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return bytes;
        }
        
        public static byte[] ConvertHexStringTo2ByteArray(string hex)
        {
            if (hex == null)
                throw new ArgumentNullException(nameof(hex));
            if (hex.StartsWith("0x"))
                hex = hex.Substring(2); // Remove the '0x' prefix if it exists
            if (hex.Length != 4)
                throw new ArgumentException("The hexadecimal string must be exactly 8 characters long (excluding '0x').", nameof(hex));

            byte[] bytes = new byte[2]; // Create a byte array to hold the converted value

            for (int i = 0; i < bytes.Length; i++)
            {
                // Convert each two-character group to a byte and add to array
                string byteValue = hex.Substring(i * 2, 2);
                bytes[i] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return bytes;
        }
    }
}