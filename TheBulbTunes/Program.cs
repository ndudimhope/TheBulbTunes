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


            SongService songService = new SongService();

            // Create a number of songs
            songService.Create("All Over", "Tiwa Savage", "Sugarcane", "", "Afro-pop, Romantic", new DateTime(2017, 5, 22));
            songService.Create("Nobody's Business", "Rihanna", "Unapologetic", "Chris Brown", "R&B", new DateTime(2012, 1, 1));
            songService.Create("Get Down On It", "Kool & The Gang", "Something Special", "", "Funk", new DateTime(1981, 11, 24));
            songService.Create("The Monster", "Eminem", "Marshall Matters", "Rihanna", "R&B/Rap", new DateTime(2013, 1, 1));
            songService.Create("Essence", "Wizkid", "Made In Lagos", "Tems", "R&B", new DateTime(2020, 10, 30));

            // Fetch all songs
            List<Song> availableSongs = songService.FetchAll();

            Console.Write("Title\tArtist\tAlbum");
            foreach (Song song in availableSongs)
            {
                Console.WriteLine();
                Console.Write($"{song.Title}\t{song.Artist}\t{song.Album}");
            }


        }

    }
}