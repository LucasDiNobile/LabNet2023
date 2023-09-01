using Lab.Practica3.EF.Logic;
using Lab.Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Reflection;

namespace Lab.Practica3.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            bool continuar = true;            
            EmployeeLogic employeeLogic = new EmployeeLogic();
            CustomerLogic customerLogic = new CustomerLogic();

            while (continuar) 
            {
                int tablaDeseada = 3, accionDeseadaCliente = 5, accionDeseadaEmpleado = 5;
                
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
                {
                    case 1:
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
                        foreach (Customer customer in customerLogic.GetAll())
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} {customer.CompanyName} - {customer.City} - {customer.Country} - {customer.PostalCode}");
                        }
                        break;
                    case 2://TODO: agregar validaciones
                        int agregar = 8, salirInsertC = 1;
                        string nombre = "", nombreContacto = "", ciudad = "", pais = "", codigoPostal = "", id = "";

                        Console.WriteLine("Que campo desea agregarle al cliente?");

                        while (salirInsertC == 1)
                        {
                            try
                            {
                                Console.WriteLine(
                                    "1.Id\n" +
                                    "2.Nombre\n" +
                                    "3.Nombre de contacto\n" +
                                    "4.Ciudad\n" +
                                    "5.Codigo postal\n" +
                                    "6.Pais\n" +
                                    "7.Insertar empleado\n" +
                                    "0.Salir");
                                agregar = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("creo que ingreso una letra, vuelva a intentarlo");
                            }

                            switch (agregar)
                            {
                                case 1:                              
                                    id = Console.ReadLine(); 
                                    
                                    Console.WriteLine($"Se agregara el id: {id} a la tabla.");
                                    break;
                                case 2:
                                    nombre = Console.ReadLine();
                                    Console.WriteLine($"Se ingresara el nombre: {nombre} a la tabla.");
                                    break;
                                case 3:
                                    nombreContacto = Console.ReadLine();
                                    Console.WriteLine($"Se ingresara el apellido: {nombreContacto} a la tabla.");
                                    break;
                                case 4:
                                    ciudad = Console.ReadLine();
                                    Console.WriteLine($"Se ingresara la ciudad: {ciudad} a la tabla.");

                                    break;
                                case 5:
                                    codigoPostal = Console.ReadLine();
                                    Console.WriteLine($"Se ingresara el codigo postal: {codigoPostal} a la tabla.");

                                    break;
                                case 6:
                                    pais = Console.ReadLine();
                                    Console.WriteLine($"Se ingresara el pais: {pais} a la tabla.");
                                    break;
                                case 7:
                                    salirInsertC = 0;
                                    break;
                                case 0:
                                    salirInsertC = 0;
                                    continuar = false;
                                    break;
                                default:
                                    Console.WriteLine("El numero no es valido, vuelva a intentarlo");
                                    break;
                            }
                        }
                        customerLogic.Insert(new Customer
                        {
                            CustomerID = id,
                            CompanyName = nombre,
                            ContactName = nombreContacto,
                            City = ciudad,
                            PostalCode = codigoPostal,
                            Country = pais,
                        });

                        foreach (Customer customer in customerLogic.GetAll())
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} {customer.CompanyName} - {customer.City} - {customer.Country} - {customer.PostalCode}");
                        }

                        Console.WriteLine("Genial! El cliente se inserto con exito");
                        break; 
                    case 3:
                        
                        string nuevoCompanyName = "", nuevoContactName = "", NuevaCiudad = "", nuevoCodigoPostal = "", nuevoPaisC = "", clienteModificar = "";

                        foreach (Customer customer in customerLogic.GetAll())
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} {customer.CompanyName} - {customer.City} - {customer.Country} - {customer.PostalCode}");
                        }

                        Console.WriteLine("Indique el Id del cliente que desa modificar");

                        clienteModificar = Console.ReadLine();                                
                        

                        Console.WriteLine($"Ingrese un nuevo nombre para la compañia con id:{clienteModificar}");
                        nuevoCompanyName = Console.ReadLine();

                        Console.WriteLine($"Ingrese un nuevo nombre de contacto para la compañiacon id:{clienteModificar}");
                        nuevoContactName = Console.ReadLine();

                        Console.WriteLine($"Ingrese una nueva ciudad para la compañia con id:{clienteModificar}");
                        NuevaCiudad = Console.ReadLine();

                        Console.WriteLine($"Ingrese un nuevo codigo postal para la compañia con id:{clienteModificar}");
                        nuevoCodigoPostal = Console.ReadLine();

                        Console.WriteLine($"Ingrese un nuevo pais para la compañia con id:{clienteModificar}");
                        nuevoPaisC = Console.ReadLine();

                        customerLogic.Update(new Customer
                        {
                            CustomerID = clienteModificar,
                            CompanyName = nuevoCompanyName,
                            ContactName = nuevoContactName,
                            City = NuevaCiudad,
                            PostalCode = nuevoCodigoPostal,
                            Country = nuevoPaisC,

                        }); ;

                        Console.WriteLine($"Genial! El cliente con id:{clienteModificar} se actualizo.");

                        foreach (Customer customer in customerLogic.GetAll())
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} {customer.CompanyName} - {customer.City} - {customer.Country} - {customer.PostalCode}");
                        }
                        break;
                    case 4:
                        string borrarCliente;

                        foreach (Customer customer in customerLogic.GetAll())
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} {customer.CompanyName} - {customer.City} - {customer.Country} - {customer.PostalCode}");
                        }

                        Console.WriteLine("Ingrese un Id para eliminarlo.");
                                                   
                        borrarCliente = Console.ReadLine();
                                                                                 
                        customerLogic.Delete(new Customer { CustomerID = borrarCliente });

                        Console.WriteLine($"El cliente con el id {borrarCliente} a sido eliminado correctamente.");

                        foreach (Customer customer in customerLogic.GetAll())
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} {customer.CompanyName} - {customer.City} - {customer.Country} - {customer.PostalCode}");
                        }
                        break;
                    case 0:
                        continuar = false;
                        break;
                }
                
                switch (accionDeseadaEmpleado)
                {
                    case 1:
                        foreach (Employee employee in employeeLogic.GetAll())
                        {
                            Console.WriteLine($"{employee.EmployeeID} - {employee.FirstName} {employee.LastName} - {employee.City} - {employee.Country} - {employee.PostalCode}");
                        }
                        break;
                    case 2://TODO: agregar validaciones
                        int agregar = 0, salirInsert = 1, id = 0;
                        string nombre = "", apellido = "", ciudad = "", pais = "", codigoPostal = "";
                        
                        Console.WriteLine("Que campo desea agregarle al empleado?");

                        while(salirInsert == 1)
                        {
                            try
                            {
                                Console.WriteLine(
                                    "1.Id\n" +
                                    "2.Nombre\n" +
                                    "3.Apellido\n" +
                                    "4.Ciudad\n" +                                                                                                 
                                    "5.Codigo postal\n" +
                                    "6.Pais\n" +
                                    "7.Insertar empleado\n" +                                    
                                    "0.Salir");
                                agregar = int.Parse(Console.ReadLine());
                            }
                            catch(FormatException)
                            {
                                Console.WriteLine("creo que ingreso una letra, vuelva a intentarlo");
                            }
                            
                            switch (agregar)
                            {
                                case 1:
                                    try
                                    {
                                        id = int.Parse(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Debe ingresar un numer, intentelo de nuevo.");
                                        break;
                                    }
                                    Console.WriteLine($"Se agregara el id: {id} a la tabla.");
                                    break;
                                case 2:
                                    nombre = Console.ReadLine();
                                    Console.WriteLine($"Se ingresara el nombre: {nombre} a la tabla.");
                                    break;
                                case 3:
                                    apellido = Console.ReadLine();
                                    Console.WriteLine($"Se ingresara el apellido: {apellido} a la tabla.");
                                    break;
                                case 4:
                                    ciudad = Console.ReadLine();
                                    Console.WriteLine($"Se ingresara la ciudad: {ciudad} a la tabla.");

                                    break;
                                case 5:
                                    codigoPostal = Console.ReadLine();
                                    Console.WriteLine($"Se ingresara el codigo postal: {codigoPostal} a la tabla.");

                                    break;
                                case 6:
                                    pais = Console.ReadLine();
                                    Console.WriteLine($"Se ingresara el pais: {pais} a la tabla.");
                                    break;
                                case 7:
                                    salirInsert = 0;
                                    break;
                                case 0:
                                    salirInsert = 0;
                                    continuar = false;
                                    break;
                                default:
                                    Console.WriteLine("El numero no es valido, vuelva a intentarlo");
                                    break;                                
                            }
                        }
                        employeeLogic.Insert(new Employee
                        {
                            EmployeeID = id,
                            FirstName = nombre,
                            LastName = apellido,
                            City = ciudad,
                            PostalCode = codigoPostal,
                            Country = pais,
                        });

                        foreach (Employee employee in employeeLogic.GetAll())
                        {
                            Console.WriteLine($"{employee.EmployeeID} - {employee.FirstName} {employee.LastName} - {employee.City} - {employee.Country} - {employee.PostalCode}");
                        }

                        Console.WriteLine("Genial! El empleado se agrego con exito");

                        break;
                    case 3:
                        int empleadoModificar = 0, salirModificar = 1;
                        string nuevoNombre = "", nuevoApellido = "", NuevaCity = "", nuevoPostalCode = "", nuevoPais = "";

                        foreach (Employee employee in employeeLogic.GetAll())
                        {
                            Console.WriteLine($"{employee.EmployeeID} - {employee.FirstName} {employee.LastName} - {employee.City} - {employee.Country} - {employee.PostalCode}");
                        }

                        Console.WriteLine("Indique la Id del empleado que desa modificar");

                        while (salirModificar == 1)
                        {
                            try
                            {
                                empleadoModificar = int.Parse(Console.ReadLine());
                                salirModificar = 0;
                            }
                            catch(Exception) 
                            {
                                Console.WriteLine("usted ingreso una letro o una Id ivalida, por favor vuelva a intentarlo.");
                            }

                        }

                        Console.WriteLine($"Ingrese un nuevo nombre para el empleado con id:{empleadoModificar}");
                        nuevoNombre = Console.ReadLine();

                        Console.WriteLine($"Ingrese un nuevo apellido para el empleado con id:{empleadoModificar}");
                        nuevoApellido = Console.ReadLine();

                        Console.WriteLine($"Ingrese una nueva ciudad para el empleado con id:{empleadoModificar}");
                        NuevaCity = Console.ReadLine();

                        Console.WriteLine($"Ingrese un nuevo codigo postal para el empleado con id:{empleadoModificar}");
                        nuevoPostalCode = Console.ReadLine();

                        Console.WriteLine($"Ingrese un nuevo pais para el empleado con id:{empleadoModificar}");
                        nuevoPais = Console.ReadLine();

                        employeeLogic.Update(new Employee
                        {
                            EmployeeID = empleadoModificar,
                            LastName = nuevoApellido,
                            FirstName = nuevoNombre,
                            City = NuevaCity,
                            PostalCode = nuevoPostalCode,
                            Country = nuevoPais,

                        }); ;

                        Console.WriteLine($"Genial! El empleado con id:{empleadoModificar} se actualizo.");

                        foreach (Employee employee in employeeLogic.GetAll())
                        {
                            Console.WriteLine($"{employee.EmployeeID} - {employee.FirstName} {employee.LastName} - {employee.City} - {employee.Country} - {employee.PostalCode}");
                        }

                        break;
                    case 4:
                        int borrarEmpleado = 0, salirDelete = 1;

                        foreach (Employee employee in employeeLogic.GetAll())
                        {
                            Console.WriteLine($"{employee.EmployeeID} - {employee.FirstName} {employee.LastName} - {employee.City} - {employee.Country} - {employee.PostalCode}");
                        }

                        Console.WriteLine("Ingrese un numero de Id para eliminarlo.");
                        while (salirDelete == 1)
                        {
                            try
                            {             
                                borrarEmpleado = int.Parse(Console.ReadLine());
                                salirDelete = 0;
                            }
                            catch (Exception) 
                            {
                                Console.WriteLine("Usted ingreso una letra o una Id invalida, por favor vuelva a intentarlo.");
                            }
                           
                        }
                        employeeLogic.Delete(new Employee { EmployeeID = borrarEmpleado });

                        Console.WriteLine($"El empleado con el id {borrarEmpleado} a sido eliminado correctamente.");

                        foreach (Employee employee in employeeLogic.GetAll())
                        {
                            Console.WriteLine($"{employee.EmployeeID} - {employee.FirstName} {employee.LastName} - {employee.City} - {employee.Country} - {employee.PostalCode}");
                        }
                        break;  
                    case 0:
                        continuar = false;
                        break;
                }
            }                       
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