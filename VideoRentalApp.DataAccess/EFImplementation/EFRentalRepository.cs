using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.DataAccess.Interfaces;
using VideoRentalApp.Domain.Models;

namespace VideoRentalApp.DataAccess.EFImplementation
{
    public class EFRentalRepository : IRepository<Rental>
    {
        private readonly VideoRentalAppDbContext _dbContext;

        public EFRentalRepository(VideoRentalAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Rental entity)
        {
            _dbContext.Rental.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var rental = GetById(id);
            if(rental != null)
            {
                _dbContext.Rental.Remove(rental);
                _dbContext.SaveChanges();
            }
        }

        public IQueryable<Rental> GetAll()
        {
            return _dbContext.Set<Rental>();
        }

        public Rental GetById(int id)
        {
            return _dbContext.Rental.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Rental entity)
        {
            _dbContext.Rental.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
