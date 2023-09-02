using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.Practica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica3.EF.Logic.Tests
{
    [TestClass()]
    public class InstertLogicTests
    {
        [TestMethod()]
        public void InsterCheckTest()
        {
            //Arrange
            int resultado = 0, resultadoEsperado = 1;
            string var = "lucas";

            //Act
            resultado = InstertLogic.InsterCheck(var, "Nombre", 10);

            //Assert
            Assert.AreEqual(resultado, resultadoEsperado);
        }
    }
}