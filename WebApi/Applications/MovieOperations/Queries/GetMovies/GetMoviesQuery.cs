using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Applications.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMapper _mapper;
        private readonly MovieStoreDbContext _dbContext;

        public GetMoviesQuery(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MoivesViewModel> Handle()
        {
             var movieList = _dbContext.Movies
                                              .Include(x=>x.Genre)
                                              .Include(x=>x.Director)
                                              .Include(x=> x.MovieActors)
                                              .ThenInclude(x=> x.Actor)
                                              .OrderBy(x => x.Id).ToList();
             //.Include(x=>x.Actor).Include(x=>x.Genre).Include(x=>x.Director).OrderBy(x => x.Id).ToList();
             List<MoivesViewModel> vm= _mapper.Map<List<MoivesViewModel>>(movieList); 
              return vm;
        }
    }
    public class MoivesViewModel
    {
        public string MovieName { get; set; }
        public string PublisDate { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public List<string> ActorName { get; set; }
        public int Price { get; set; }
    }
}