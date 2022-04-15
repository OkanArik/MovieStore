using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        private readonly MovieStoreDbContext _dbContext ;

        public UpdateGenreCommand( MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.Where(x=> x.Id==GenreId).FirstOrDefault();

            if(genre is null)
              throw new InvalidOperationException("Güncellemek istediğiniz id'li tür mevcut değil!");

            genre.Name=Model.Name==default ? genre.Name : Model.Name;
            _dbContext.SaveChanges();
        }
    }
    public class UpdateGenreModel
    {
        public string Name { get; set; }
    }
}