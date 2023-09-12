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
