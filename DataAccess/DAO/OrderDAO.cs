using BusinessObject.Context;
using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        //Get Order
        public static List<Order> GetOrders()
        {
            var listOrders = new List<Order>();
            try
            {
                using(var context = new eStoreDBContext())
                {
                    listOrders = context.Orders.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return listOrders;
        }

        //Find Order By Id
        public static Order GetOrderById(int id)
        {
            Order order = new Order();
            try
            {
                using( var context = new eStoreDBContext())
                {
                    order = context.Orders.SingleOrDefault(x => x.OrderId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return order;
        }

        //Save Order
        public static void SaveOrder(Order order)
        {
            try
            {
                using(var context = new eStoreDBContext())
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Update Order
        public static void UpdateOrder(Order order)
        {
            try
            {
                using( var context = new eStoreDBContext())
                {
                    context.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Delete Order
        public static void DeleteOrder(Order order)
        {
            try
            {
                using (var context = new eStoreDBContext())
                {
                    var order1 = context.Orders.SingleOrDefault(c => c.OrderId == order.OrderId);
                    context.Orders.Remove(order1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
