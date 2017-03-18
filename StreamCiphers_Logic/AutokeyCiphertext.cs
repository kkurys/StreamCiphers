using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCiphers_Logic
{
    public class AutokeyCiphertext
    {
        List<int> seed;
        List<int> f;
        List<int> x;
        List<int> y;

        byte[] fileBytes;

        public AutokeyCiphertext()
        {
            seed = new List<int>();
            f = new List<int>();
            x = new List<int>();
            y = new List<int>();
        }

        public AutokeyCiphertext(string fileName)
        {
            // czytanie z pliku !!
            fileBytes = File.ReadAllBytes(fileName);
            seed = new List<int>();
            f = new List<int>();
            x = new List<int>();
            y = new List<int>();
        }

        public void Init(string argSeed, string argFunction, string argStream)
        {
            for (int i = 0; i < argSeed.Count(); i++)
            {
                seed.Add(int.Parse(argSeed[i].ToString()));
                y.Add(0);
            }

            for (int i = 0; i < 4; i++)
            {
                f.Add(int.Parse(argFunction[i].ToString()));
            }

            for (int i = 0; i < 4; i++)
            {
                x.Add(int.Parse(argStream[i].ToString()));
            }
        }

        public List<int> Encrypt()
        {

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

        public string GetEcnryptedString()
        {
            string result = "";

            for (int i = 0; i < y.Count(); i++)
            {
                result += y[i];
            }

            return result;
        }


    }
}
