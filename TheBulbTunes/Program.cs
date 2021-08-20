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

            //// Create a number of songs
            //songService.Create("All Over", "Tiwa Savage", "Sugarcane", "", "Afro-pop, Romantic", new DateTime(2017, 5, 22));
            //songService.Create("Nobody's Business", "Rihanna", "Unapologetic", "Chris Brown", "R&B", new DateTime(2012, 1, 1));
            //songService.Create("Get Down On It", "Kool & The Gang", "Something Special", "", "Funk", new DateTime(1981, 11, 24));
            //songService.Create("The Monster", "Eminem", "Marshall Matters", "Rihanna", "R&B/Rap", new DateTime(2013, 1, 1));
            //songService.Create("Essence", "Wizkid", "Made In Lagos", "Tems", "R&B", new DateTime(2020, 10, 30));

            //// Fetch all songs
            List<Song> availableSongs = songService.FetchAll();

            //Console.Write("Title\tArtist\tAlbum");
            //foreach (Song song in availableSongs)
            //{
            //    Console.WriteLine();
            //    Console.Write($"{song.Title}\t{song.Artist}\t{song.Album}");
            //}

            // Fetch songs that meet some search criteria
            List<Song> filteredSongs1 = songService.FetchWithFilter("over", "romantic", null, null);
            List<Song> filteredSongs2 = songService.FetchWithFilter("Ess", "R", "Lagos", "Kid");
            //List<Song> filteredSongs3;
            //List<Song> filteredSongs4;

            //Console.WriteLine("\n\nFILTERED SONGS FOR JANE\n");
            //Console.Write("Title\t\tArtist\t\tAlbum");
            //foreach (Song song in filteredSongs1)
            //{
            //    Console.WriteLine();
            //    Console.Write($"{song.Title}\t{song.Artist}\t{song.Album}");
            //}

            //Console.WriteLine("\n\nFILTERED SONGS FOR HOPE\n");
            //Console.Write("Title\t\tArtist\t\tAlbum");
            //foreach (Song song in filteredSongs2)
            //{
            //    Console.WriteLine();
            //    Console.Write($"{song.Title}\t{song.Artist}\t{song.Album}");
            //}


            // Set the id of song to be updated
            Guid idOfSongToUpdate1 = new Guid("D0E4740A-6D90-41BB-423C-08D963264A6B"); // Non-existing id
            Guid idOfSongToUpdate2 = new Guid("D0E4740A-6D90-41BB-423C-08D963264A4B"); // Existing id

            // Create a Song object containing new info for the update
            Song songWithNewInfo = new Song()
            {
                Genre = "Rap/Hip-hop",
                ReleaseDate = new DateTime(2013, 3, 31)
            };

            // Call the Update method to make the desired update
            songService.Update(idOfSongToUpdate1, songWithNewInfo);
            songService.Update(idOfSongToUpdate2, songWithNewInfo);

            Console.WriteLine("\n\nFILTERED SONGS FOR JANE\n");
            // Fetch all songs after update
            availableSongs = songService.FetchAll();

            Console.WriteLine("\n\nCURRENTLY AVAILABLE SONGS:\n");
            Console.Write("Title\t\tArtist\t\tAlbum\t\tGenre");
            
            foreach (Song song in availableSongs)
                {
                    Console.WriteLine();
                    Console.Write($"{song.Title}\t{song.Artist}\t{song.Album}\t{song.Genre}");
                }

          

            // Set the id of song to be deleted
            Guid idOfSongToDelete1 = new Guid("D0E4740A-6D90-41BB-423C-08D963264A7B"); // Non-existing id
            Guid idOfSongToDelete2 = new Guid("D0E4740A-6D90-41BB-423C-08D963264A4B"); // Existing id

            // Call the Delete method to perform the desired deletion
            songService.Delete(idOfSongToDelete1);
            songService.Delete(idOfSongToDelete2);

            // Fetch all songs after delete
            availableSongs = songService.FetchAll();

            Console.WriteLine("\n\nCURRENTLY AVAILABLE SONGS:\n");
            Console.Write("Title\t\tArtist\t\tAlbum");
            
            foreach (Song song in availableSongs)
                {
                    Console.WriteLine();
                    Console.Write($"{song.Title}\t{song.Artist}\t{song.Album}");
                }


        }

    }
}