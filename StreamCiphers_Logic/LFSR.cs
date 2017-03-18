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
        public int XORBits(int _base)
        {
            int bit = _base;
            for (int j = 1; j < Polynomial.Length; j++)
            {
                if (Polynomial[j] == '1')
                {
                    bit = bit ^ (_base >> j);
                }
            }
            string bitString = Convert.ToString(bit, 2);
           // bitString = bitString.PadLeft(Seed.Length, '0');
            if (bitString.LastIndexOf('0') != -1) return 0;
            return 1;
        }
        public int ReplaceFirstBit(int _base, int bit)
        {
            string _baseString = Convert.ToString(_base, 2);

            _baseString = _baseString.PadLeft(Seed.Length, '0');
            _baseString = bit.ToString() + _baseString.Substring(1);

            return Convert.ToInt32(_baseString, 2);
        }
        public int Shift(int _base)
        {
            return (_base >> 1);
        }
        public string GetOutput()
        {
            string result = "";
            string ciphered = Seed;
            for (int i = 0; i < Seed.Length; i++)
            {
                int cipheredInt = Convert.ToInt32(ciphered, 2);

                int bit = XORBits(cipheredInt);

                cipheredInt = Shift(cipheredInt);

                cipheredInt = ReplaceFirstBit(cipheredInt, bit);

                ciphered = Convert.ToString(cipheredInt, 2).PadLeft(Seed.Length, '0');
                if ( i == 3)
                    return ciphered;
                result += ciphered[0];
            }

            return result;
        }
    }
}
