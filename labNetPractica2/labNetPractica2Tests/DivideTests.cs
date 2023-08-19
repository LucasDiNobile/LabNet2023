using Microsoft.VisualStudio.TestTools.UnitTesting;
using labNetPractica2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2.Tests
{
    [TestClass()]
    public class DivideTests
    {
        [TestMethod()]
        public void DividirTest()
        {
            //Arrang
            int dividendo = 10;
            int divisor = 5;
            int resultadoPrueba;
            int resultadoEsperado = 2;

            //Act
            resultadoPrueba = dividendo / divisor;

            //Assert


            Assert.AreEqual(resultadoPrueba, resultadoEsperado);
        }
    }
}