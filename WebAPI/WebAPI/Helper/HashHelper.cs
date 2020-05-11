namespace WebAPI.Helper
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class SecureData
    {
        private byte[] bytes;

        public byte[] Bytes => bytes.ToArray();

        private int length;

        public int Length => length;

        public SecureData(string data)
        {
            bytes = Encoding.UTF8.GetBytes(data);
            length = data.Length;
        }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }

    /// <summary>
    /// HashHelper.
    /// </summary>
    public class HashHelper
    {
        public static SecureData GenerateSaltedHash(SecureData value, SecureData salt)
        {
            var valueArray = value.Bytes;
            var saltArray = salt.Bytes;

            HashAlgorithm algorithm = new SHA512Managed();

            var valueWithSaltBytes =
                new byte[value.Length + salt.Length];

            for (var i = 0; i < value.Length; i++)
            {
                valueWithSaltBytes[i] = valueArray[i];
            }

            for (var i = 0; i < salt.Length; i++)
            {
                valueWithSaltBytes[value.Length + i] = saltArray[i];
            }

            var hashValue = Convert.ToBase64String(algorithm.ComputeHash(valueWithSaltBytes));
            return new SecureData(hashValue);
        }

        public static SecureData GenerateSaltedHexHash(SecureData value, SecureData salt)
        {
            var valueArray = value.Bytes;
            var saltArray = salt.Bytes;

            var algorithm = new SHA256Managed();

            var valueWithSaltBytes = new byte[valueArray.Length + saltArray.Length];

            for (var i = 0; i < valueArray.Length; i++)
            {
                valueWithSaltBytes[i] = valueArray[i];
            }

            for (var i = 0; i < saltArray.Length; i++)
            {
                valueWithSaltBytes[valueArray.Length + i] = saltArray[i];
            }

            return new SecureData(ToHex(algorithm.ComputeHash(valueWithSaltBytes), true));
        }

        private static string ToHex(byte[] bytes, bool upperCase)
        {
            var result = new StringBuilder(bytes.Length * 2);

            for (var i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));
            }

            return result.ToString();
        }
    }
}