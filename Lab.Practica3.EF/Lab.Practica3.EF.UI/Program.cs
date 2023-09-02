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
using System.Net.Http;

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
                catch (MaxNumExcepcion ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Usted se paso de listo -_-");
                }

                switch (tablaDeseada)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Ustedes eligio la tabla de clientes, desea:\n" +
                            "1.Ver tabla de clientes\n" +
                            "2.Insertar un nuevo cliente\n" +
                            "3.Modificar un cliente\n" +
                            "4.Eliminar un cliente\n" +
                            "0.Salir de la aplicacion");
                            accionDeseadaCliente = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (MaxNumExcepcion)
                        {
                            Console.WriteLine("Usted se paso de listo -_-");
                        }

                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("Ustedes eligio la tabla de empleados, desea:\n" +
                            "1.Ver tabla de empleados\n" +
                            "2.Insertar un nuevo empleado\n" +
                            "3.Modificar un empleado\n" +
                            "4.Eliminar un empleado\n" +
                            "0.Salir de la aplicacion");
                            accionDeseadaEmpleado = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }                        
                        catch (MaxNumExcepcion)
                        {
                            Console.WriteLine("Usted se paso de listo -_-");
                        }

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
                    case 2:
                        int agregar = 8, salirInsertC = 1;
                        string nombre = "", nombreContacto = "", ciudad = "", pais = "", codigoPostal = "", id = "";

                        Console.WriteLine("Que campo desea agregarle al cliente?");

                        while (salirInsertC == 1)
                        {
                            try
                            {
                                Console.WriteLine(
                                    "1.Id (campo obligatorio)\n" +
                                    "2.Nombre de la empresa (campo obligatorio)\n" +
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
                            catch (MaxNumExcepcion)
                            {
                                Console.WriteLine("Usted se paso de listo -_-");
                            }

                            switch (agregar)
                            {
                                case 1:
                                    Console.WriteLine("Tenga en cuenta que el campo 'Id' acepta un maximo de 5 caracteres.");
                                    string nuevaId = Console.ReadLine();
                                    id = InstertLogic.InsterCheck(nuevaId, "'Id'", 10);
                                    Console.WriteLine($"Se ingresara el 'Id': {id} a la tabla.");

                                    break;
                                case 2:
                                    Console.WriteLine("Recuerde que el campo 'Nombre de la Empresa' acepta un maximo de 40 caracteres.");
                                    string nuevoNombre = Console.ReadLine();
                                    nombre = InstertLogic.InsterCheck(nuevoNombre, "'Nombre'", 10);
                                    Console.WriteLine($"Se ingresara el 'nombre': {nombre} a la tabla.");

                                    break;
                                case 3:
                                    Console.WriteLine("Tenga en cuenta que el campo 'Contacto de la Empresa' acepta un maximo de 30 caracteres.");
                                    string nuevoNombreContacto = Console.ReadLine();
                                    nombreContacto = InstertLogic.InsterCheck(nuevoNombreContacto, "'Contacto de la Empresa'", 10);
                                    Console.WriteLine($"Se ingresara el 'Nombre de Contacto': {nombreContacto} a la tabla.");

                                    break;
                                case 4:
                                    Console.WriteLine("Recuerde que el campo 'Ciudad' acepta un maximo de 15 caracteres.");
                                    string nuevaCiudadC = Console.ReadLine();
                                    ciudad = InstertLogic.InsterCheck(nuevaCiudadC, "'Ciudad'", 10);
                                    Console.WriteLine($"Se ingresara la 'Ciudad': {ciudad} a la tabla.");

                                    break;
                                case 5:
                                    Console.WriteLine("Tenga en cuenta que el campo 'Codigo postal' acepta un maximo de 10 caracteres.");
                                    string nuevoCodigoPostalC = Console.ReadLine();
                                    codigoPostal = InstertLogic.InsterCheck(nuevoCodigoPostalC, "'Codigo postal'", 10);
                                    Console.WriteLine($"Se ingresara el 'Codigo Postal': {codigoPostal} a la tabla.");

                                    break;
                                case 6:
                                    Console.WriteLine("Recuerde que el campo 'Pais' acepta un maximo de 15 caracteres.");
                                    string nuevoPais = Console.ReadLine();
                                    pais = InstertLogic.InsterCheck(nuevoPais, "'Pais'", 10);
                                    Console.WriteLine($"Se ingresara el 'Pais': {pais} a la tabla.");

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
                        int salirModificarC = 1;

                        foreach (Customer customer in customerLogic.GetAll())
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} {customer.CompanyName} - {customer.City} - {customer.Country} - {customer.PostalCode}");
                        }

                        Console.WriteLine("Indique el Id del cliente que desa modificar");

                        while (salirModificarC == 1)
                        {
                            try
                            {
                                Console.WriteLine("Tenga en cuenta que debe ingresar una id de un empleado existente, respetando mayusculas y minusculas por favor.");
                                clienteModificar = Console.ReadLine();
                                foreach (Customer customer in customerLogic.GetAll())
                                {
                                    if (clienteModificar == customer.CustomerID)
                                    {
                                        salirModificarC = 0;
                                        throw new EncuentraIdExcepcion();
                                    }
                                }
                            }
                            catch (EncuentraIdExcepcion ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("usted ingreso una letra o una Id ivalida, por favor vuelva a intentarlo.");
                            }

                        }

                        nuevoCompanyName = UpdateLogic.UpdateCliente("'Nombre de la empresa'", clienteModificar, 40);

                        nuevoContactName = UpdateLogic.UpdateCliente("'Contacto de la empresa'", clienteModificar, 30);

                        NuevaCiudad = UpdateLogic.UpdateCliente("'Ciudad'", clienteModificar, 15);

                        nuevoCodigoPostal = UpdateLogic.UpdateCliente("'Codigo Postal'", clienteModificar, 10);

                        nuevoPaisC = UpdateLogic.UpdateCliente("'pais'", clienteModificar, 15);

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
                    case 2:
                        int agregar = 0, salirInsert = 1, id = 0;
                        string nombre = "", apellido = "", ciudad = "", pais = "", codigoPostal = "";
                        
                        Console.WriteLine("Que campo desea agregarle al empleado?");

                        while(salirInsert == 1)
                        {
                                                         
                            try
                            {
                                Console.WriteLine(                                  
                                    "1.Nombre (campo obligatorio)\n" +
                                    "2.Apellido (campo obligatorio)\n" +
                                    "3.Ciudad\n" +
                                    "4.Codigo postal\n" +
                                    "5.Pais\n" +
                                    "6.Insertar empleado\n" +
                                    "0.Salir");
                                agregar = int.Parse(Console.ReadLine());

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("creo que ingreso una letra, vuelva a intentarlo");
                            }                          
                            catch (Exception)
                            {
                                Console.WriteLine("Usted se paso de listo -_-");
                            }

                            switch (agregar)
                            {                              
                                case 1:
                                    Console.WriteLine("Tenga en cuenta que el campo 'Nombre' acepta un maximo de 10 caracteres.");
                                    string nuevoNombreE = Console.ReadLine();
                                    nombre = InstertLogic.InsterCheck(nuevoNombreE, "'Nombre'", 10);
                                    Console.WriteLine($"Se ingresara el nombre: {nombre} a la tabla.");

                                    break;
                                case 2:
                                    Console.WriteLine("Recuerde que el campo 'Apellido' acepta un maximo de 20 caracteres.");
                                    string nuevoApellidoE = Console.ReadLine();
                                    apellido = InstertLogic.InsterCheck(nuevoApellidoE, "'Apellido'", 20);
                                    Console.WriteLine($"Se ingresara el apellido: {apellido} a la tabla.");

                                    break;
                                case 3:
                                    Console.WriteLine("Tenga en cuenta que el campo 'Ciudad' acepta un maximo de 15 caracteres.");
                                    string nuevaCiudadE = Console.ReadLine();
                                    ciudad = InstertLogic.InsterCheck(nuevaCiudadE, "'Ciudad'", 15);
                                    Console.WriteLine($"Se ingresara la ciudad: {ciudad} a la tabla.");

                                    break;
                                case 4:
                                    Console.WriteLine("Recuerde que el campo 'Codigo Postal' acepta un maximo de 10 caracteres.");
                                    string nuevoCodigoE = Console.ReadLine();
                                    codigoPostal = InstertLogic.InsterCheck(nuevoCodigoE, "'Codigo Postal'", 10);
                                    Console.WriteLine($"Se ingresara el Codigo Postal: {codigoPostal} a la tabla.");


                                    break;
                                case 5:
                                    Console.WriteLine("Tenga en cuenta que el campo 'Pais' acepta un maximo de 15 caracteres.");
                                    string nuevoPaisE = Console.ReadLine();
                                    pais = InstertLogic.InsterCheck(nuevoPaisE, "'Pais'", 15);
                                    Console.WriteLine($"Se ingresara el Pais: {pais} a la tabla.");

                                    break;
                                case 6:
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
                        int empleadoModificar = 0, salirModificarE = 1;
                        string nuevoNombre = "", nuevoApellido = "", NuevaCity = "", nuevoPostalCode = "", nuevoPais = "";

                        foreach (Employee employee in employeeLogic.GetAll())
                        {
                            Console.WriteLine($"{employee.EmployeeID} - {employee.FirstName} {employee.LastName} - {employee.City} - {employee.Country} - {employee.PostalCode}");
                        }

                        Console.WriteLine("Indique la Id del empleado que desea modificar");

                        while (salirModificarE == 1)
                        {
                            try
                            {
                                Console.WriteLine("Tenga en cuenta que debe ingresar una id de un empleado existente.");
                                empleadoModificar = int.Parse(Console.ReadLine());

                                foreach (Employee employee in employeeLogic.GetAll())
                                {
                                    if (empleadoModificar == employee.EmployeeID)
                                    {
                                        salirModificarE = 0;
                                        throw new EncuentraIdExcepcion();
                                    }                                                                       
                                }                                
                            }
                            catch(EncuentraIdExcepcion ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch(Exception) 
                            {
                                Console.WriteLine("usted ingreso una letra o una Id invalida, por favor vuelva a intentarlo.");
                            }
                        }

                        nuevoNombre = UpdateLogic.UpdateEmpleado("'Nombre'", empleadoModificar, 10);

                        nuevoApellido = UpdateLogic.UpdateEmpleado("'Apellido'", empleadoModificar, 20);

                        NuevaCity = UpdateLogic.UpdateEmpleado("'Ciudad'", empleadoModificar, 15);

                        nuevoPostalCode = UpdateLogic.UpdateEmpleado("'Codigo Postal'", empleadoModificar, 10);

                        nuevoPais = UpdateLogic.UpdateEmpleado("'Pais'", empleadoModificar, 15);

                        employeeLogic.Update(new Employee
                        {
                            EmployeeID = empleadoModificar,
                            LastName = nuevoApellido,
                            FirstName = nuevoNombre,
                            City = NuevaCity,
                            PostalCode = nuevoPostalCode,
                            Country = nuevoPais,

                        }); ;
                       
                        foreach (Employee employee in employeeLogic.GetAll())
                        {
                            Console.WriteLine($"{employee.EmployeeID} - {employee.FirstName} {employee.LastName} - {employee.City} - {employee.Country} - {employee.PostalCode}");
                        }

                        Console.WriteLine($"Genial! El empleado con id:{empleadoModificar} se actualizo.");

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

                        foreach (Employee employee in employeeLogic.GetAll())
                        {
                            Console.WriteLine($"{employee.EmployeeID} - {employee.FirstName} {employee.LastName} - {employee.City} - {employee.Country} - {employee.PostalCode}");
                        }

                        Console.WriteLine($"El empleado con el id {borrarEmpleado} a sido eliminado correctamente.");
                        break;  
                    case 0:
                        continuar = false;
                        break;
                }
            }                       
        }            
    }
}



