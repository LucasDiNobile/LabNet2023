using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica3.EF.Logic
{
    public class MaxNumExepcion : Exception
    {
        public MaxNumExepcion() : base("El numero que usted ingreso se encuentra fuera de los limites.")
        {
        }

       
        
      
    }
}
