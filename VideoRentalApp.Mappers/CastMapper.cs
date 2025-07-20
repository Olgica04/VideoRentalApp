using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Domain.Models;
using VideoRentalApp.Models.ViewModels;

namespace VideoRentalApp.Mappers
{
    public static class CastMapper
    {
        public static CastViewModel ToCastViewModel(this Cast cast)
        {
            return new CastViewModel()
            {
                Id = cast.Id,
                Name = cast.Name,
                MovieId = cast.MovieId,
                Part = cast.Part
            };
        }
    }
}
