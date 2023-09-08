using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica6.Logic
{
    public class UpdateLogic
    {
        public static string UpdateEmpleado(string nombre, int id, int cant)
        {
            string var = "";
            int sale = 0;
            while (sale == 0)
            {
                Console.WriteLine($"Ingrese un nuevo {nombre} para el empleado con id:{id}\nRecuerde que este campo admite {cant} caracteres.");
                var = Console.ReadLine();
                if(var.Length <= cant && var != "") sale++;
                else Console.WriteLine($"El campo debe estar completo y no debe contener mas de {cant} caracteres.");
            }    
            return var;
        }

        public static string UpdateCliente(string nombre, string id, int cant)
        {
            string var = "";
            int sale = 0;
            while (sale == 0)
            {
                Console.WriteLine($"Ingrese un nuevo {nombre} para el cliente con id:{id}\nRecuerde que este campo admite {cant} caracteres.");
                var = Console.ReadLine();
                if (var.Length <= cant && var != "") sale++;
                else Console.WriteLine($"El campo debe estar completo y no debe contener mas de {cant} caracteres.");
            }
            return var;
        }
    }
}
