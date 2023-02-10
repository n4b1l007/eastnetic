using AutoMapper;
using eastnetic.Server.Interfaces;
using eastnetic.Server.Models;
using eastnetic.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace eastnetic.Server.Services
{
    public class OrderManager : IOrder
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _dbContext = new();

        public OrderManager(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //To Get all Order details
        public List<OrderDto> GetOrderDetails()
        {
            try
            {
                var listOrders = _dbContext.Orders.ToList();
                return _mapper.Map<List<OrderDto>>(listOrders);
            }
            catch
            {
                throw;
            }
        }

        //To Add new Order record
        public void AddOrder(OrderDto Order)
        {
            try
            {
                var model = _mapper.Map<Order>(Order);
                _dbContext.Orders.Add(model);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar Order
        public void UpdateOrderDetails(OrderDto Order)
        {
            try
            {
                var model = _mapper.Map<Order>(Order);
                _dbContext.Entry(model).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Order
        public OrderDto GetOrderData(int id)
        {
            try
            {
                Order? Order = _dbContext.Orders.Find(id);
                if (Order != null)
                {
                    var dto = _mapper.Map<OrderDto>(Order);
                    return dto;
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