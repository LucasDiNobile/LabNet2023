using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica6.Logic
{
    public class MaxNumExcepcion : Exception
    {
        public MaxNumExcepcion() : base("Usted supero el numero maximo de caracteres.")
        {
        }
    }
}
