using CustomerServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4.EsFinale.Core.Models;

namespace Week4.EsFinale.Client.Utilities
{
    public class Menu
    {
        
        
        internal static void Start()
        {
            bool continuare = true;
            Console.WriteLine("################# BENVENUTO! ################");
            do
            {
                Console.WriteLine();
                Console.WriteLine("#############################################");
                Console.WriteLine("Selezionare un operazione da eseguire:");
                Console.WriteLine("1 - Visualizzare tutti i clienti");
                Console.WriteLine("2 - Inserire un nuovo cliente");
                Console.WriteLine("3 - Modificare un cliente");
                Console.WriteLine("4 - Cancellare un cliente");
                Console.WriteLine("0 - Per uscire");
                Console.WriteLine("#############################################");

                Console.WriteLine();
                Console.WriteLine("Quale operazione vuoi scegliere?");
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        FetchCustomers();
                        break;
                    case "2":
                        InsertCustomer();
                        break;
                    case "3":
                        EditCustomer();
                        break;
                    case "4":
                        DeleteCustomer();
                        break;
                    case "0":
                        Console.WriteLine("Arrivederci. A presto!");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata riprova");
                        break;
                }
            } while (continuare);
        }

        private static void DeleteCustomer()
        {
            CustomerServiceClient client = new CustomerServiceClient();
            var customers = client.;
            int i = 1;
            Console.WriteLine("Seleziona il cliente da eliminare: ");
            foreach (var c in customers)
            {
                Console.WriteLine($"{i} - {c.FirstName} - {c.LastName}");
                i++;
            }
            Console.WriteLine();

            bool isInt;
            int clienteScelto;
            do
            {
                Console.WriteLine("Quale cliente?");

                isInt = int.TryParse(Console.ReadLine(), out clienteScelto);

            } while (!isInt || clienteScelto <= 0 || clienteScelto > customers.Count);
            Customer customer = customers.ElementAt(clienteScelto - 1);
            client.DeleteCustomerById(customer.Id);
        }

        private static void EditCustomer()
        {
            CustomerServiceClient client = new CustomerServiceClient();
            List<Customer> customers = client.GetAllCustomers();
            int i = 1;
            Console.WriteLine("Seleziona il cliente da modificare: ");
            foreach (var c in customers)
            {
                Console.WriteLine($"{i} - {c.FirstName} - {c.LastName}");
                i++;
            }
            Console.WriteLine();

            bool isInt;
            int clienteScelto;
            do
            {
                Console.WriteLine("Quale cliente?");

                isInt = int.TryParse(Console.ReadLine(), out clienteScelto);

            } while (!isInt || clienteScelto <= 0 || clienteScelto > customers.Count);
            Customer customer = customers.ElementAt(clienteScelto - 1);
            customer.CustomerCode = InsertCustomerCode();
            customer.FirstName = InsertFirstName();
            customer.LastName = InsertLastName();
            client.UpdateCustomer(customer);
        }

        private static void InsertCustomer()
        {
            CustomerServiceClient client = new CustomerServiceClient();
            Customer customer = new Customer();
                customer.CustomerCode = InsertCustomerCode();
                customer.FirstName = InsertFirstName();
                customer.LastName = InsertLastName();
                customer.Orders = new List<Order>();
                client.AddCustomer(customer);

        }

        private static string InsertLastName()
        {
            string cognome = String.Empty;
            do
            {
                Console.WriteLine("Cognome: ");
                cognome = Console.ReadLine();

            } while (String.IsNullOrEmpty(cognome));
            return cognome;
        }

        private static string InsertFirstName()
        {
            string nome = String.Empty;
            do
            {
                Console.WriteLine("Nome: ");
                nome = Console.ReadLine();

            } while (String.IsNullOrEmpty(nome));
            return nome;
        }

        private static string InsertCustomerCode()
        {
            string code = String.Empty;
            do
            {
                Console.WriteLine("Codice fiscale: ");
                code = Console.ReadLine();

            } while (String.IsNullOrEmpty(code));
            return code;
        }


        private static void FetchCustomers()
        {
            CustomerServiceClient client = new CustomerServiceClient();
            List<Customer> customers = client.GetAllCustomers();
            if (customers.Count != 0)
            {
                foreach (var c in customers)
                {
                    Console.WriteLine($"{c.CustomerCode} - {c.FirstName} - {c.LastName}");
                }
            }
            else
                Console.WriteLine("Elenco di clienti vuota");
        }
    }
}
