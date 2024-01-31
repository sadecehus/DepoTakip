using System.Security.Cryptography;
using System.Text;

namespace example
{
    internal class sifreleme
    {
        public static string md5sifreleme(string sifrelenecekmetin)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var arrayBytes = Encoding.UTF8.GetBytes(sifrelenecekmetin);
            arrayBytes = md5.ComputeHash(arrayBytes);
            var sb = new StringBuilder();
            foreach (var item in arrayBytes)
                sb.Append(item.ToString("X2").ToLower());
            return sb.ToString();
        }

        public static string shaSifreleme(string sifrelenecekmetin)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            var arrayBytes = Encoding.UTF8.GetBytes(sifrelenecekmetin);
            arrayBytes = sha256.ComputeHash(arrayBytes);
            var sb = new StringBuilder();
            foreach (var item in arrayBytes)
                sb.Append(item.ToString("X2").ToLower());
            return sb.ToString();
        }
    }
}