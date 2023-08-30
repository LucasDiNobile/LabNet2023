using Lab.Practica3.EF.Logic;
using Lab.Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Runtime.CompilerServices;

namespace Lab.Practica3.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            int tablaDeseada = 0, accionDeseadaCliente = 0, accionDeseadaEmpleado = 0;
            EmployeeLogic employeeLogic = new EmployeeLogic();

            while (continuar) 
            {
                try
                {
                    Console.WriteLine("Que tabla desea utilizar?\n 1.Clientes\n 2.Empleados\n 0.Salir de la aplicacion");
                    tablaDeseada = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                switch (tablaDeseada)
                {   case 1:
                        Console.WriteLine("Ustedes elijio la tabla de clientes, desea:\n" +
                            "1.Ver tabla de clientes\n" +
                            "2.Insertar un nuevo cliente\n" +
                            "3.Modificar un cliente\n" +
                            "4.Eliminar un cliente\n" +
                            "0.Salir de la aplicacion");
                        accionDeseadaCliente = int.Parse(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Ustedes elijio la tabla de empleados, desea:\n" +
                            "1.Ver tabla de empleados\n" +
                            "2.Insertar un nuevo empleado\n" +
                            "3.Modificar un empleado\n" +
                            "4.Eliminar un empleado\n" +
                            "0.Salir de la aplicacion");
                        accionDeseadaEmpleado = int.Parse(Console.ReadLine());
                        break;
                    case 0:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("el numero no es valido, vuelva a intentarlo");
                        break;
                }

                switch (accionDeseadaCliente)
                {
                    case 1:
                        break;
                    case 2:
                        break; 
                    case 3:
                        break;
                    case 4:
                        break;
                    case 0:
                        break;
                }

                switch (accionDeseadaEmpleado)
                {
                    case 1:
                        foreach (Employee employee in employeeLogic.GetAll())
                            {
                              Console.WriteLine($"{employee.FirstName} {employee.LastName} from {employee.Country }, was hired on {employee.HireDate}\n");
                            }
                        break;
                    case 2:  //TODO                                                                                              
                        employeeLogic.Insert(new Employee
                        {
                          FirstName = Console.ReadLine(),
                          LastName = "Di Nobile"
                        });
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 0:
                        break;
                }


            }

            
            foreach (var item in employeeLogic.GetAll())
            {
                Console.WriteLine($"{item.EmployeeID} {item.FirstName} {item.LastName} {item.HireDate}");
            }

            Console.ReadKey();
        }
    }
}


//Muestra tabla de empleados
//EmployeeLogic employeeLogic = new EmployeeLogic();

//foreach (Employee employee in employeeLogic.GetAll())
//{
//  Console.WriteLine($"{employee.FirstName} {employee.LastName} from {employee.Country }, was hired on {employee.HireDate}\n");
//}


//Prueba Insert

//employeeLogic.Insert(new Employee
//{
//  FirstName = "Lucas",
//  LastName = "Di Nobile"
//});

//foreach (var item in employeeLogic.GetAll())
//{
//  Console.WriteLine($"{item.EmployeeID} {item.FirstName} {item.LastName} {item.HireDate}");
//}


// Prueba Delete
//employeeLogic.Delete(new Employee { EmployeeID = 9 });


// Prueba Update

//employeeLogic.Update(new Employee
//{
//   LastName = "Cruz",
//    FirstName = "Juan",         
//     EmployeeID = 2,
//});