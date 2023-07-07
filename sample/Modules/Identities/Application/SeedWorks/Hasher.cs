using System.Security.Cryptography;
using System.Text;

namespace Identities.Application.SeedWorks
{
    public sealed class Hasher : IHasher
    {
        public string CalculateHash(string value)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                return Convert.ToHexString(hash);
            }
        }
    }
}
