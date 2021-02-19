using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProjektSemestralny;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string uzytkownik = "user";
            string haslo = "user";

            MainWindow mainWindow = new MainWindow();

            mainWindow.SprawdzNazweiHaslo(uzytkownik , haslo);

            //Assert.AreEqual(uzytkownik, mainWindow );
            //Assert.AreEqual(haslo, mainWindow);
            Assert.AreNotSame(uzytkownik, mainWindow);
            Assert.AreNotSame(haslo, mainWindow);



        }
    }
}
