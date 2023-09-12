using System;

namespace Lab.Practica6.Logic
{
    public class MaxNumExcepcion : Exception
    {
        public MaxNumExcepcion() : base("Usted supero el numero maximo de caracteres.")
        {
        }
    }
}
