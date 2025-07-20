using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Domain.Models;

namespace VideoRentalApp.Models.ViewModels
{
    public class RentalViewModel
    {
        public int Id { get; set; }
        public MovieViewModel Movie { get; set; }
        public int MovieId { get; set; }
        public UserViewModel User { get; set; }
        public int UserId { get; set; }
        public DateTime? RentedOn { get; set; }
        public DateTime? ReturnedOn { get; set; }
    }
}
