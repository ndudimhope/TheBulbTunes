using System;
using TheBulbTunes.EFDataService;
using TheBulbTunes.EFDataService.Models;
using System.Linq;
using TheBulbTunes.EFDataService.Services;
using System.Collections.Generic;

namespace TheBulbTunes
{
    class Program
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService();

            ////Create Users
            //userService.Create("Hope", "Casso","cassolagos@gmail.com");
            //userService.Create("Tems", "Shantee", "shantee@gmail.com");
            //userService.Create("Enoch", "Emeka", "nochnoch@gmail.com");
            //userService.Create("Presh", "Ndudim", "presh@gmail.com");
            //userService.Create("Cephas", "Ademosun", "cephas@gmail.com");

            ////Fetch All Users
            //List<User> availableUsers = userService.FetchAll();

            //Console.Write("FirstName\tLastNmae\tEmail");
            //foreach (User user in availableUsers)
            //{
            //    Console.WriteLine();
            //    Console.Write($"{user.FirstName}\t{user.LastName}\t{user.EmailAddress}");
            //}


            //Fetch Users that meet Filter Criteria
            List<User> filteredUser1 = userService.FetchWithFilter("Hop", "ss", null);
            List<User> filteredUser2 = userService.FetchWithFilter("noc", "mek", "noch");

            Console.WriteLine("\n\n FILTERED USER1\n");
          

            foreach (User user in filteredUser1)
            {


                Console.Write("FirstName\tLastNmae\tEmail");
                Console.WriteLine();
                Console.Write($"{user.FirstName}\t{user.LastName}\t{user.EmailAddress}");

            }


        }

    }
}