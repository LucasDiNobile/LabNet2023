using Lab.Practica6.Entities;
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
            var employeeToDelete = context.Employee.Find(entity.EmployeeID);
            
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
