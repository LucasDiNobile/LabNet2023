using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    public class ExcepcionPersonalizada : Exception
    {
        public ExcepcionPersonalizada() : base("Mensaje de error de la Excepcion Personalizada")
        {

        }
    }
}
