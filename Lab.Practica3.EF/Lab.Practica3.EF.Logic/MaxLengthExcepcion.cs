using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica6.Logic
{
    public class MaxLengthExcepcion : Exception
    {
        public MaxLengthExcepcion() : base("Usted excedio la cantidad maxima de caracteres.")
        {
        }
    }
}
