using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PBL6BackEnd.Extensions
{
    public static class StringExtensions
    {
        private const string passwordKey = "p*a%P_Uc!E9jvKN=L$Q#y=hxaQat4q7Bg?_TaWbfAvD9YXjeWCkmy!vqgzu*eUALDN6JLRLue2RnhXUb";

        public static string Encrypt(this string password)
        {
            password += passwordKey;
            var byteSourceText = Encoding.ASCII.GetBytes(password);
            var md5Hash = new MD5CryptoServiceProvider();
            var byteHash = md5Hash.ComputeHash(byteSourceText);

            return string.Concat(byteHash.Select(x => x.ToString("x2")));
        }
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
