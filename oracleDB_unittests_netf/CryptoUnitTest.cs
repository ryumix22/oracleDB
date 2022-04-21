using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace oracleDB_unittests_netf
{
    [TestClass]
    public class CryptoUnitTest
    {
        [TestMethod]
        public void hashPasswordTest()
        {
            string passwordTest = "JKSDH57923nsdf43-_gp9I";
            string hashTest1 = oracleDB.crypto.Crypto.hashPassword(passwordTest);
            string hashTest2 = oracleDB.crypto.Crypto.hashPassword(passwordTest);
            Assert.AreNotEqual(hashTest1, hashTest2);
        }

        [TestMethod]
        public void checkPasswordTest()
        {
            string passwordTest = "Zfhj84-6adf;JSKDNG:";
            string hashTest1 = oracleDB.crypto.Crypto.hashPassword(passwordTest);
            bool IsMatch = oracleDB.crypto.Crypto.checkPassword(hashTest1, passwordTest);
            Assert.IsTrue(IsMatch);
        }
        [TestMethod]
        public void checkPasswordWrongTest()
        {
            string hashTest1 = oracleDB.crypto.Crypto.hashPassword("qwe123");
            bool IsMatch = oracleDB.crypto.Crypto.checkPassword(hashTest1, "qwe124");
            Assert.IsFalse(IsMatch);
        }
    }


}
