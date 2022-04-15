using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }
        private readonly MovieStoreDbContext _dbContext;

        public DeleteDirectorCommand(MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x=> x.Id==DirectorId);

            if(director is null)
               throw new InvalidOperationException($"{DirectorId} id 'li director zaten mevcut değil!");
            
            _dbContext.Directors.Remove(director);
            _dbContext.SaveChanges();
        }
    }
}