using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGenreCommand(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var genre= _dbContext.Genres.Where(x=> x.Name==Model.Name);

            if(genre is null)
              throw new InvalidOperationException("Tür zaten mevcut!");

            var newGenre = _mapper.Map<Genre>(Model);
            
            _dbContext.Genres.Add(newGenre);
            _dbContext.SaveChanges();
        }

    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}