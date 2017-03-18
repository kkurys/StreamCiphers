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
    class AutokeyCiphertext_Tests
    {
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

            autokey.Init("1011", "1001", "1100");
            string result = autokey.GetEcnryptedString();

            Assert.AreEqual("1110", result);
        }

        [TestMethod]
        public void AutokeyCiphertext_Logic_Engine_Works_2()
        {
            AutokeyCiphertext autokey = new AutokeyCiphertext();

            autokey.Init("0010", "1011", "1111");
            string result = autokey.GetEcnryptedString();

            Assert.AreEqual("0010", result);
        }
    }
}
