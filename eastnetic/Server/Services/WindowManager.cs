using AutoMapper;
using eastnetic.Client.Pages.Order;
using eastnetic.Client.Pages.Window;
using eastnetic.Server.Interfaces;
using eastnetic.Server.Models;
using eastnetic.Shared.DTO;
using eastnetic.Shared.Model;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using System.Collections.Generic;

namespace eastnetic.Server.Services
{
    public class WindowManager : IWindow
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _dbContext = new();

        public WindowManager(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //To Get all Window details
        public List<WindowDto> GetWindowDetails()
        {
            try
            {
                var result = (from windo in _dbContext.Windows
                              join order in _dbContext.Orders on windo.OrderId equals order.Id
                              join subElement in _dbContext.SubElements on windo.Id equals subElement.WindowId into gj
                              from subpet in gj.DefaultIfEmpty()
                              select new
                              {
                                  Id = windo.Id,
                                  Name = windo.Name,
                                  QuantityOfWindows = windo.QuantityOfWindows,
                                  OrderId = windo.OrderId,
                                  Order = order.Name,
                                  subElement = subpet.Id
                              })
                              .GroupBy(g => g.Id)
                              .Select(s => new WindowDto
                              {
                                  Id = s.FirstOrDefault().Id,
                                  Name = s.FirstOrDefault().Name,
                                  QuantityOfWindows = s.FirstOrDefault().QuantityOfWindows,
                                  OrderId = s.FirstOrDefault().OrderId,
                                  Order = s.FirstOrDefault().Order,
                                  TotalSubElements = s.Any(a => a.subElement == null) ? 0 : s.Count()
                              })
                              .ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //To Add new Window record
        public void AddWindow(WindowDto Window)
        {
            try
            {
                var model = _mapper.Map<Window>(Window);
                _dbContext.Windows.Add(model);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar Window
        public void UpdateWindowDetails(WindowDto Window)
        {
            try
            {
                var model = _mapper.Map<Window>(Window);
                _dbContext.Entry(model).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Window
        public WindowDto GetWindowData(int id)
        {
            try
            {
                Window? Window = _dbContext.Windows.Find(id);
                if (Window != null)
                {
                    var dto = _mapper.Map<WindowDto>(Window);
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

        //To Delete the record of a particular Window
        public void DeleteWindow(int id)
        {
            try
            {
                Window? Window = _dbContext.Windows.Find(id);
                if (Window != null)
                {
                    _dbContext.Windows.Remove(Window);
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