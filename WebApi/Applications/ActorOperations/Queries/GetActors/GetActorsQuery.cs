using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.MovieOperations.Queries.GetActors
{
    public class GetActorsQuery
    {
        private readonly IMapper _mapper;
        private readonly MovieStoreDbContext _dbContext;

        public GetActorsQuery(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ActorsViewModel> Handle()
        {
             var actorList = _dbContext.Actors.OrderBy(x => x.Id).ToList();
             List<ActorsViewModel> vm= _mapper.Map<List<ActorsViewModel>>(actorList); 
              return vm;
        }
    }
    public class ActorsViewModel
    {
        public string Fullname { get; set; }
        public string Birthday { get; set; }
    }
}