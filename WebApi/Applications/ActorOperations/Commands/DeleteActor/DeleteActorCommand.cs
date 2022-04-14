using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        public int ActorId { get; set; }
        private readonly MovieStoreDbContext _dbContext;

        public DeleteActorCommand(MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(x=> x.Id == ActorId);

            if(actor is null)
                throw new InvalidOperationException("Oyuncu mevcut değil!");
             
            _dbContext.Actors.Remove(actor);
            _dbContext.SaveChanges();
        }
    }
}