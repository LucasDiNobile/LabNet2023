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
            double dividendo = 10;
            double divisor = 5;
            double resultadoPrueba;
            double resultadoEsperado = 2;

            //Act
            resultadoPrueba = Divide.Dividir(dividendo, divisor);

            //Assert
            Assert.AreEqual(resultadoPrueba, resultadoEsperado);
            
        }
    }
}