using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Applications.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        public DirectorsViewModel Model { get; set; }
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<DirectorsViewModel> Handle()
        {
            var directorList = _dbContext.Directors.Include(x=> x.DirectorMovies).OrderBy(x=> x.Id).ToList();
            var resultList= _mapper.Map<List<DirectorsViewModel>>(directorList);
            return resultList;        
        }
    }

    public class DirectorsViewModel
    {
        public string  FullName { get; set; }
        public string BirthDay { get; set; }
        public List<string> Movies { get; set; }
    }
}