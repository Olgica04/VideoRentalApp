using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Domain.Enums;
using VideoRentalApp.Domain.Models;
using VideoRentalApp.Models.ViewModels;

namespace VideoRentalApp.Mappers
{
    public static class MoviesMapper
    {
        public static MovieViewModel ToMovieViewModel(this Movie movie)
        {
            return new MovieViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Language = movie.Language,
                IsAvailable = movie.IsAvailable,
                ReleaseDate = movie.ReleaseDate,
                Duration = movie.Duration,
                AgeRestriction = movie.AgeRestriction,
                Quantity = movie.Quantity
            };
        }
    }
}