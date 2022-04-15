using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenresQuery(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genreList= _dbContext.Genres.OrderBy(x=> x.Id).ToList();
            
            List<GenresViewModel> vm=_mapper.Map<List<GenresViewModel>>(genreList);
            
            return vm;
        }
    }
    public class GenresViewModel
    {
        public string Name { get; set; }
    }
}