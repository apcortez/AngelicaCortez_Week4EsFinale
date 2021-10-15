using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4.EsFinale.Core.BusinessLayer;
using Week4.EsFinale.Core.Models;
using Week4.EsFinale.EF.Repositories;

namespace Week4.EsFinale.Wcf
{
    public class CustomerService : ICustomerService
    {

        private MainBL mainBL;

        public CustomerService()
        {
            mainBL = new MainBL(new EFOrderRepository(), new EFCustomerRepository());
        }

        public bool AddCustomer(Customer newCustomer)
        {
            if (newCustomer == null)
                return false;

            return mainBL.CreateCustomer(newCustomer);
        }

        public bool DeleteCustomerById(int id)
        {
            Customer customer = mainBL.GetCustomerById(id);
            if (id > 0 || customer != null)
                return mainBL.DeleteCustomer(customer);


            return false;
        }

        public List<Customer> GetAllCustomers()
        {
            var result = mainBL.FetchCustomers().ToList();
            return result;
        }

        public Customer GetCustomerByCode(string code)
        {
            return mainBL.GetCustomerByCode(code);
        }

        public Customer GetCustomerById(int id)
        {
            if (id > 0)
                return mainBL.GetCustomerById(id);


            return null;
        }

        public bool UpdateCustomer(Customer updatedCustomer)
        {
            if (updatedCustomer == null)
                return false;

            return mainBL.EditCustomer(updatedCustomer);
        }
    }
}
