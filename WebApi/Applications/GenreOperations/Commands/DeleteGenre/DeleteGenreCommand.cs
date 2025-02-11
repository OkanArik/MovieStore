using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly MovieStoreDbContext _dbContext ;

        public DeleteGenreCommand(MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x=>x.Id==GenreId);

            if(genre is null)
               throw new InvalidOperationException("Tür zaten mevcut değil!");

            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }
    }
}