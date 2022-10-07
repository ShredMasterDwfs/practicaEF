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
            Console.ReadLine();
        }

        public static void ShowUI()
        {
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║     SELECCIONAR UNA OPCIÓN      ║");
            Console.WriteLine("║                                 ║");
            Console.WriteLine("║ -1 VER TABLA DE EMPLEADOS.      ║");
            Console.WriteLine("║ -2 VER TABLA DE CLIENTES.       ║");
            Console.WriteLine("║ -3 SALIR.                       ║");
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
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "3":
                    Environment.Exit(0);
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
            Console.WriteLine("");
            Console.WriteLine($"Tabla seleccionada: {table}.");
            Console.WriteLine("");
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║    SELECCIONAR UNA OPERACIÓN    ║");
            Console.WriteLine("║                                 ║");
            Console.WriteLine("║ -1 NUEVO REGISTRO.              ║");
            Console.WriteLine("║ -2 MODIFICAR REGISTRO.          ║");
            Console.WriteLine("║ -3 ELIMINAR REGISTRO.           ║");
            Console.WriteLine("║ -4 CONSULTAR TABLA.             ║");
            Console.WriteLine("║ -5 MENÚ ANTERIOR                ║");
            Console.WriteLine("║ -6 SALIR                        ║");
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

                            string companyId;
                            string name;
                            string contact;                            
                            
                            Console.Write("Ingrese el nombre de la compañia:");
                            name = Console.ReadLine();
                            Console.Write("Ingrese el nombre de contacto:");
                            contact = Console.ReadLine();
                            companyId = GenerateStringId(name);

                            customersLogic.Add(new Customers
                            {
                                CustomerID = companyId,
                                CompanyName = name,
                                ContactName = contact
                            });

                            Console.WriteLine("Registro agregado correctamente.");
                            ShowPreviousMenu(table);
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

                            Console.WriteLine("Registro agregado correctamente.");
                            ShowPreviousMenu(table);
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
                            try
                            {
                                CustomersLogic customersLogic = new CustomersLogic();

                                string id;
                                string name;
                                string contact;
                              
                                Console.Write("Ingrese ID de cliente (deber esta compuesto de 5 caracteres):");
                                id = Console.ReadLine();

                                if (id.Length == 5 && (!int.TryParse(id, out _)))
                                {
                                    id.ToUpper();
                                } else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("ID incorrecto.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    ShowAbmUI(table);
                                }

                                
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

                                Console.WriteLine("Registro actualizado correctamente.");
                                ShowPreviousMenu(table);
                            }
                            catch (NullReferenceException)
                            {
                                Console.WriteLine("Formato incorrecto.");
                                ShowAbmUI(table);
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                            
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

                            Console.WriteLine("Registro actualizado correctamente.");
                            ShowPreviousMenu(table);                                                   
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
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Formato incorrecto.");
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
                            try
                            {
                                string customerID;
                                Console.WriteLine("Ingrese el ID del Cliente que desea eliminar:");
                                customerID = Console.ReadLine().ToUpper();

                                CustomersLogic customersLogic = new CustomersLogic();
                            
                                customersLogic.Delete(customerID);
                                Console.WriteLine("Registro eliminado correctamente.");
                                ShowPreviousMenu(table);
                            }
                            catch (NullReferenceException)
                            {
                                Console.WriteLine("Formato incorrecto. El ID de cliente esta formado por 5 caracteres.");
                                Console.WriteLine("");
                                ShowAbmUI(table);
                            }
                            catch (ArgumentNullException)
                            {
                                Console.WriteLine($"No se encontró el ID especificado.");
                                Console.WriteLine("");
                                ShowAbmUI(table);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No se puede eliminar el ID especificado porque la tabla contiene relaciones con otras tablas.");
                                ShowAbmUI(table);
                            }
                        }
                        else
                        {
                            try
                            {
                                string employeeID;
                                Console.WriteLine("Ingrese el ID del Empleado que desea eliminar:");
                                employeeID = Console.ReadLine();

                                EmployeesLogic employeesLogic = new EmployeesLogic();

                                employeesLogic.Delete(employeeID);
                                Console.WriteLine("Registro eliminado correctamente.");
                                ShowPreviousMenu(table);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine($"Formato incorrecto. El ID debe ser un número entero.");
                                Console.WriteLine("");
                                ShowAbmUI(table);
                            }
                            catch (ArgumentNullException)
                            {                                
                                Console.WriteLine($"No se encontró el ID especificado.");
                                Console.WriteLine("");
                                ShowAbmUI(table);
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Número demasiado grande.");
                                ShowAbmUI(table);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No se puede eliminar el ID especificado porque la tabla contiene relaciones con otras tablas.");
                                ShowAbmUI(table);
                            }                            
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

                case "5":
                    Console.Clear();
                    ShowUI();
                    break;

                case "6":
                    Environment.Exit(0);
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

            Console.WriteLine($"EMPLOYEE_ID\tFULL_NAME\t\t\t\tTITLE");

            foreach (var item in employeesLogic.GetAll())
            {
                Console.WriteLine($"{item.EmployeeID}\t\t{item.LastName}, {item.FirstName}\t\t\t\t{item.Title}");
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
            string goToMenu;
            Console.WriteLine("Desea volver al menú anterior? (s/n)");
            goToMenu = Console.ReadLine().ToLower();


            if (goToMenu == "s")
            {
                ShowAbmUI(table);
            }
            else if (goToMenu == "n")
            {
                Environment.Exit(0);
            }
            else
            {
                ShowPreviousMenu(table);
            }
        }

        public static string GenerateStringId(string name)
        {
            string companyId;
            char[] nameArray = name.ToCharArray();
            companyId = $"{nameArray[0]}{nameArray[1]}{nameArray[2]}{nameArray[nameArray.Length - 2]}{nameArray[nameArray.Length - 1]}".ToUpper();
            return companyId;
        }
    }
}
