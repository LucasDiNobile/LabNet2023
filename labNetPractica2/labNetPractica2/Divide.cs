using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    public static class Divide
    {
        public static int DivCero(int num1)
        {
            try
            {
                return num1 / 0;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                Console.WriteLine("La operacion terminó de realizarse!");
            }
        }

        public static decimal Dividir(decimal dividendo, decimal divisor)
        {
            try
            {
                return dividendo / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("¡Solo Chuck Norris divide por cero!");
                return -1;
            }

        }
    }
}
