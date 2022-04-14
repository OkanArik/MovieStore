using System;
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
                
                movie = _mapper.Map<Movie>(Model);

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
        public int ActorId { get; set; }
        public int Price { get; set; }
    }
}