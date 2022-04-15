using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        private readonly IMapper _mapper;
        private readonly MovieStoreDbContext _dbContext ;
        public CreateMovieModel  Model { get; set; }
        public CreateMovieCommand(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(movie=> movie.MovieName==Model.MovieName);

                if(movie is not null)
                   throw new InvalidOperationException("Film zaten mevcut!");
                
                movie =new Movie{
                    DirectorId=Model.DirectorId,
                    GenreId=Model.GenreId,
                    MovieName=Model.MovieName,
                    Price=Model.Price,
                    PublisDate=Model.PublisDate,
                    MovieActors=new List<MovieActor>{}
                };
                //_mapper.Map<Movie>(Model);
                foreach (var actorId in Model.ActorsId)
                {
                    var actor = _dbContext.Actors.SingleOrDefault(x=>x.Id==actorId);

                    if(actor is null)
                       throw new InvalidOperationException("Aktör bulunamadı!");
                    
                    movie.MovieActors.Add(new MovieActor{
                        Actor=actor,
                        Movie=movie
                    });  
                }

                _dbContext.Movies.Add(movie);
                _dbContext.SaveChanges();
        }
    }
    public class CreateMovieModel
    {
        public string MovieName { get; set; }
        public DateTime PublisDate { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
        public ICollection<int> ActorsId { get; set; }
        public int Price { get; set; }
    }
}