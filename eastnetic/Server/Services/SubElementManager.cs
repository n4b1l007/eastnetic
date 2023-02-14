using AutoMapper;
using eastnetic.Server.Interfaces;
using eastnetic.Server.Models;
using eastnetic.Shared.DTO;
using eastnetic.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace eastnetic.Server.Services
{
    public class SubElementManager : ISubElement
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _dbContext = new();

        public SubElementManager(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //To Get all SubElement details
        public List<SubElementDto> GetSubElementDetails()
        {
            try
            {
                return (from subElmt in _dbContext.SubElements
                        join win in _dbContext.Windows on subElmt.WindowId equals win.Id
                        select new SubElementDto
                        {
                            Id = subElmt.Id,
                            WindowId = subElmt.WindowId,
                            Element = subElmt.Element,
                            Type = subElmt.Type,
                            Height = subElmt.Height,
                            Width = subElmt.Width,
                            Window = win.Name,
                        }).ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new SubElement record
        public void AddSubElement(SubElementDto SubElement)
        {
            try
            {
                var model = _mapper.Map<SubElement>(SubElement);
                _dbContext.SubElements.Add(model);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar SubElement
        public void UpdateSubElementDetails(SubElementDto SubElement)
        {
            try
            {
                var model = _mapper.Map<SubElement>(SubElement);
                _dbContext.Entry(model).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular SubElement
        public SubElementDto GetSubElementData(int id)
        {
            try
            {
                SubElement? SubElement = _dbContext.SubElements.Find(id);
                if (SubElement != null)
                {
                    var dto = _mapper.Map<SubElementDto>(SubElement);
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

        //To Delete the record of a particular SubElement
        public void DeleteSubElement(int id)
        {
            try
            {
                SubElement? SubElement = _dbContext.SubElements.Find(id);
                if (SubElement != null)
                {
                    _dbContext.SubElements.Remove(SubElement);
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