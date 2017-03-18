using System;

namespace StreamCiphers_Logic
{
    public class LFSR
    {
        public string Polynomial { get; set; }
        public string Seed { get; set; }

        public void Init(string _seed, string _polynomial)
        {
            Polynomial = _polynomial;
            Seed = _seed;
        }
        public string GetOutput()
        {
            string result = "";
            string lfsr = Seed;
            for (int i = 0; i < Seed.Length; i++)
            {
                int lfsrInt = Convert.ToInt32(lfsr, 2);
                int bit = lfsrInt;

                for (int j = 1; j < Polynomial.Length; j++)
                {
                    if (Polynomial[j] == '1')
                    {
                        bit = bit ^ (lfsrInt >> (j - 1));
                    }
                }
                bit = bit & 1;
                lfsrInt = (lfsrInt >> 1) | (bit << (lfsr.Length - 1));
                lfsr = Convert.ToString(lfsrInt, 2);
                result += bit;
            }

            return result;
        }
    }
}
