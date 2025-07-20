using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRentalApp.Domain.Models
{
    public class Rental : BaseEntity
    {
        public Movie Movie{ get; set; }
        public int MovieId{ get; set; }
        public User User { get; set; }
        public int UserId{ get; set; }
        public DateTime? RentedOn  { get; set; }
        public DateTime? ReturnedOn  { get; set; }

    }
}
