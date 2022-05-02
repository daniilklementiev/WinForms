using System;

namespace MyLibrary
{
    public class Hash
    {
        public static string Md5(string input)
        {
            var sb = new System.Text.StringBuilder();
            using (var hasher = new System.Security.Cryptography.MD5CryptoServiceProvider())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hash = hasher.ComputeHash(bytes);

                foreach (var b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
            }

            return sb.ToString();
        }

        public static string Sha1(string input)
        {
            var sb = new System.Text.StringBuilder();

            using (var hasher = System.Security.Cryptography.SHA1.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hash = hasher.ComputeHash(bytes);

                foreach (var b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
            }

            return sb.ToString();
        }

        public static string Sha256(string input)
        {
            var sb = new System.Text.StringBuilder();

            using (var hasher = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hash = hasher.ComputeHash(bytes);

                foreach (var b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
            }

            return sb.ToString();
        }
    }
}
