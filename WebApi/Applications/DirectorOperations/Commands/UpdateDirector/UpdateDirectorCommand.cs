using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public int DirectorId { get; set; }
        public UpdateDirectorModel Model { get; set; }
        private readonly MovieStoreDbContext _dbContext;

        public UpdateDirectorCommand(MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var director= _dbContext.Directors.SingleOrDefault(x=> x.Id==DirectorId);
            if(director is null)
              throw new InvalidOperationException($"{DirectorId} id'li yönetmen mevcut değil!");

            director.FullName= Model.FullName!=default ? Model.FullName : director.FullName;
            director.BirthDay= Model.BirthDay!=default ? Model.BirthDay : director.BirthDay;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateDirectorModel
    {
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}