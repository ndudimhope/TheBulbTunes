using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBulbTunes.EFDataService.Models;

namespace TheBulbTunes.EFDataService.Services
{
    class UserService
    {
        private readonly AppDbContext _context = new AppDbContext();
        private List<User> _users;


        // Create a song
        public void Create(string firstName, string lastName, string emailAddress)
        {
            User newUser = new User()
            {
                UserId = new Guid(),
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress

            };
            _context.Users.Add(newUser);
            _context.SaveChanges();

        }

        //Fetch All Users
        public List<User> FetchAll()
        {
            return _context.Users.ToList();
        }


    }
}
