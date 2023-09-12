using Lab.Practica6.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Practica6.Logic
{
    public class CustomerLogic : BaseLogic, ILogic<Customer>
    {
        public CustomerLogic() : base() { }

        public void Delete(Customer entity)
        {
            var customerToDelete = context.Customers.Find(entity.CustomerID);

            context.Customers.Remove(customerToDelete);

            context.SaveChanges();
        }

        public List<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public void Insert(Customer entity)
        {
            context.Customers.Add(entity);

            context.SaveChanges();
        }

        public void Update(Customer entity)
        {
            var customerUpdate = context.Customers.Find(entity.CustomerID);

            customerUpdate.CompanyName = entity.CompanyName;
            customerUpdate.ContactName = entity.ContactName;
            customerUpdate.City = entity.City;
            customerUpdate.PostalCode = entity.PostalCode;
            customerUpdate.Country = entity.Country;

            context.SaveChanges();
        }
    }
}
