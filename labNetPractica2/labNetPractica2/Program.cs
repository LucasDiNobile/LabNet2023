using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ejerciocio 1
            int divCero;

            divCero = DivCero(4);
            Console.WriteLine(divCero);

            //Ejercicio 2
            int divisor = 0, dividendo = 0;

            try
            {
                Console.WriteLine("Por favor ingrese un numero.");
                divisor = int.Parse(Console.ReadLine());
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
            }

            try
            {
                Console.WriteLine("Por favor ingrese un numero.");
                dividendo = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
            }

            Console.WriteLine(Divide.Dividir(divisor, dividendo));

            //Ejercicio 3
            try
            {
                Logic.TiraExcepcion();
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Ejercicio 4
            try
            {
                TrowExcepcionPersonalizada();
            }
            catch(ExcepcionPersonalizada ex) 
            {
                Console.WriteLine($"se capturo {ex.Message}");
            }   

                
            Console.ReadKey();
        }

        private static int DivCero(int num1)
        {
            try
            {
                return num1 / 0;
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                Console.WriteLine("La operacion terminó de realizarse!");
            }
        }

        private static void TrowExcepcionPersonalizada()
        {
            throw new ExcepcionPersonalizada(); 
        }

        
    }
}
