using practica.EF.Entities;
using practica.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica.EF.UI
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomersLogic customersLogic = new CustomersLogic();

            foreach  (var item in customersLogic.GetAll())
            {
                Console.WriteLine($"{item.CustomerID}\t{item.CompanyName}\t{item.ContactName}");
            }
            Console.WriteLine();

            // INSERT:
            //customerslogic.add(new customers
            //{
            //    customerid = "lphmx",
            //    companyname = "los pollos hermanos",
            //    country = "méxico"
            //});
            //foreach (var item in customerslogic.getall())
            //{
            //    console.writeline($"{item.customerid}\t{item.companyname}\t{item.country}");
            //}
            //console.writeline();

            // UPDATE:
            //customersLogic.Update(new Customers
            //{
            //    ContactName = "Gustavo Fring",
            //    CustomerID = "LPHMX"
            //});


            // DELETE:
            // customersLogic.Delete("LPHMX");

            foreach (var item in customersLogic.GetAll())
            {
                Console.WriteLine($"{item.CustomerID}\t{item.CompanyName}\t{item.ContactName}");
            }



            Console.ReadLine();
        }
    }
}
