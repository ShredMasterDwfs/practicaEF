using practica.EF.Data;
using practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica.EF.Logic
{
    public class CustomersLogic : BaseLogic
    {
        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }

        public void Add(Customers newCustomers)
        {
            context.Customers.Add(newCustomers);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var customerToDelete = context.Customers.Find(id);
            context.Customers.Remove(customerToDelete);
            context.SaveChanges();
        }

        public void Update(Customers customers)
        {
            var customersUpdate = context.Customers.Find(customers.CustomerID);
            customersUpdate.ContactName = customers.ContactName;
            context.SaveChanges();
        }
    }
}
