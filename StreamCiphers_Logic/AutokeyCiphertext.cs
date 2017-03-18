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
        public List<string> Bytes { get; set; }
        List<string> output;

        byte[] fileBytes;

        public AutokeyCiphertext()
        {
            Seed = new List<int>();
            F = new List<int>();
            X = new List<int>();
            Y = new List<int>();
            Bytes = new List<string>();
            output = new List<string>();
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

        public void Init(string argSeed, string argFunction)
        {
            for (int i = 0; i < argSeed.Count(); i++)
            {
                Seed.Add(int.Parse(argSeed[i].ToString()));
            }

            for (int i = 0; i < argFunction.Count(); i++)
            {
                F.Add(int.Parse(argFunction[i].ToString()));
            }
        }

        public List<int> Encrypt()
        {
            foreach (string stream in Bytes)
            {
                X = new List<int>();
                Y = new List<int>();
                for (int i = 0; i < stream.Count(); i++)
                {
                    X.Add(int.Parse(stream[i].ToString()));
                    Y.Add(0);
                }

                for (int i = 0; i < X.Count(); i++)
                {
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
                output.Add(ByteToString());
            }

            

            return Y;
        }

        private string ByteToString()
        {
            string result = "";

            for (int i = 0; i < Y.Count(); i++)
            {
                result += Y[i];
            }

            return result;
        }

        public string GetResultString()
        {
            string result = "";
            foreach (string stream in output)
            {
                result += stream;
            }

            return result;
        }

        public void ReadBytesFromFile(string fileName)
        {
            byte[] fileBytes = File.ReadAllBytes(fileName);

            foreach (byte b in fileBytes)
            {
                Bytes.Add(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
        }

        private byte[] GetOutputBytes()
        {
            List<byte> byteList = new List<byte>();

            foreach (string stream in output)
            {
                byteList.Add(Convert.ToByte(stream, 2));
            }
            return byteList.ToArray();
        }

        public void WriteBytesToFile(string filename)
        {
            File.WriteAllBytes(filename, GetOutputBytes());
        }
    }
}
