using System.Security.Cryptography;
using System.Text;

namespace USFH.Libs
{
    public class PasswordHash
    {
        public static string HashPass(string password)
        {
            var sha1 = SHA1.Create();
            var step1 = Encoding.UTF8.GetBytes(password);
            var step2 = sha1.ComputeHash(step1);
            var encryted_password = ByteArrayToString(step2);
            return encryted_password;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
