using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Domain.Models;
using VideoRentalApp.Models.ViewModels;

namespace VideoRentalApp.Services.Interfaces
{
    public interface IRentalService
    {
        List<RentalViewModel> GetRentalsByUserId(int userId);
        void RentMovie(int movieId, int userId);
        void ReturnMovie(int rentalId, int movieId);
    }
}