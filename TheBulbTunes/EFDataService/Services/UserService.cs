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

        //Fetch with Filter
        public List<User> FetchWithFilter(string firstNameFilter= null, string lastNameFilter= null, string emailAddressFilter= null)
        {
            _users = FetchAll();


            // If any filter is specified, apply that filter by calling its search method

            if (firstNameFilter != null)
                _users = SearchByFirstName(firstNameFilter, _users);

            if (lastNameFilter != null)
                _users = SearchByFirstName(firstNameFilter, _users);

            if (emailAddressFilter != null)
                _users = SearchByFirstName(firstNameFilter, _users);

            return _users;

        }

        // Private helper methods to simplify searching with various parameters

        private List<User> SearchByFirstName(string searchValue, List<User> users)
        {
            return users.Where(u => u.FirstName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private List<User> SearchByLastName(string searchValue, List<User> users)
        {
            return users.Where(u => u.LastName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private List<User> SearchByEmailAddress(string searchValue, List<User> users)
        {
            return users.Where(u => u.EmailAddress.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }
}
