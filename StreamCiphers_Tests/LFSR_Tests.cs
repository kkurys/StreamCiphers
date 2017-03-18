using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamCiphers_Logic;
namespace StreamCiphers_Tests
{
    [TestClass]
    public class LFSR_Tests
    {
        [TestMethod]
        public void LFSR_Logic_Initialization()
        {
            LFSR lfsr = new LFSR();

            lfsr.Init("1011", "1101");
            Assert.AreEqual("1011", lfsr.Seed);
            Assert.AreEqual("1101", lfsr.Polynomial);

        }
        [TestMethod]
        public void Math_Operations_Work()
        {
            int seed = 11;
            Assert.AreEqual(11, seed);
            // seed = 1011, polynomial = 1101
            int bit = ((seed >> 0) ^ (seed >> 1) ^ (seed >> 3)) & 1;
            Assert.AreEqual(1, bit);

        }
        [TestMethod]
        public void LFSR_Logic_Engine_Works()
        {
            LFSR lfsr = new LFSR();

            lfsr.Init("1011", "11001");
            string result = lfsr.GetOutput();

            Assert.AreEqual("0110", result);
        }
    }
}
