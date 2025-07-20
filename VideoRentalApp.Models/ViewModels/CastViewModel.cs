using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Domain.Enums;
using VideoRentalApp.Domain.Models;

namespace VideoRentalApp.Models.ViewModels
{
    public class CastViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public PartEnum Part { get; set; }
    }
}
