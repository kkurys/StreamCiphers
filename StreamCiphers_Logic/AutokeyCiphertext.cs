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
        public List<int> Seed { get; set; }
        public List<int> F { get; set; }
        public List<int> X { get; set; }
        public List<int> Y { get; set; }

        byte[] fileBytes;

        public AutokeyCiphertext()
        {
            Seed = new List<int>();
            F = new List<int>();
            X = new List<int>();
            Y = new List<int>();
        }

        public AutokeyCiphertext(string fileName)
        {
            // czytanie z pliku !!
            fileBytes = File.ReadAllBytes(fileName);
            Seed = new List<int>();
            F = new List<int>();
            X = new List<int>();
            Y = new List<int>();
        }

        public void Init(string argSeed, string argFunction, string argStream)
        {
            for (int i = 0; i < argSeed.Count(); i++)
            {
                Seed.Add(int.Parse(argSeed[i].ToString()));
            }

            for (int i = 0; i < 4; i++)
            {
                F.Add(int.Parse(argFunction[i].ToString()));
            }

            for (int i = 0; i < 4; i++)
            {
                X.Add(int.Parse(argStream[i].ToString()));
            }
        }

        public List<int> Encrypt()
        {

            for (int i = 0; i < Seed.Count(); i++)
            {
                Y.Add(0);
                for (int j = 0; j < F.Count(); j++)
                {
                    if (F[j] == 1)
                    {
                        Y[i] += Seed[j];
                    }
                }

                Y[i] = (X[i] + Y[i]) % 2;

                for (int j = Seed.Count() - 1; j > 0; j--)
                {
                    Seed[j] = Seed[j - 1];
                }
                Seed[0] = Y[i];
            }

            return Y;
        }

        public string GetEcnryptedString()
        {
            string result = "";

            for (int i = 0; i < Y.Count(); i++)
            {
                result += Y[i];
            }

            return result;
        }


    }
}
