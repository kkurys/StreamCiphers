using System;
using System.Collections.Generic;
using System.IO;

namespace StreamCiphers_Logic
{
    public class SynchronousStream : ICipher
    {
        private LFSR _lfsr;
        private byte[] _fileBytes;
        private List<string> _output;
        public List<string> Bytes { get; set; }

        public SynchronousStream()
        {
            _lfsr = new LFSR();
            Bytes = new List<string>();
            _output = new List<string>();
        }
        public string Polynomial { get; set; }
        public string Seed { get; set; }

        public string GetOutput()
        {
            string _lfsrResult = _lfsr.GetOutput();
            string _result = "";
            foreach (string input in Bytes)
            {
                _result = "";
                for (int i = 0; i < 8; i++)
                {
                    _result += (Convert.ToInt32(input[i]) ^ Convert.ToInt32(_lfsrResult[i % _lfsrResult.Length]));
                }
            }

            WriteBytesToFile("out.bin");
            return _result;
        }
        public void ReadBytesFromFile(string fileName)
        {
            byte[] fileBytes = File.ReadAllBytes(fileName);

            foreach (byte b in fileBytes)
            {
                Bytes.Add(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
        }

        public void Init(string _seed, string _polynomial)
        {
            Seed = _seed;
            Polynomial = _polynomial;
            _lfsr.Init(Seed, Polynomial);
        }
        private byte[] GetOutputBytes()
        {
            List<byte> byteList = new List<byte>();

            foreach (string stream in _output)
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
