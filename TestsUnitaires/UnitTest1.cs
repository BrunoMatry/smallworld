using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wrapper;

namespace TestsUnitaires
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestWrapper()
        {
            Assert.AreEqual(WrapperCarte.gencarte()[0], 1);
        }
    }
}
