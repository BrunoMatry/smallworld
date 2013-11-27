using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapper;

namespace TestsUnitaires
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestWrapper()
        {
            Assert.AreEqual(WrapperCarte.gen_carte()[0], 1);
        }
    }
}
