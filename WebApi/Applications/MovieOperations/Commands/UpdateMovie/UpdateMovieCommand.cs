using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public UpdateMovieModel Model { get; set; }
        public int MovieId { get; set; }
        private readonly MovieStoreDbContext _dbContext;

        public UpdateMovieCommand(MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var movie= _dbContext.Movies.SingleOrDefault(x=> x.Id==MovieId);

            if(movie is null)
               throw new InvalidOperationException("Film bulunamadı!");

            movie.MovieName = Model.MovieName==default ? movie.MovieName : Model.MovieName;
            movie.DirectorId = Model.DirectorId==default ? movie.DirectorId : Model.DirectorId;
            movie.GenreId = Model.GenreId==default ? movie.GenreId : Model.GenreId;
            movie.ActorId = Model.ActorId==default ? movie.ActorId : Model.ActorId;
            movie.Price = Model.Price==default ? movie.Price : Model.Price;
            movie.PublisDate = Model.PublisDate<=DateTime.Now.Date.AddDays(-10) ? Model.PublisDate:movie.PublisDate;

            _dbContext.SaveChanges();   
        }
    }
    public class UpdateMovieModel
    {
        public string MovieName { get; set; }
        public DateTime PublisDate { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
        public int ActorId { get; set; }
        public int Price { get; set; }
    }
}