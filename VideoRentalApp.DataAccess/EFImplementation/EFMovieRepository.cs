using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.DataAccess.Interfaces;
using VideoRentalApp.Domain.Models;

namespace VideoRentalApp.DataAccess.EFImplementation
{
    public class EFMovieRepository : IRepository<Movie>
    {
        private readonly VideoRentalAppDbContext _dbContext;

        public EFMovieRepository(VideoRentalAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Movie entity)
        {
            _dbContext.Movie.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = GetById(id);

            if(movie != null)
            {
                _dbContext.Movie.Remove(movie);
                _dbContext.SaveChanges();
            }
        }

        public IQueryable<Movie> GetAll()
        {
            return _dbContext.Set<Movie>();
        }

        public Movie GetById(int id)
        {
            return _dbContext.Movie.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Movie entity)
        {
            _dbContext.Movie.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
