using VideoRentalApp.Domain.Models;
using VideoRentalApp.Models.ViewModels;

namespace VideoRentalApp.Services.Implementation
{
    public interface IMovieService
    {
        List<MovieViewModel> GetAll();
        MovieViewModel GetMovieById(int id);
    }
}