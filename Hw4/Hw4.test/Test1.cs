
namespace Hw4.test
{
    using Hw4;

    [TestClass]
    [DoNotParallelize]
    public sealed class Test1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OptimumEmptyTest()
        {
            Routers.Optimum("../../../TestData/testEmpty.txt", "../../../TestData/testOutEmpty.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OptimumDisconnectedTest()
        {
            Routers.Optimum("../../../TestData/testDisconnected.txt", "../../../TestData/testOutDisconnected.txt");
        }

        [TestMethod]
        public void OptimumTest()
        {
            Routers.Optimum("../../../TestData/test1.txt", "../../../TestData/testOut1.txt");
            var sr = new StreamReader("../../../TestData/testOut1.txt");
            Assert.AreEqual(sr.ReadLine(), "1: 2 (100), 5 (100)");
            Assert.AreEqual(sr.ReadLine(), "2: 3 (100)");
            Assert.AreEqual(sr.ReadLine(), "3: 4 (100)");

        }
    }
}
