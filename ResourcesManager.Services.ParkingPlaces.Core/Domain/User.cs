using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public string Fullname { get; private set; }
        public string Email { get; private set; }

        private User()
        {
        }
        public User(string email, string username, string password, string salt)
        {

        }
    }
}
