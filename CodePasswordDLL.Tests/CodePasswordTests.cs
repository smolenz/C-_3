using CodePasswordDLL;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace CodePasswordDLL.Tests
{
    [TestClass]
    public class CodePasswordTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("Test Initialize");
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            Debug.WriteLine("Test CleanUp");
        }

        [TestMethod]
        public void getCodPassword_abc_bcd()
        {
            Debug.WriteLine("Test getCodPassword_abc_bcd");
            // arrange
            string strIn = "abc";
            string strExpected = "bcd";
            // act
            string strActual = CodePassword.getCodPassword(strIn);
            //assert
            Assert.AreEqual(strExpected, strActual, "Значения не равны");
        }

        [TestMethod()]
        public void getCodPassword_empty_empty()
        {
            Debug.WriteLine("Test getCodPassword_empty_empty");
            // arrange 
            string strIn = "";
            string strExpected = "";
            // act 
            string strActual = CodePassword.getCodPassword(strIn);
            //assert
            Assert.AreEqual(strExpected, strActual,"Значения не равны");
        }

        [TestMethod]
        public void getPassword_bcd_abc()
        {
            Debug.WriteLine("Test getPassword_bcd_abc");
            // arrange
            string strIn = "bcd";
            string strExpected = "abc";
            // act
            string strActual = CodePassword.getPassword(strIn);
            //assert
            Assert.AreEqual(strExpected, strActual, "Значения не равны");
        }

        [TestMethod()]
        public void getPassword_empty_empty()
        {
            Debug.WriteLine("Test getPassword_empty_empty");
            // arrange 
            string strIn = "";
            string strExpected = "";
            // act 
            string strActual = CodePassword.getPassword(strIn);
            //assert
            Assert.AreEqual(strExpected, strActual, "Значения не равны");

        }

        [TestMethod]

        public void getPassword_isNotNull()
        {
            // arrange 
            string strIn = "test";
            // act 
            string strActual = CodePassword.getPassword(strIn);
            //assert
            Assert.IsNotNull(strActual);
        }
    }
}
