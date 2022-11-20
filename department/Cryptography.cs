using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace department
{
     class Cryptography
    {
        public static string crypt(string randomString)
        {
            MD5 mD5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(randomString);
            return Encoding.UTF8.GetString(mD5.ComputeHash(bytes));
        }
    }
}
