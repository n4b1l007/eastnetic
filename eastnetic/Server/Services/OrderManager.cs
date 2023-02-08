using eastnetic.Server.Interfaces;
using eastnetic.Server.Models;
using eastnetic.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace eastnetic.Server.Services
{
    public class OrderManager : IOrder
    {
        private readonly DatabaseContext _dbContext = new();

        public OrderManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //To Get all Order details
        public List<Order> GetOrderDetails()
        {
            try
            {
                return _dbContext.Orders.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new Order record
        public void AddOrder(Order Order)
        {
            try
            {
                _dbContext.Orders.Add(Order);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar Order
        public void UpdateOrderDetails(Order Order)
        {
            try
            {
                _dbContext.Entry(Order).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Order
        public Order GetOrderData(int id)
        {
            try
            {
                Order? Order = _dbContext.Orders.Find(id);
                if (Order != null)
                {
                    return Order;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular Order
        public void DeleteOrder(int id)
        {
            try
            {
                Order? Order = _dbContext.Orders.Find(id);
                if (Order != null)
                {
                    _dbContext.Orders.Remove(Order);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}