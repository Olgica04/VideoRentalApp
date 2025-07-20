using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Domain.Enums;

namespace VideoRentalApp.Models.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public GenreEnum Genre { get; set; }
        public LanguageEnum Language { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Duration { get; set; }
        public int AgeRestriction { get; set; }
        public int Quantity { get; set; }
    }
}