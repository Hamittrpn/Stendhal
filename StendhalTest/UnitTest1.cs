using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stendhal.Client.mobile.ViewModels;
using System;

namespace StendhalTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange  
            Methods m1 = new Methods();
            int expectedResult = 16;


            //Act  
            int actualResult = m1.Addititon(11, 5);


            //Assert  
            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}
