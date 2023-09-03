using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Lab.Practica4.EF.Entities;
using Lab.Practica4.EF.Data;
using System.Runtime.ExceptionServices;

namespace Lab.Practica4.EF.Logic
{
    public class CustomerLogic : BaseLogic
    {
        public List<object> CustomerTable()
        {
             List<object> list = (
                from Customers in context.Customers
                orderby Customers.CustomerID
                select Customers
            ).ToList<object>();
            w
            return list;
        }

        public List<object> RegionWA()
        {
            List<object> list4 = (
                from Customers in context.Customers
                where Customers.Region == "WA"
                select Customers
            ).ToList<object>();


            return list4;
        }

        public List<object> CustomerJoin()
        {

            List<object> list7 = new List<object>();

            var query7 = from Customers in context.Customers
                         join Orders in context.Orders on Customers.CustomerID equals Orders.CustomerID
                         where Orders.OrderDate > new DateTime(1997, 1, 1)
                         group Customers by Customers.Region == "WA";


            foreach (var item in query7)
            {
                list7.Add(item);
            }
            return list7;
        }

       
    }
}
