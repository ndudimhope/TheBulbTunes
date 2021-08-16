using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBulbTunes.EFDataService.Models;

namespace TheBulbTunes.EFDataService
{
   public class AppDbContext:DbContext
    {
        string connectionString;

        //Constructor to set up connection to database
        public AppDbContext()
        {
            connectionString = "Data Source=.;Initial Catalog=SchoolAdminDB;Integrated Security=True;Pooling=False";
        }

        //DBSet properties, one for each entity/model
        public DbSet<User> Users { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Favourite> Favourites { get; set; }


        //OnConfiguring Method
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString);

        }

        /*
         A favourite must have one song as selected song
         A favourite must have one User as added id
         */

        public void Configure(EntityTypeBuilder<Favourite> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.SelectedSong)
                .WithMany(s => s.FavouritesList)
                .HasForeignKey(f => f.SelectedSongId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.AddedBy)
                .WithMany(u => u.FavouritesList)
                .HasForeignKey(f => f.AddedByUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }


        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u=>u.UserId);

           
        }

        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(s=>s.SongId);

            
        }
    }
}
