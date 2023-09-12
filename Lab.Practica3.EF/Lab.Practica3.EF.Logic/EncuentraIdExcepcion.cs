using System;

namespace Lab.Practica6.Logic
{
    public class EncuentraIdExcepcion : Exception
    {
        public EncuentraIdExcepcion() : base("Genial! Encontramos el empleado que desea modificar.")
        {
        }
    }
}
