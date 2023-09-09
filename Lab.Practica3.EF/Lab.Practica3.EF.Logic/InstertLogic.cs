using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica6.Logic
{
    public class InstertLogic
    {
        public static string InsterCheck(string varLength, int cant)
        {
            if (varLength.Length <= cant && varLength != "")
            {
                return varLength;
            }
                     
            return null;
        }       
    }
}
