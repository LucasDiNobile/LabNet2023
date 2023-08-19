using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    public class Divide
    {
        public static int Dividir(int dividendo, int divisor)
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
