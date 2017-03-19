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
        public string StringSeed { get; set; }
        public List<int> F { get; set; }
        public List<string> Bytes { get; set; }
        List<string> output;

        byte[] fileBytes;

        public AutokeyCiphertext()
        {
            F = new List<int>();
            Bytes = new List<string>();
            output = new List<string>();
        }

        public AutokeyCiphertext(string fileName)
        {
            // czytanie z pliku !!
            fileBytes = File.ReadAllBytes(fileName);
            F = new List<int>();
        }

        public void Init(string argSeed, string argFunction)
        {
            StringSeed = argSeed;
            for (int i = 0; i < argFunction.Count(); i++)
            {
                F.Add(int.Parse(argFunction[i].ToString()));
            }
        }

        public void Encrypt()
        {
            foreach (string stream in Bytes)
            {
                List<int> x = new List<int>();
                List<int> y = new List<int>();
                List<int> seed = new List<int>();

                for (int i = 0; i < StringSeed.Count(); i++)
                {
                    seed.Add(int.Parse(StringSeed[i].ToString()));
                }

                for (int i = 0; i < stream.Count(); i++)
                {
                    x.Add(int.Parse(stream[i].ToString()));
                    y.Add(0);
                }

                for (int i = 0; i < x.Count(); i++)
                {
                    for (int j = 0; j < F.Count(); j++)
                    {
                        if (F[j] == 1)
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
                output.Add(ByteToString(y));
            }
        }

        private string ByteToString(List<int> oneByte)
        {
            string result = "";

            for (int i = 0; i < oneByte.Count(); i++)
            {
                result += oneByte[i];
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
