using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.DataAccess.EFImplementation;
using VideoRentalApp.Domain.Models;
using VideoRentalApp.Models.ViewModels;
using VideoRentalApp.Services.Interfaces;
using VideoRentalApp.Mappers;
using VideoRentalApp.DataAccess.Interfaces;

namespace VideoRentalApp.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;

        public MovieService (IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<MovieViewModel> GetAll()
        {
            var movies = _movieRepository.GetAll();
            return movies.Select(x => x.ToMovieViewModel()).ToList();
        }

        public MovieViewModel GetMovieById(int id)
        {
            var movie = _movieRepository.GetById(id);
            return movie.ToMovieViewModel();
        }
    }

}
