using Lab.Practica4.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica4.EF.Logic
{
    public class CategoryLogic : BaseLogic
    {
        public List<object> ProductCategory()
        {
            List<object> list11 = (
                from Categories in context.Categories
                join Products in context.Products on Categories.CategoryID equals Products.CategoryID
                select Categories
            ).ToList<object>();
            
            return list11;
        }
    }
}
