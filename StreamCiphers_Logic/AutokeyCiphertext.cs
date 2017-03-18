using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCiphers_Logic
{
    class AutokeyCiphertext
    {
        List<int> seed;
        List<int> f;
        List<int> x;
        
        byte[] fileBytes;

        public AutokeyCiphertext(string fileName)
        {
            fileBytes = File.ReadAllBytes(fileName);
            seed = new List<int>();
            f = new List<int>();
            x = new List<int>();
        }

        public List<int> Encrypt()
        {
            List<int> y = new List<int>();

            for (int i = 0; i < seed.Count(); i++)
            {
                for (int j = 0; j < f.Count(); j++)
                {
                    if (f[j] == 1)
                    {
                        y[i] += seed[j];
                    }
                }

                y[i] = (x[i] + y[i]) % 2;

                for (int j = seed.Count() - 1; j > 0; j--)
                {
                    seed[j] = seed[j - 1];
                }
                seed[0] = y[i];
            }

            return y;
        }


    }
}
