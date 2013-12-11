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
        public void TestWrapper1()
        {
            // Genere une carte de 3 cases avec deux types de case different
			List<int> l = WrapperCarte.wrap_gen_carte(1, 3);
            Assert.IsTrue(l[0] == 0);
            Assert.IsTrue(l[1] == 0);
            Assert.IsTrue(l[2] == 0);
        }

        [TestMethod]
        public void TestWrapper2()
        {
            // Genere une carte de 3 cases avec deux types de case different
            List<int> l = WrapperCarte.wrap_gen_carte(2, 3);
            Assert.IsTrue(l[0] == 0 || l[0] == 1);
        }
    }
}
