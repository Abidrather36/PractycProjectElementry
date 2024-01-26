using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Practyc.Application.Utils
{
    public static  class AppEncryption
    {
        public static string? CreateSalt()
        {
            /* RNGCryptoServiceProvider rng = new();
             byte[] salt= new byte[32];
             rng.GetBytes(salt);
             return Convert.ToBase64String(salt);*/
            var rng=RandomNumberGenerator.GetBytes(20);
            return  Convert.ToBase64String(rng);
        }
        
        public static string CreatepasswordHash(string password,string salt)
        {
            string saltedPassword =string.Concat(password,salt);
            HMACSHA256 sha = new HMACSHA256();
            byte[] hash=sha.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
            return Convert.ToBase64String(hash);  
        }
        public static bool ComparePassword(string dbPassword,string newPassword,string dbsalt)
        {
            return dbPassword==CreatepasswordHash(newPassword,dbsalt);
        }
    }
}
