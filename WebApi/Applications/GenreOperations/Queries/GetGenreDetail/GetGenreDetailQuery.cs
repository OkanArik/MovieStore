using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGenreDetailQuery(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre=_dbContext.Genres.SingleOrDefault(x=> x.Id==GenreId);

            if(genre is null)
               throw new InvalidOperationException("Aradığınız tür bulunamadı!");
            
            GenreDetailViewModel vm=_mapper.Map<GenreDetailViewModel>(genre);
            return vm;
        }
    }
    public class GenreDetailViewModel
    {
        public string Name { get; set; }
    }
}