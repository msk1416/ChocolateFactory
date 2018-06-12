using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProductService.PSReference;

namespace UnitTestProductService
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetProducts()
        {
            ProductServiceClient client =
                new ProductServiceClient();
            ProductDTO[] prods = client.getProducts();
            Assert.IsNotNull(prods);
            Assert.IsTrue(prods.Length > 0);
        }
    }
}
