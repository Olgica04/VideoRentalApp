using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Domain.Enums;

namespace VideoRentalApp.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public int Age { get; set; }
        public long CardNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsSubscriptionExpired { get; set; }
        public SubscriptionTypeEnum SubscriptionType { get; set; }
    }
}
