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
            ShowUI();
            
            //CustomersLogic customersLogic = new CustomersLogic();

            //foreach (var item in customersLogic.GetAll())
            //{
            //    Console.WriteLine($"{item.CustomerID}\t{item.CompanyName}\t{item.ContactName}");
            //}
            //Console.WriteLine();

            //// INSERT:
            //customersLogic.Insert(new Customers
            //{
            //    CustomerID = "LPHMX",
            //    CompanyName = "Los Pollos Hermanos",
            //    ContactName = "None"
            //});

            //foreach (var item in customersLogic.GetAll())
            //{
            //    Console.WriteLine($"{item.CustomerID}\t{item.CompanyName}\t{item.ContactName}");
            //}

            //Console.WriteLine();

            //// UPDATE:
            //customersLogic.Update(new Customers
            //{
            //    ContactName = "Gustavo Fring",
            //    CustomerID = "LPHMX"
            //});

            //foreach (var item in customersLogic.GetAll())
            //{
            //    Console.WriteLine($"{item.CustomerID}\t{item.CompanyName}\t{item.ContactName}");
            //}

            //Console.WriteLine();


            //// DELETE:
            //customersLogic.Delete("LPHMX");

            //foreach (var item in customersLogic.GetAll())
            //{
            //    Console.WriteLine($"{item.CustomerID}\t{item.CompanyName}\t{item.ContactName}");
            //}

            Console.ReadLine();
        }

        public static void ShowUI()
        {
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║     SELECCIONAR UNA OPCIÓN      ║");
            Console.WriteLine("║                                 ║");
            Console.WriteLine("║ -1 VER TABLA DE EMPLEADOS.      ║");
            Console.WriteLine("║ -2 VER TABLA DE CLIENTES.       ║");
            Console.WriteLine("║                                 ║");
            Console.WriteLine("╚═════════════════════════════════╝");

            string option;
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    try
                    {
                        ShowEmployeesTable();

                        ShowAbmUI("EMPLEADOS");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

                case "2":
                    try
                    {
                        ShowCustomersTable();

                        ShowAbmUI("CLIENTES");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Por favor, ingrese una opción válida:");
                    ShowUI();
                    break;
            }
        }

        public static void ShowAbmUI(string table)
        {


            Console.WriteLine($"Tabla selecionada: {table}.");
            Console.WriteLine("");
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║    SELECCIONAR UNA OPERACIÓN    ║");
            Console.WriteLine("║                                 ║");
            Console.WriteLine("║ -1 NUEVO REGISTRO.              ║");
            Console.WriteLine("║ -2 MODIFICAR REGISTRO.          ║");
            Console.WriteLine("║ -3 ELIMINAR REGISTRO.           ║");
            Console.WriteLine("║ -4 CONSULTAR TABLA.             ║");
            Console.WriteLine("║                                 ║");
            Console.WriteLine("╚═════════════════════════════════╝");

            string option;
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    try
                    {
                        if (table == "CLIENTES")
                        {
                            CustomersLogic customersLogic = new CustomersLogic();

                            string id;
                            string name;
                            string contact;

                            Console.Write("Ingrese ID de cliente (deber esta compuesto de 5 caracteres):");
                            id = Console.ReadLine();
                            Console.Write("Ingrese el nombre de la compañia:");
                            name = Console.ReadLine();
                            Console.Write("Ingrese el nombre de contacto:");
                            contact = Console.ReadLine();

                            customersLogic.Add(new Customers
                        {
                            CustomerID = id,
                            CompanyName = name,
                            ContactName = contact
                        });
                            
                        }
                        else
                        {
                            EmployeesLogic employeesLogic = new EmployeesLogic();

                            string firstName;
                            string lastName;
                            string title;

                            Console.Write("Ingrese el nombre del empleado:");
                            firstName = Console.ReadLine();
                            Console.Write("Ingrese el apellido del empleado:");
                            lastName = Console.ReadLine();
                            Console.Write("Ingrese el cargo del empleado:");
                            title = Console.ReadLine();

                            employeesLogic.Add(new Employees
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                Title = title
                            });                            
                        }

                        try
                        {
                            ShowPreviousMenu(table);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

                case "2":
                    try
                    {
                        if (table == "CLIENTES")
                        {
                            CustomersLogic customersLogic = new CustomersLogic();

                            string id;
                            string name;
                            string contact;

                            Console.Write("Ingrese ID de cliente (deber esta compuesto de 5 caracteres):");
                            id = Console.ReadLine().ToUpper();
                            Console.Write("Ingrese el nombre de la compañia:");
                            name = Console.ReadLine();
                            Console.Write("Ingrese el nombre de contacto:");
                            contact = Console.ReadLine();

                            customersLogic.Update(new Customers
                            {
                                CustomerID = id,
                                CompanyName = name,
                                ContactName = contact
                            });                            
                        }
                        else
                        {
                            EmployeesLogic employeesLogic = new EmployeesLogic();

                            string firstName;
                            string lastName;
                            string title;
                            int id;

                            Console.Write("Ingrese el ID del empleado:");
                            id = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese el nombre del empleado:");
                            firstName = Console.ReadLine();
                            Console.Write("Ingrese el apellido del empleado:");
                            lastName = Console.ReadLine();
                            Console.Write("Ingrese el cargo del empleado:");
                            title = Console.ReadLine();

                            employeesLogic.Update(new Employees
                            {
                                EmployeeID = id,
                                FirstName = firstName,
                                LastName = lastName,
                                Title = title
                            });
                        }

                        try
                        {
                            ShowPreviousMenu(table);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

                case "3":
                    try
                    {
                        if (table == "CLIENTES")
                        {
                            string customerID;
                            Console.WriteLine("Ingrese el ID del Cliente que desea eliminar:");
                            customerID = Console.ReadLine();
                            CustomersLogic customersLogic = new CustomersLogic();
                            
                            customersLogic.Delete(customerID);
                        }
                        else
                        {
                            string employeeID;
                            Console.WriteLine("Ingrese el ID del Empleado que desea eliminar:");
                            employeeID = Console.ReadLine();
                            CustomersLogic customersLogic = new CustomersLogic();

                            customersLogic.Delete(employeeID);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

                case "4":
                    try
                    {
                        if (table == "CLIENTES")
                        {
                            ShowCustomersTable();

                            ShowPreviousMenu(table);
                        }
                        else
                        {
                            ShowEmployeesTable();

                            ShowPreviousMenu(table);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Por favor, ingrese una opción válida:");
                    ShowAbmUI(table);
                    break;
            }
        }

        public static void ShowEmployeesTable()
        {
            EmployeesLogic employeesLogic = new EmployeesLogic();

            Console.WriteLine($"EMPLOYEE_ID\tFULL_NAME\t\tTITLE");

            foreach (var item in employeesLogic.GetAll())
            {
                Console.WriteLine($"{item.EmployeeID}\t\t{item.LastName}, {item.FirstName}\t\t{item.Title}");
            }
        }

        public static void ShowCustomersTable()
        {
            CustomersLogic customersLogic = new CustomersLogic();

            Console.WriteLine($"CUSTOMER_ID\tCOMPANY_NAME\t\t\t\tCONTACT_NAME\tCOUNTRY");

            foreach (var item in customersLogic.GetAll())
            {
                Console.WriteLine($"{item.CustomerID}\t\t{item.CompanyName}\t\t\t{item.ContactName}\t{item.Country}");
            }
        }

        public static void ShowPreviousMenu(string table)
        {
            Console.WriteLine("");
            string goToMenu = "";
            Console.WriteLine("Desea volver al menú anterior? (s/n)");
            goToMenu = Console.ReadLine();


            if (goToMenu == "s")
            {
                ShowAbmUI(table);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
