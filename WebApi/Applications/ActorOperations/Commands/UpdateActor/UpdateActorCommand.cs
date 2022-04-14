using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public UpdateActorModel Model { get; set; }
        public int ActorId { get; set; }
        private readonly MovieStoreDbContext _dbContext;

        public UpdateActorCommand(MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var actor= _dbContext.Actors.SingleOrDefault(x=> x.Id==ActorId);

            if(actor is null)
               throw new InvalidOperationException("Oyuncu bulunamadı!");

            actor.Fullname = Model.Fullname==default ? actor.Fullname : Model.Fullname;
            actor.Birthday = Model.Birthday==default ? actor.Birthday : Model.Birthday;

            _dbContext.SaveChanges();   
        }
    }
    public class UpdateActorModel
    {
        public string Fullname { get; set; }
        public DateTime Birthday { get; set; }
    }
}