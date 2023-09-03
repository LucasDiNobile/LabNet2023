using System;
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
            CustomerLogic customerLogic =  new CustomerLogic();
            ProductLogic productLogic =  new ProductLogic();
            CategoryLogic categoryLogic = new CategoryLogic();  

            int elegirEjercicio = 0;
            bool nuncaSale = true;

            while (nuncaSale)
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
                    "8.\n" +
                    "9.Products ordenados por nombre\n" +
                    "10.Products ordenados por Units In Stock de manera descendiente\n" +
                    "11.Cate\n" +
                    "12.Mostrar primer elemento de lista productos" +
                    "0.Salir" +
                    "\n5 7 8 11 12 por revisar\n");

                Console.ForegroundColor = ConsoleColor.White;
                elegirEjercicio = int.Parse(Console.ReadLine());

                switch (elegirEjercicio)
                {
                    case 1:
                        var customerAll = customerLogic.CustomerTable();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Esta es la lista Customers");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Customer customer in customerAll)
                        {
                            
                            Console.WriteLine($"{customer.CustomerID} - " +
                                $"{customer.CompanyName} - " +
                                $"{customer.ContactTitle} - " +
                                $"{customer.Address} - " +
                                $"{customer.City} - " +
                                $"{customer.Region} - " +
                                $"{customer.PostalCode} - " +
                                $"{customer.Country} -  ");
                        }
                        break;
                    case 2:
                        var productInStock = productLogic.ProductNoStock();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Estos son los productos sin stock");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Product product in productInStock)
                        {
                            Console.WriteLine($"{product.ProductID} - {product.ProductName}");
                        }
                        break;
                    case 3:
                        var productInStock3 = productLogic.ProductStock3();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Estos son los productos que disponen de stock y cuestan mas de 3 por unidad");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Product product in productInStock3)
                        {
                            Console.WriteLine($"{product.ProductID} - {product.ProductName}");
                        }
                        break;
                    case 4:
                        var RegionWA = customerLogic.RegionWA();

                        Console.ForegroundColor = ConsoleColor.Red;
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

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Estos son los Customers en mayusculas y en minusculas");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Customer customer in customerUpperLower)
                        {
                            Console.WriteLine($"{customer.CompanyName.ToUpper()} - {customer.CompanyName.ToLower()}");
                        }
                        break;
                    case 7:
                        var customerJoin = customerLogic.CustomerJoin();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Este es el join entre Customers y Orders");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Customer customer in customerJoin)
                        {
                            Console.WriteLine($"{customer.CustomerID} - {customer.CompanyName} - {customer.Region}");
                        }
                        break;
                    case 8://TODO
                        break;
                    case 9:
                        var orderByName = productLogic.OrderByName();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Estos son los Customers ordenados por nombre");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Product product in orderByName)
                        {
                            Console.WriteLine($"{product.ProductName} - {product.UnitPrice} - {product.UnitsInStock}");
                        }
                        break;
                    case 10:
                        var orderByStockD = productLogic.OrderByStockD();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Estos son los Customers ordenados por Units In Stock de manera descendiente");
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Product product in orderByStockD)
                        {
                            Console.WriteLine($"{product.UnitsInStock} - {product.ProductName}");
                        }
                        break;
                    case 11:
                        var categoryProduc = categoryLogic.ProductCategory();

                        foreach (Category category in categoryProduc)
                        {
                            Console.WriteLine($"{category.CategoryID} - {category.CategoryName}");
                        }
                        break;  
                    case 12:
                        
                        break;

                    case 0:
                        Console.WriteLine("Salio con exito");
                        nuncaSale = false;
                        break;
                    default:
                        Console.WriteLine("Numero invalido");
                        break;
                }
            }


            

            

            Console.ReadKey();
        }
    }
}
