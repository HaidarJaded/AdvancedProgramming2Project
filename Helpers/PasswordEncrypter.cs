using System.Security.Cryptography;
using System.Text;

namespace APP2EFCore.Helpers
{
    public static class PasswordEncrypter
    {
        public static string EncryptPassword(string password)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = MD5.HashData(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
