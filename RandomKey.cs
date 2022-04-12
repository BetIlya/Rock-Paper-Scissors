using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using SHA3.Net;

namespace Task_3
{
    class RandomKey
    {
        private byte[] tokenBuffer;
        public RandomKey()
        {
            using (RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider())
            {
                tokenBuffer = new byte[32]; //256 bit = 32 byte       
                rngCrypt.GetBytes(tokenBuffer);
            }
        }
        public byte[] GetRandomKey()
        {
            return tokenBuffer;
        }
        public override string ToString() => BitConverter.ToString(tokenBuffer).Replace("-", string.Empty);
    }
}
