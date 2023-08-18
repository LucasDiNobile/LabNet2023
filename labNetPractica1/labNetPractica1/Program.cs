using System;
using System.Collections.Generic;

namespace labNetPractica1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Transportes> transportes = new List<Transportes>{};

            string transporte;
            int pasajeros, cantOmnibus = 0, cantTaxi = 0, idTaxi = 0, idOmnibus = 0;
            
            for (int i = 0; i <= 10; i++) 
            { 
                Console.WriteLine("Desea viajar en Omnibus o Taxi?");
                transporte = Console.ReadLine();

                while (transporte != "Omnibus" && transporte != "Taxi")
                {
                    Console.WriteLine("Invalido, ingrese por favor Omnibus o Taxi");
                    transporte = Console.ReadLine();
                }


                if (transporte == "Omnibus" && cantOmnibus < 5)
                {
                    cantOmnibus++;
                    idOmnibus++;
                    Console.WriteLine("Cuantos pasajeros viajaran en este transporte?");
                    pasajeros = int.Parse(Console.ReadLine());

                    while (pasajeros < 1 || pasajeros > 100)
                    {
                        Console.WriteLine("Incorrecto, por favor ingrese un numero entre 1 y 100");
                        pasajeros = int.Parse(Console.ReadLine());
                    }
                                        
                    Transportes Omnibus = new Omnibus(pasajeros, idOmnibus);
                    transportes.Add(Omnibus);
                }
                else if (transporte == "Taxi" && cantTaxi < 5)
                {
                    cantTaxi++;
                    idTaxi++;
                    Console.WriteLine("Cuantos pasajeros viajaran en este transporte?");
                    pasajeros = int.Parse(Console.ReadLine());

                    while (pasajeros < 1 || pasajeros > 4)
                    {
                        Console.WriteLine("Incorrecto, por favor ingrese un numero entre 1 y 100");
                        pasajeros = int.Parse(Console.ReadLine());
                    }
                    
                    Transportes Taxi = new Taxi(pasajeros, idTaxi);
                    transportes.Add(Taxi);



                }
                else Console.WriteLine("Transporte no disponible, por favor elija otro.");      
            }

            foreach (var item in transportes)
            {
                Console.WriteLine(item.CantidadPasajeros());
            }
            Console.ReadLine();
        }
    }
}
