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
using System.Data.Entity;

namespace Lab.Practica4.EF.Logic
{
    public class CustomerLogic : BaseLogic
    {

        public List<object> GetId()
        {
            var getId = (
                    from Customers in context.Customers
                    select Customers
                ).ToList<object>();

            return getId;
        }

        public Customer CustomerToPrint(string id)
        {
            var list = context.Customers.Where(e => e.CustomerID.Equals(id)).FirstOrDefault();

            return list;
        }

        public List<object> RegionWA()
        {
            var list4 = (
                    from Customers in context.Customers
                    where Customers.Region == "WA"
                    select Customers
                ).ToList<object>();


            return list4;
        }

        public List<object> CustomerTable() 
        {
            var query6 = (from Customers in context.Customers
                          select Customers
                    ).ToList<object>();

            return query6;
        }


        public List<object> CustomerJoin()
        {
            var list7 = (
                    from Customers in context.Customers
                    join Orders in context.Orders on Customers.CustomerID equals Orders.CustomerID
                    where Customers.Region == "WA" && Orders.OrderDate > new DateTime(1997, 1, 1)
                    select new
                    {
                        customerName = Customers.CompanyName,
                        regionWA = Customers.Region,
                        orderDate = Orders.OrderDate
                    }

                ).Distinct().ToList<object>();

            return list7;
        }

        public List<object> FirstThree()
        {
            var query8 = context.Customers
                    .Where(c => c.Region == "WA ")
                    .Take(3)
                    .ToList<object>();

            return query8;
        }

        public List<object> CustomersOrders()
        {
            var list13 = from Customers in context.Customers
                         join Orders in context.Orders on Customers.CustomerID equals Orders.CustomerID into customerOrders
                         select new
                         {
                             customerID = Customers.CustomerID,
                             orderID = customerOrders.Count()
                         };
                                                             
            return list13.ToList<object>();
        }
    }
}