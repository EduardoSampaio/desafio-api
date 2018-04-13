using System;
using System.Security.Cryptography;
using System.Text;

namespace Desafio.Infra.CrossCutting.Security
{
    public class Md5Cryptography
    {
        public static string GetMd5Hash(string valor)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(valor));
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}
