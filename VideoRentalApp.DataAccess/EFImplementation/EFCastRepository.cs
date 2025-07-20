using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.DataAccess.Interfaces;
using VideoRentalApp.Domain.Models;

namespace VideoRentalApp.DataAccess.EFImplementation
{
    public class EFCastRepository : IRepository<Cast>
    {
        private readonly VideoRentalAppDbContext _dbContext;

        public EFCastRepository (VideoRentalAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Cast entity)
        {
            _dbContext.Cast.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var cast = GetById(id);
            if (cast != null)
            {
                _dbContext.Cast.Remove(cast);
                _dbContext.SaveChanges();
            }
        }

        public IQueryable<Cast> GetAll()
        {
            return _dbContext.Set<Cast>();
        }

        public Cast GetById(int id)
        {
            return _dbContext.Cast.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Cast entity)
        {
            _dbContext.Cast.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
