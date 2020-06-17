using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unitunes.Models;

namespace Unitunes.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Firstname = "batman", Password = "batman", Role = "manager" });
            users.Add(new User { Id = 2, Firstname = "robin", Password = "robin", Role = "employee" });
            return users.Where(x => x.Firstname.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
