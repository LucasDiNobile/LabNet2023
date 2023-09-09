using Lab.Practica6.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;

namespace Lab.Practica6.Logic
{
    public class EmployeeLogic : BaseLogic, ILogic<Employee>
    {
        public EmployeeLogic() : base() { }

        public List<Employee> GetAll()
        {
            return context.Employee.ToList();
        }

        public void Delete(Employee entity)
        { 
            var employeeToDelete = context.Employee.Find(entity.EmployeeID);

            List<Territory> territoryList = new List<Territory>(entity.Territories);

            foreach (var item in territoryList)
            {
                context.Territories.Remove(item);
            }

            List<Order> orderList = new List<Order>(entity.Orders);

            foreach (var ord in orderList)
            {
                List<Order_Detail> ordersDetail = new List<Order_Detail>(ord.Order_Details);
                foreach (var orderD in ordersDetail)
                {
                    context.Order_Details.Remove(orderD);
                }
                context.Orders.Remove(ord);
            }
            context.Employee.Remove(employeeToDelete);  
            
            context.SaveChanges();
        }
        public void Insert(Employee entity)
        {
            context.Employee.Add(entity);
                                   
            context.SaveChanges();
        }
        public void Update(Employee entity)
        {              
            var employeeUpdate = context.Employee.Find(entity.EmployeeID);

            employeeUpdate.LastName = entity.LastName;
            employeeUpdate.FirstName = entity.FirstName;
   
            context.SaveChanges();
        }
    }
}
