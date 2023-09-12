using Lab.Practica6.Data;

namespace Lab.Practica6.Logic
{
    public class BaseLogic 
    {
        protected readonly NorthwindContext context;

        public BaseLogic()
        {
            context = new NorthwindContext();
        }
      
        
        
    }
}
