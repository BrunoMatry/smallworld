using System;
using System.Collections.Generic;
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
						List<int> l = WrapperCarte.gencarte(2, 3);
            Assert.IsTrue(l[0] == 0 || l[0] == 1);
        }
    }
}
