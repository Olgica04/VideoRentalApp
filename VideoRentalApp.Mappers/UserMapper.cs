using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Domain.Models;
using VideoRentalApp.Models.ViewModels;

namespace VideoRentalApp.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                CardNumber = user.CardNumber,
                FirstName = user.FirstName
            };
        }
    }
}
