using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Domain.Enums;

namespace VideoRentalApp.Domain.Models
{
    public class Cast : BaseEntity
    {
        public string  Name { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public PartEnum Part { get; set; }
    }
}
