﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica6.Logic
{
    public class EncuentraIdExcepcion : Exception
    {
        public EncuentraIdExcepcion() : base("Genial! Encontramos el empleado que desea modificar.")
        {
        }
    }
}
