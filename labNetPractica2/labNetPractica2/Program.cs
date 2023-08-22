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
            int divCero = 0;
            bool continuar = true;

            while (continuar)
            {
                try
                {
                    Console.WriteLine("Por favor ingrese un numero para que sea dividido por cero.");
                    divCero = int.Parse(Console.ReadLine());
                    continuar = false;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
                }
            }
            Console.WriteLine(Divide.DivCero(divCero));

            //Ejercicio 2
            double divisor = 0, dividendo = 0, resultado;

            try
            {
                Console.WriteLine("Por favor ingrese un numero.");
                divisor = double.Parse(Console.ReadLine());
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
            }

            try
            {
                Console.WriteLine("Por favor ingrese un numero.");
                dividendo = double.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
            }
            resultado = Divide.Dividir(divisor, dividendo);
            Console.WriteLine($"\nEl resultado de la division es: {resultado}");

            //Ejercicio 3
            try
            {
                Logic.TiraExcepcion();
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"\nExcepcion: {ex.Message}");
                Console.WriteLine($"StackTrace {ex.StackTrace}");
            }

            //Ejercicio 4
            try
            {
                Logic.TrowExcepcionPersonalizada();
            }
            catch(ExcepcionPersonalizada ex) 
            {
                Console.WriteLine($"\n{ex.Message}");
                Console.WriteLine($"\n{ex.MensajePerso()}");
            }   

                
            Console.ReadKey();
        }

       
               
    }
}
