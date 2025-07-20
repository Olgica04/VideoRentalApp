using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Domain.Models;
using VideoRentalApp.Models.ViewModels;

namespace VideoRentalApp.Mappers
{
    public static class RentalMapper
    {
        public static RentalViewModel ToRentalViewModel(this Rental rental)
        {
            return new RentalViewModel()
            {
                Id = rental.Id,
                MovieId = rental.MovieId,
                UserId = rental.UserId,
                RentedOn = rental.RentedOn,
                ReturnedOn = rental.ReturnedOn,
                Movie = rental.Movie.ToMovieViewModel(),
                User = rental.User.ToUserViewModel()
            };
        }
    }
}
