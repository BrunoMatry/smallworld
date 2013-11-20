using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using WrapperCarte;

namespace TestsUnitaires
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestWrapper()
        {
            WrapperCarte w = new WrapperCarte();
            Assert.AreEqual(w.nbPtVie(), 10);
        }
    }
}
