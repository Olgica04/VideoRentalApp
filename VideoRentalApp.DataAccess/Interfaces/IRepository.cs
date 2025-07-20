using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Domain.Models;

namespace VideoRentalApp.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        //CRUD methods for accessing the db

        IQueryable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
