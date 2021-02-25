using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProjektSemestralny;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        [DataRow("user", "user")]
        public void SprawdzNazweiHasloPoprawne(string uzytkownik, string haslo)
        {
            Assert.AreEqual(true, MainWindow.SprawdzNazweIhaslo(uzytkownik, haslo));
        }

        [DataTestMethod]
        [DataRow("user", "user1")]
        public void SprawdzNazweiHasloNiepoprawne(string uzytkownik, string haslo)
        {
            Assert.AreEqual(false, MainWindow.SprawdzNazweIhaslo(uzytkownik, haslo));
        }



    
    }
}
