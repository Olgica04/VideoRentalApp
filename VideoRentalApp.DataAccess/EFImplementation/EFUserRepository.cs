using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.DataAccess.Interfaces;
using VideoRentalApp.Domain.Models;

namespace VideoRentalApp.DataAccess.EFImplementation
{
    public class EFUserRepository : IRepository<User>
    {
        private readonly VideoRentalAppDbContext _dbContext;

        public EFUserRepository(VideoRentalAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(User entity)
        {
            _dbContext.User.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if(user != null)
            {
                _dbContext.User.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public IQueryable<User> GetAll()
        {
            return _dbContext.Set<User>();
        }

        public User GetById(int id)
        {
            return _dbContext.User.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User entity)
        {
            _dbContext.User.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
