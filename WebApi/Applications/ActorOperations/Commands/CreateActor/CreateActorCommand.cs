using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        private readonly IMapper _mapper;
        private readonly MovieStoreDbContext _dbContext ;
        public CreateActorModel  Model { get; set; }
        public CreateActorCommand(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(movie=> movie.Fullname==Model.Fullname);

                if(actor is not null)
                   throw new InvalidOperationException("Oyuncu zaten mevcut!");
                
                actor = _mapper.Map<Actor>(Model);

                _dbContext.Actors.Add(actor);
                _dbContext.SaveChanges();
        }
    }
    public class CreateActorModel
    {
        public string Fullname { get; set; }
        public DateTime Birthday { get; set; }
    }
}