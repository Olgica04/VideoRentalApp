using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.DataAccess.EFImplementation;
using VideoRentalApp.Models.ViewModels;
using VideoRentalApp.Services.Interfaces;
using VideoRentalApp.Mappers;
using VideoRentalApp.DataAccess.Interfaces;
using VideoRentalApp.Domain.Models;

namespace VideoRentalApp.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public UserViewModel? GetUserByEmail(string email)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Email == email);

            return user?.ToUserViewModel();
        }

        public UserViewModel LogIn(string email, long cardNumber)
        {
            var user = GetUserByEmail(email);

            if(user == null)
            {
                throw new Exception("Not Found");
            }

            if(user.CardNumber != cardNumber)
            {
                throw new Exception("Unauthorized");
            }

            return user;
        }
    }
}