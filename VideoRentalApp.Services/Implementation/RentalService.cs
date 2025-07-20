using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.DataAccess.EFImplementation;
using VideoRentalApp.DataAccess.Interfaces;
using VideoRentalApp.Domain.Models;
using VideoRentalApp.Mappers;
using VideoRentalApp.Models.ViewModels;
using VideoRentalApp.Services.Interfaces;

namespace VideoRentalApp.Services.Implementation
{
    public class RentalService : IRentalService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Rental> _rentalRepository;

        public RentalService(IRepository<Movie> movieRepository, IRepository<Rental> rentalRepository)
        {
            _movieRepository = movieRepository;
            _rentalRepository = rentalRepository;
        }
        public List<RentalViewModel> GetRentalsByUserId(int userId)
        {
            return _rentalRepository.GetAll().Include(x => x.User).Include(x => x.Movie)
                .Where(r => r.UserId == userId && r.RentedOn != null && r.ReturnedOn == null).Select(x => x.ToRentalViewModel()).ToList();
        }

        public void RentMovie(int movieId, int userId)
        {
            var movie = _movieRepository.GetById(movieId);

            if (movie != null && movie.Quantity >= 0)
            {
                var rental = new Rental
                {
                    MovieId = movieId,
                    UserId = userId,
                    RentedOn = DateTime.Now
                };

                movie.Quantity--;

                if(movie.Quantity == 0)
                {
                    movie.IsAvailable = false;
                }

                _movieRepository.Update(movie);
                _rentalRepository.Create(rental);
            }
        }      

        public void ReturnMovie(int rentalId, int movieId)
        {
            var rental = _rentalRepository.GetById(rentalId);
            rental.ReturnedOn = DateTime.Now;
            _rentalRepository.Update(rental);

            var movie = _movieRepository.GetById(movieId);
            movie.Quantity++;
            if(movie.Quantity == 1)
            {
                movie.IsAvailable = true;
            }
            _movieRepository.Update(movie);

        }
    }
}
