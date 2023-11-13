using BusinessObject.Model;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(Order p)
=> OrderDAO.DeleteOrder(p);


        public Order GetOrderById(int id)
        => OrderDAO.GetOrderById(id);

        public List<Order> GetOrders()
        => OrderDAO.GetOrders();

        public void SaveOrder(Order p)
       => OrderDAO.SaveOrder(p);

        public void UpdateOrder(Order p)
        => OrderDAO.UpdateOrder(p);
    }
}
