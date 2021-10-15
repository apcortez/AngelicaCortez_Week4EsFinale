using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4.EsFinale.Core.Interfaces;
using Week4.EsFinale.Core.Models;

namespace Week4.EsFinale.EF.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly OrderContext ctx;

        public EFOrderRepository() : this(new OrderContext())
        {

        }

        public EFOrderRepository(OrderContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Order item)
        {
            if (item == null)
                return false;
            try
            {
                ctx.Orders.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Order item)
        {
            try
            {
                var order = ctx.Orders.Find(item.Id);

                if (order == item)
                    ctx.Orders.Remove(item);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Order> FetchAll()
        {
            try
            {
                var orders = ctx.Orders.ToList();
                return orders;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public Order GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Orders.Find(id);
        }

        public bool Update(Order item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Orders.Update(item);

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
