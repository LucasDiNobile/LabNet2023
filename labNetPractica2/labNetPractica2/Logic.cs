using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    public static class Logic
    {
        //Ejercicio 3
        public static int TiraExcepcion()
        {
            string mensaje = "hola";
            int mensaje2;
                     
            mensaje2 = int.Parse(mensaje);
            return mensaje2;                           
        }

        //Ejercicio 4

        public static void TrowExcepcionPersonalizada()
        {
            throw new ExcepcionPersonalizada("Este es el mensaje personalizado que toma la excepcion.");
        }
    }
}
