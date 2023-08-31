using Lab.Practica3.EF.Data;
using Lab.Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica3.EF.Logic
{
    public class EmployeeLogic : BaseLogic, ILogic<Employee>
    {

        public EmployeeLogic() : base() { }


        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public void Delete(Employee entity)
        {
            var employeeToDelete = context.Employees.Find(entity.EmployeeID);

            context.Employees.Remove(employeeToDelete);

            context.SaveChanges();
        }
        public void Insert(Employee entity)
        {
            context.Employees.Add(entity);

            context.SaveChanges();
        }
        public void Update(Employee entity)
        {
            var employeeUpdate = context.Employees.Find(entity.EmployeeID);

            employeeUpdate.LastName = entity.LastName;
            employeeUpdate.FirstName = entity.FirstName;
            employeeUpdate.City = entity.City;
            employeeUpdate.PostalCode = entity.PostalCode;
            employeeUpdate.Country = entity.Country;    

            context.SaveChanges();
        }
    }
}
