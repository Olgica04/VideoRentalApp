using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Models.ViewModels;

namespace VideoRentalApp.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel LogIn(string email, long cardNumber);
        UserViewModel? GetUserByEmail(string email);
    }
}
