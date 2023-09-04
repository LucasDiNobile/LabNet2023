using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Lab.Practica4.EF.Entities;
using Lab.Practica4.EF.Logic;
using static System.Net.WebRequestMethods;

namespace Lab.Practica4.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerLogic customerLogic = new CustomerLogic();
            ProductLogic productLogic = new ProductLogic();

            int elegirEjercicio = 0;
            bool boolMain = true;

            while (boolMain)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nSeleccione el ejercicio que desea ver:\n" +
                        "1.Mostrar tabla Customers\n" +
                        "2.Mostrar Products sin stock\n" +
                        "3.Mostrar Products que dispones de stock y cuestan mas de 3\n" +
                        "4.Mostrar Customers de la Region WA\n" +
                        "5.\n" +
                        "6.Mostar Customers en mayusculas y en minusculas\n" +
                        "7.Join entre Customer y Order \n" +
                        "8.Mostrar los tres primeros Customers de la Region WA\n" +
                        "9.Products ordenados por nombre\n" +
                        "10.Products ordenados por Units In Stock de manera descendiente\n" +
                        "11.Mostrar las distintas categorías asociadas a los productos\n" +
                        "12.Mostrar primer elemento de lista productos\n" +
                        "0.Salir");

                    Console.ForegroundColor = ConsoleColor.White;
                    elegirEjercicio = int.Parse(Console.ReadLine());
                }
                catch(Exception)
                {
                    //En este caso utilizo Exception en vez de FormatException para controlar tambien el tamaño del int.
                }

                switch (elegirEjercicio)
                {
                    case 1:
                        string id = "";
                        bool ej1 = true;
                        foreach (Customer customer in customerLogic.GetId())
                        {
                            Console.WriteLine(customer.CustomerID);
                        }
                        
                        while (ej1)
                        {
                            Console.WriteLine("Indique la Id del Customer que desea mostrar.");

                            id = Console.ReadLine();

                            foreach (Customer customer in customerLogic.GetId())
                            {
                                if (id.ToUpper() == customer.CustomerID.ToUpper())
                                {
                                    ej1 = false;
                                }
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Estos son los datos del Customer con la Id indicada:");
                        Console.ForegroundColor = ConsoleColor.White;

                        var mostrarCustomer = customerLogic.CustomerToPrint(id);
                       
                        Console.WriteLine($"{mostrarCustomer.CustomerID} - " +
                            $"{mostrarCustomer.CompanyName} - " +
                            $"{mostrarCustomer.ContactTitle} - " +
                            $"{mostrarCustomer.Address} - " +
                            $"{mostrarCustomer.City} - " +
                            $"{mostrarCustomer.Region} - " +
                            $"{mostrarCustomer.PostalCode} - " +
                            $"{mostrarCustomer.Country} -  ");
                        
                        break;
                    case 2:
                        var productInStock = productLogic.ProductNoStock();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Estos son los productos sin stock");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Product product in productInStock)
                        {
                            Console.WriteLine($"{product.ProductID} - {product.ProductName}");
                        }
                        break;
                    case 3:
                        var productInStock3 = productLogic.ProductStock3();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Estos son los productos que disponen de stock y cuestan mas de 3 por unidad");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Product product in productInStock3)
                        {
                            Console.WriteLine($"{product.ProductID} - {product.ProductName}");
                        }
                        break;
                    case 4:
                        var RegionWA = customerLogic.RegionWA();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Estos son los clientes de la Region WA");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Customer customer in RegionWA)
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} - {customer.Region}");
                        }
                        break;
                    case 5://TODO

                        break;
                    case 6:
                        var customerUpperLower = customerLogic.CustomerTable();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Estos son los Customers en mayusculas y en minusculas");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Customer customer in customerUpperLower)
                        {
                            Console.WriteLine($"{customer.CompanyName.ToUpper()} - {customer.CompanyName.ToLower()}");
                        }
                        break;
                    case 7:
                        var customerJoin = customerLogic.CustomerJoin();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Este es el join entre Customers y Orders");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (object customer in customerJoin)
                        {
                            Console.WriteLine(customer);
                        }
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Estos son los primeros tres Customers de la Region 'WA':");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Customer customer in customerLogic.FirstThree())
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.CompanyName} - {customer.Region}");
                        }
                        break;
                    case 9:
                        var orderByName = productLogic.OrderByName();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Estos son los Customers ordenados por nombre");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Product product in orderByName)
                        {
                            Console.WriteLine($"{product.ProductName} - {product.UnitPrice} - {product.UnitsInStock}");
                        }
                        break;
                    case 10:
                        var orderByStockD = productLogic.OrderByStockD();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Estos son los Customers ordenados por Units In Stock de manera descendiente");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Product product in orderByStockD)
                        {
                            Console.WriteLine($"{product.UnitsInStock} - {product.ProductName}");
                        }
                        break;
                    case 11:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Estas son las distintas categorías asociadas a los productos:");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (object item in productLogic.ProductCategory())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 12:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Este es el primer objeto de la lista productos:");
                        Console.ForegroundColor = ConsoleColor.White;

                        Product productUno = productLogic.FirstProduct();

                        Console.WriteLine($"{productUno.ProductID} - {productUno.ProductName} - {productUno.UnitPrice}");
                        break;

                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Salio con exito, hasta luego.");
                        Console.ForegroundColor = ConsoleColor.White;
                        boolMain = false;
                        break;
                    default:
                        Console.WriteLine("Usted ingreso una letra o un nuemero invalido, vuelva a intentar.");
                        break;
                }
            }






            Console.ReadKey();
        }
    }
}