namespace tets1.Tests
{
    [TestClass]
    public sealed class Test1
    {
        [DataTestMethod]
        [DataRow("bla1", 1)]
        [DataRow("bla2", 2)]
        [DataRow("bla3", 3)]
        [DataRow("bla4", 4)]
        [DataRow("bla5", 5)]
        [DataRow("bla6", 6)]
        [DataRow("bla7", 7)]
        public void EnqueueTest(string value, int priority)
        {
            PriorityQueue queue = new PriorityQueue(10);
            queue.Enqueue(value, priority);
        }
    }
}
