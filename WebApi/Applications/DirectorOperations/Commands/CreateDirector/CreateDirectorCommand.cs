using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        public CreateDirectorModel Model { get; set; }
        private readonly MovieStoreDbContext _dbContext ;
        private readonly IMapper _mapper ;

        public CreateDirectorCommand(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x=> x.FullName==Model.FullName);

            if(director is not null)
              throw new InvalidOperationException($"{Model.FullName} isimli yönetmen zaten var!");
            
            director= _mapper.Map<Director>(Model);
            _dbContext.Directors.Add(director);
            _dbContext.SaveChanges();
        }
    }
    public class CreateDirectorModel
    {
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}