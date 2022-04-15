using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

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
            var movie= _dbContext.Movies.Include(x=> x.MovieActors).ThenInclude(x=> x.Actor).SingleOrDefault(x=> x.Id==MovieId);
            var actorIds=Model.MovieActors.ToList();

            if(movie is null)
               throw new InvalidOperationException("Film bulunamadı!");

            movie.MovieName = Model.MovieName==default ? movie.MovieName : Model.MovieName;
            movie.DirectorId = Model.DirectorId==default ? movie.DirectorId : Model.DirectorId;
            movie.GenreId = Model.GenreId==default ? movie.GenreId : Model.GenreId;
           //movie.ActorId = Model.ActorId==default ? movie.ActorId : Model.ActorId;
            movie.Price = Model.Price==default ? movie.Price : Model.Price;
            movie.PublisDate = Model.PublisDate<=DateTime.Now.Date.AddDays(-10) ? Model.PublisDate:movie.PublisDate;

            List<MovieActor> movieActors= new List<MovieActor>();
            foreach (var actorId in Model.MovieActors)
            {
                var actor = _dbContext.Actors.Where(x=> x.Id==actorId).FirstOrDefault();

                if(actor is null)
                   throw new InvalidOperationException("Actor mevcut değil!");

                movieActors.Add(new MovieActor{
                    Actor=actor,
                    Movie=movie
                }) ;
            }
            movie.MovieActors=movieActors;
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
        public ICollection<int> MovieActors { get; set; }
    }
}