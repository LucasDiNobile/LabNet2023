using Lab.Practica4.EF.Entities;
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
            var list2 = context.Products
                    .Where(p => p.UnitsInStock == 0)
                    .ToList<object>();

            return list2;
        }

        public List<object> ProductStock3()
        {
            var list3 = context.Products
                    .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3)
                    .ToList<object>();

            return list3;
        }

        public Product Id789()
        {
            try
            {
                var list5 = (from Products in context.Products
                        where Products.ProductID == 789
                        select Products).First();
            }
            catch (Exception ex)
            {
                return null;

            }
            return list5;
            
        }

        public List<object> OrderByName()
        {
            var list9 = context.Products
                    .OrderBy(e => e.ProductName)
                    .ToList<object>();

            return list9;
        }

        public List<object> OrderByStockD()
        {
            var list10 = context.Products
                    .OrderByDescending(e => e.UnitsInStock)
                    .ToList<object>();

            return list10;
        }

        public List<object> ProductCategory()
        {
            var list11 = context.Products
                    .Join(
                        context.Categories,
                        product => product.CategoryID,
                        category => category.CategoryID,
                        (product, category) => new
                        {
                            categoryId = category.CategoryID,
                            categoryname = category.CategoryName,
                            productName = product.ProductName,
                        })
                .ToList<object>();

            return list11;
        }

        public Product FirstProduct()
        {
            var list12 = context.Products.First();

            return list12;
        }


    }
}