using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4.EsFinale.Core.Interfaces;
using Week4.EsFinale.Core.Models;

namespace Week4.EsFinale.EF.Repositories
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly OrderContext ctx;

        public EFCustomerRepository() : this(new OrderContext())
        {

        }

        public EFCustomerRepository(OrderContext ctx)
        {
            this.ctx = ctx;
        }


        public bool Add(Customer item)
        {
            if (item == null)
                return false;
            try
            {
                ctx.Customers.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Customer item)
        {
            try
            {
                var customer = ctx.Customers.Find(item.Id);

                if (customer == item)
                    ctx.Customers.Remove(item);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Customer> FetchAll()
        {
            try
            {
                var customers= ctx.Customers.ToList();
                return customers;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public Customer GetByCode(string code)
        {
            return ctx.Customers.Where(c => c.CustomerCode == code).FirstOrDefault();
        }

        public Customer GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Customers.Find(id);
        }

        public bool Update(Customer item)
        {

            if (item == null)
                return false;

            try
            {
                ctx.Customers.Update(item);

                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
