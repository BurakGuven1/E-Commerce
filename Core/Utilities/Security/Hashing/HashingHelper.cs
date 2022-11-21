using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //password vericez ve hash-salt ını yani 2 değer çıkaracak bize.
        //out dışarıya verilecek değer gibi düşünebiliriz ve birden fazla değer döndürmek için de kullanılır.
        public static void CreatePasswordHash(string password, 
            out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password,
            byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
               var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            
        }
    }
}
