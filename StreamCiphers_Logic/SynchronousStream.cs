using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StreamCiphers_Logic
{
    public class SynchronousStream : ICipher
    {
        private LFSR _lfsr;
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

        public string GetOutput(string _fileName, int _mode)
        {
            string _lfsrResults = _lfsr.GetOutput(null, 0);
            string[] _lfsrResultTokens = _lfsrResults.Split('\n');
            string _lfsrResult = "";
            for (int i = 0; i < _lfsrResultTokens.Length; i++)
            {
                _lfsrResult += _lfsrResultTokens[0];                
            }
            string _result = "";
            ReadBytesFromFile(_fileName);
            int pos = 0;
            foreach (string input in Bytes)
            {
                _result = "";
                for (int i = 0; i < 8; i++)
                {
                    _result += (Convert.ToInt32(input[i]) ^ Convert.ToInt32(_lfsrResult[pos++]));
                    if (pos == _lfsrResult.Length)
                    {
                        pos = 0;
                    }
                }
                _output.Add(_result);
            }

            WriteBytesToFile(GetOutputFileName(_fileName));
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
            Bytes.Clear();
            _lfsr.Init(Seed, Polynomial);
            _output.Clear();

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
        public string GetOutputFileName(string inputFileName)
        {
            string[] parts = inputFileName.Split('.');
            parts[parts.Count() - 2] += "_out";

            return String.Join(".", parts);
        }

        public void WriteBytesToFile(string filename)
        {
            File.WriteAllBytes(filename, GetOutputBytes());
        }
    }
}
