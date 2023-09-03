using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica4.EF.Logic
{
    public class ProductLogic : BaseLogic
    {
        public List<object> ProductNoStock()
        {
            List<object> list2 = context.Products.Where(p => p.UnitsInStock == 0).ToList<object>();

            return list2;  
        }

        public List<object> ProductStock3() 
        {
            List<object> list3 = context.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3).ToList<object>();

            return list3;
        }

        public List<object> OrderByName() 
        { 
            List<object> list9 = context.Products.OrderBy(e => e.ProductName).ToList<object>(); 

            return list9;
        }

        public List<object> OrderByStockD()
        {
            List<object> list10 = context.Products.OrderByDescending(e => e.UnitsInStock).ToList<object>();

            return list10;
        }

        public List<object> FirstProduct()
        {
            List<object> list12 = (
                from Products in context.Products
                select Products
            ).ToList<object>();

            return list12;
        }
    }
}
