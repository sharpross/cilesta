namespace Cilesta.Utils.Common
{
    using System.Security.Cryptography;
    using System.Text;

    public static class SecurityHelper
    {
        public static string EncryptPassword(string password)
        {
            var result = string.Empty;

            var md5 = MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);

            byte[] hash = md5.ComputeHash(inputBytes);
            
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            result = sb.ToString();

            return result;
        }
    }
}
