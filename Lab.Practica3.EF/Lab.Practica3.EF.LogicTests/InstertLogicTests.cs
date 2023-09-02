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
        public void InsterSetTest()
        {
            //Arrange
            string var = "Lucas", resultado = "", resultadoEspereado = "Lucas";
            int cant = 10;

            //Act
            resultado = InstertLogic.InsterSet("'Nombre'", cant);

            //Assert
            Assert.AreEqual(resultadoEspereado, resultado);
        }
    }
}