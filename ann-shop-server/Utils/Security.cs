using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ann_shop_server.Utils
{
    public class Security
    {
        private const string SIGN = "ANN SHOP";

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2")); // hex format
            }
            return result.ToString();
        }

        public static string Encrypt(string pass)
        {
            var encoding = new ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(SIGN);
            byte[] messageBytes = encoding.GetBytes(pass);

            var hmacmd5 = new HMACMD5(keyByte);
            var hmacsha256 = new HMACSHA256(keyByte);
            byte[] hashmessage = hmacmd5.ComputeHash(messageBytes);

            hashmessage = hmacsha256.ComputeHash(messageBytes);

            return GetStringFromHash(hashmessage);
        }


        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

    }
}