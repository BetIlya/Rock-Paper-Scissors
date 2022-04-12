using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHA3.Net;

namespace Task_3
{
    class CalcHMAC
    {
        private RandomKey key;
        private byte[] hash;
        private string originalStr;
        public CalcHMAC(string str)
        {
            key = new RandomKey();
            originalStr = str;
            hash = Sha3.Sha3256().ComputeHash(Encoding.Default.GetBytes(str));
        }
        public RandomKey GetKey()
        {
            return key;
        }
        public byte[] GetHash()
        {
            return hash;
        }
        public override string ToString() => BitConverter.ToString(hash).Replace("-", string.Empty);

        public void WriteKey()
        {
            Console.WriteLine("HMAC key:");
            Console.WriteLine(key);
        }

        public void WriteHash()
        {
            Console.WriteLine("HMAC:");
            Console.WriteLine(this);
        }




    }
}
