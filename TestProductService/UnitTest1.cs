using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProductService
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProductServiceClass p = new ProductServiceClass();
            List<ProductDTO> prods = p.getProducts();
            Assert.IsNotNull(prods);
            Assert.IsTrue(prods.Count > 0);
        }
    }
}
