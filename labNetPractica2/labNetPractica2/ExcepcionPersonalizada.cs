using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    //Ejercicio 4
    public class ExcepcionPersonalizada : Exception
    {
        private string mensajePerso;
        public ExcepcionPersonalizada(string mensajePerso) : base("Este el mensaje de error de la Excepcion Personalizada")
        {
            this.mensajePerso = mensajePerso;
        }

        public string MensajePerso()
        {
            return $"Mensaje personalizado de la excepcion: {mensajePerso}";
        }
    }
}
