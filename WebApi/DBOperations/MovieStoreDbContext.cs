using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class MovieStoreDbContext : DbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options){}

        public DbSet<Movie> Movies {get; set;}
        public DbSet<Actor> Actors {get; set;}
        public DbSet<Genre> Genres {get; set;}
        public DbSet<Director> Directors {get; set;}

        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Movie> DirectorMovies { get; set; }


         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>()
        .HasKey(bc => new { bc.MovieId , bc.ActorId});
            modelBuilder.Entity<MovieActor>()
                .HasOne(bc => bc.Movie)
                .WithMany(b => b.MovieActors)
                .HasForeignKey(bc => bc.MovieId);
            modelBuilder.Entity<MovieActor>()
                .HasOne(bc => bc.Actor)
                .WithMany(c => c.MovieActors)
                .HasForeignKey(bc => bc.ActorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}