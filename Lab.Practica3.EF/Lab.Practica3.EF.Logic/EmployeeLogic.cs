using Lab.Practica6.Entities;
using System;
using System.Collections.Generic;
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
            if (entity.EmployeeID == 0)
            {
                throw new Exception("Los campos no pueden ser nulos");
            }

            Employee employeeToDelete = context.Employee.Find(entity.EmployeeID);

            context.Employee.Remove(employeeToDelete);

            context.SaveChanges();                                     
        }


        public void Insert(Employee entity)
        {
            if (entity.FirstName == null || entity.LastName == null)
            {
                throw new Exception("Los campos no pueden ser nulos");
            }

            context.Employee.Add(entity);
   
            context.SaveChanges();
        }

        public void Update(Employee entity)
        {
            if (entity.FirstName == null || entity.LastName == null)
            {
                throw new Exception("Los campos no pueden ser nulos");
            }

            var employeeUpdate = context.Employee.Find(entity.EmployeeID);

            employeeUpdate.LastName = entity.LastName;
            employeeUpdate.FirstName = entity.FirstName;
   
            context.SaveChanges();
        }
    }
}
