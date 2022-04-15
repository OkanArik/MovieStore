using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Applications.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        public int MovieId { get; set; }
        private readonly IMapper _mapper;
        private readonly MovieStoreDbContext _dbContext;

        public GetMovieDetailQuery(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MoiveDetailViewModel Handle()
        {
             var movie = _dbContext.Movies
                                          .Include(x=>x.Genre)
                                          .Include(x=>x.Director)
                                          .Include(x=> x.MovieActors)
                                          .ThenInclude(x=>x.Actor)
                                          .Where(movie => movie.Id==MovieId).SingleOrDefault();

             if(movie is null)
               throw new InvalidOperationException("Film bulunamadı!");
            
            MoiveDetailViewModel vm = _mapper.Map<MoiveDetailViewModel>(movie);
            return vm;
        }
    }
    public class MoiveDetailViewModel
    {
        public string MovieName { get; set; }
        public string PublisDate { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public List<string> ActorName { get; set; }
        public int Price { get; set; }
    }
}