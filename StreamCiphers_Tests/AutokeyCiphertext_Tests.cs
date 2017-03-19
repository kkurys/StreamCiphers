using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamCiphers_Logic;

namespace StreamCiphers_Tests
{
    [TestClass]
    public class AutokeyCiphertext_Tests
    {
        /*
        [TestMethod]
        public void AutokeyCiphertext_Logic_Initialization()
        {
            AutokeyCiphertext autokey = new AutokeyCiphertext();

            autokey.Init("1011", "1001", "1100");
            List<int> checkSeed = new List<int>();
            checkSeed.Add(1);
            checkSeed.Add(0);
            checkSeed.Add(1);
            checkSeed.Add(1);
            Assert.AreEqual(checkSeed, autokey.Seed);
            //Assert.AreEqual("1101", lfsr.Polynomial);

        }
        */

        /*
        [TestMethod]
        public void AutokeyCiphertext_Operations_Work()
        {
            int seed = 11;
            Assert.AreEqual(11, seed);
            // seed = 1011, polynomial = 1101
            int bit = ((seed >> 0) ^ (seed >> 1) ^ (seed >> 3)) & 1;
            Assert.AreEqual(1, bit);

        }
        */
        [TestMethod]
        public void AutokeyCiphertext_Logic_Engine_Works()
        {
            AutokeyCiphertext autokey = new AutokeyCiphertext();

            //autokey.Init("1011", "1001", "1100");
            autokey.Init("1011", "1001");
            List<string> streams = new List<string>();
            streams.Add("1100");
            autokey.Bytes = streams;
            autokey.Encrypt();
            string result = autokey.GetResultString();

            Assert.AreEqual("1110", result);
        }

        [TestMethod]
        public void AutokeyCiphertext_Logic_Engine_Works_2()
        {
            AutokeyCiphertext autokey = new AutokeyCiphertext();

            //autokey.Init("1011", "1001", "11001101");
            autokey.Init("1011", "1001");
            List<string> streams = new List<string>();
            streams.Add("11001101");
            autokey.Bytes = streams;
            autokey.Encrypt();
            string result = autokey.GetResultString();

            Assert.AreEqual("11100010", result);
        }

        [TestMethod]
        public void AutokeyCiphertext_Logic_Engine_Works_3()
        {
            AutokeyCiphertext autokey = new AutokeyCiphertext();

            //autokey.Init("1110", "0101", "10011101");
            autokey.Init("11101010", "10100011");
            List<string> streams = new List<string>();
            streams.Add("10011101");
            autokey.Bytes = streams;
            autokey.Encrypt();
            string result = autokey.GetResultString();

            Assert.AreEqual("00000111", result);
        }

        [TestMethod]
        public void AutokeyCiphertext_Logic_Engine_Works_4()
        {
            AutokeyCiphertext autokey = new AutokeyCiphertext();

            //autokey.Init("0010", "1011", "1111");
            autokey.Init("11101010", "10100011");
            List<string> streams = new List<string>();
            streams.Add("01110010");
            autokey.Bytes = streams;
            autokey.Encrypt();
            string result = autokey.GetResultString();

            Assert.AreEqual("10101010", result);
        }

        [TestMethod]
        public void AutokeyCiphertext_Logic_Engine_Works_5()
        {
            AutokeyCiphertext autokey = new AutokeyCiphertext();

            //autokey.Init("0010", "1011", "1111");
            autokey.Init("11101010", "10100011");
            List<string> streams = new List<string>();
            streams.Add("10011101");
            streams.Add("01110010");
            autokey.Bytes = streams;
            autokey.Encrypt();
            string result = autokey.GetResultString();

            Assert.AreEqual("0000011110101010", result);
        }

        /*
        [TestMethod]
        public void AutokeyCiphertext_Logic_Engine_Works_File()
        {
            AutokeyCiphertext autokey = new AutokeyCiphertext();

            //autokey.Init("1110", "0101", "10011101");
            autokey.Init("11101010", "10100011");
            autokey.ReadBytesFromFile("test3.bin");
            autokey.Encrypt();
            autokey.WriteBytesToFile("output3.bin");
            string result = autokey.GetResultString();

            Assert.AreEqual("00100110", result);
        }
        */
    }
}
