using System;

namespace Lab.Practica6.Logic
{
    public class MaxLengthExcepcion : Exception
    {
        public MaxLengthExcepcion() : base("Usted excedio la cantidad maxima de caracteres.")
        {
        }
    }
}
